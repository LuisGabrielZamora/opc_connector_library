using System.Linq;
using System.Collections.Generic;
using opc_connector_library.Domain.Dtos;

namespace opc_connector_library.Application.Mappers
{
    public static class PlcSettingsMapper
    {
        public static List<OpcValueItem> OpcItems(ParamPlcSettingsDto paramPlcSettingsDto)
        {
            var data = string.IsNullOrEmpty(paramPlcSettingsDto.FilterOperation)
                ? paramPlcSettingsDto.OpcItems
                :  paramPlcSettingsDto.OpcItems.Where(opcSetting => opcSetting.Operations == paramPlcSettingsDto.FilterOperation);

            return data.Select(opcSetting => new OpcValueItem { Tag = opcSetting.Tag, Value = opcSetting.Value })
                .ToList();
        }
    }
}