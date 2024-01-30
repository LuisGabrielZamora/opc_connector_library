using System.Collections.Generic;
using opc_connector_library.Domain.Models;

namespace opc_connector_library.Domain.Dtos
{
    public class ParamPlcSettingsDto
    {
        public string FilterOperation { get; set; }
        public List<OpcSettingValue> OpcItems { get; set; }
    }
}