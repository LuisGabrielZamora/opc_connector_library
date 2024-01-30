using System;
using System.Linq;
using System.Collections.Generic;

using Opc.Da;

using opc_connector_library.Domain.Dtos;
using opc_connector_library.Domain.Constants;
using opc_connector_library.Application.Mappers;

namespace opc_connector_library.Infrastructure.Adapters
{
    public class OpcDaAdapter
    {
        private static readonly Lazy<OpcDaAdapter> _instance = new Lazy<OpcDaAdapter>(() => new OpcDaAdapter());

        private readonly Server _server;
        private readonly OpcCom.Factory _fact = new OpcCom.Factory();

        private Subscription _groupRead;
        private SubscriptionState _groupState;

        private readonly List<Item> _itemsList = new List<Item>();

        private Subscription _groupWrite;

        // Private constructor for the singleton pattern
        private OpcDaAdapter()
        {
            _server = new Server(_fact, null);
        }

        // Public method to get the instance of the class
        public static OpcDaAdapter Instance => _instance.Value;

        public void ConnectToOpcServer()
        {
            try
            {
                if (_server.IsConnected) return;

                _server.Url = new Opc.URL(PlcConstant.OpcServerUrl);
                _server.Connect();

                CreateGroupState(PlcConstant.OpcReadGroup, PlcConstant.Rate, true);
                CreateGroupState(PlcConstant.OpcWriteGroup, PlcConstant.Rate);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                throw;
            }
        }
        
        private void CreateGroupState(
            string groupStateName, int updateRate, bool isReadable = false
        )
        {
            try
            {
                _groupState = new SubscriptionState
                {
                    Name = groupStateName,
                    UpdateRate = updateRate,
                    Active = isReadable
                };

                var internalGroupState = (Subscription)_server.CreateSubscription(_groupState);
        
                if (isReadable)
                {
                    _groupRead = internalGroupState;
                    _groupRead.DataChanged += GroupReadDataChanged;
                    return;
                }
        
                _groupWrite = internalGroupState;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public void AttachItemsToReadGroup(IEnumerable<string> itemNames)
        {
            try
            {
                if (!_server.IsConnected)
                {
                    ConnectToOpcServer();
                }

                if (_groupRead.Items.Length > 0)
                {
                    _groupRead.RemoveItems(_groupRead.Items);
                }
        
                foreach (var item in itemNames.Select(itemName => new Item
                         {
                             ItemName = itemName
                         }))
                {
                    _itemsList.Add(item);
                }

                _groupRead.AddItems(_itemsList.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void WriteData(ParamPlcSettingsDto paramPlcSettingsDto)
        {
            try
            {
                if (!_server.IsConnected)
                {
                    ConnectToOpcServer();
                }

                if (_groupWrite.Items.Length > 0)
                {
                    _groupWrite.RemoveItems(_groupWrite.Items);
                }

                var writeList = new List<Item>();
                var valueList = new List<ItemValue>();

                var plcSettings = PlcSettingsMapper.OpcItems(paramPlcSettingsDto);

                foreach (var opcValueItem in plcSettings)
                {
                    var itemToWrite = new Item
                    {
                        ItemName = opcValueItem.Tag
                    };

                    // TODO: Check if this assignment will be an INTEGER value or STRING 
                    var itemValue = new ItemValue(itemToWrite)
                    {
                        Value = opcValueItem.Value
                    };

                    writeList.Add(itemToWrite);
                    valueList.Add(itemValue);
                }

                //IMPORTANT:
                //#1: assign the item to the group so the items gets a ServerHandle
                _groupWrite.AddItems(writeList.ToArray());

                // #2: assign the server handle to the ItemValue
                for (var i = 0; i < valueList.Count; i++)
                    valueList[i].ServerHandle = _groupWrite.Items[i].ServerHandle;

                // #3: write
                _groupWrite.Write(valueList.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private static void GroupReadDataChanged(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {
            foreach (var itemValue in values) 
            {
                switch (itemValue.ItemName) 
                {
                    // case "[MYPLC]N7:0":
                    //     motorSpeed = Convert.ToInt32(itemValue.Value);
                    //     break;
                    //
                    // case "[MYPLC]O:0/0":
                    //     motorActive = Convert.ToBoolean(itemValue.Value);
                    //     break;
                    //
                    // case "[MYPLC]B3:0/3":
                    //     autManSwitch = Convert.ToBoolean(itemValue.Value);
                    //     break;
                }
            }
        }
    }
}