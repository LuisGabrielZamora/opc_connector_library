using opc_connector_library.Domain.Data;
using opc_connector_library.Domain.Dtos;
using opc_connector_library.Domain.Constants;
using opc_connector_library.Infrastructure.Adapters;

namespace opc_connector_library
{
    public static class Bootstrapping
    {
        public static void Run()
        {
            var opcDaAdapter = OpcDaAdapter.Instance;
            
            // Connect to the opc server
            opcDaAdapter.ConnectToOpcServer();

            if (FeatureFlag.IsDevWriteProcessActive)
            {
                opcDaAdapter.WriteData(new ParamPlcSettingsDto { FilterOperation = Operations.Write, OpcItems = OpcValueItemData.Get() });
            }
        }
    }
}