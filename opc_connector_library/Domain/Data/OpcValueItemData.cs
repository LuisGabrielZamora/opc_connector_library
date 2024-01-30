using System;
using System.Collections.Generic;
using opc_connector_library.Domain.Constants;
using opc_connector_library.Domain.Models;

namespace opc_connector_library.Domain.Data
{
    public static class OpcValueItemData
    {
        public static List<OpcSettingValue> Get()
        {
            var loader = new Loader
            {
                Id = new Guid(),
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime(),
                Code = "621DG2",
                Name = "621DG2",
                RecordStatus = true
            };
            
            return new List<OpcSettingValue>
            {
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Silo",
                    Description = "Silo",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.Silo,
                    Value = 1,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                },
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Remision",
                    Description = "Campo de Remisión",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.DeliveryCode,
                    Value = 337992662,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                },
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Id_Transporte",
                    Description = "Identificador de Transporte",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.Shipment,
                    Value = 26618231,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                },
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Peso_SP",
                    Description = "Peso Set Point (Objetivo de Carga)",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.SetPointWeight,
                    Value = 25,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                },
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Tipo_Carga",
                    Description = "Identificador del Tipo de Carga",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.Type,
                    Value = 1,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                },
                new OpcSettingValue
                {
                    Id = new Guid(),
                    Tag = "[PLC63]DATA_REM_621DG2.Id_Material",
                    Description = "Identificador de Material",
                    Operations = Operations.Write,
                    DataTypes = DataTypes.Dint,
                    FieldBindingTypes = FieldBindingTypesConstant.Material,
                    Value = 1478965213,
                    RecordStatus = true,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Loader = loader
                }
            };
        }
    }
}