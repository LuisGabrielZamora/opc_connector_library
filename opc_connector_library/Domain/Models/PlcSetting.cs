using System;

namespace opc_connector_library.Domain.Models
{
    public class PlcSetting
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool RecordStatus { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string Operations { get; set; } // Assuming Operations is an enum defined earlier
        public string DataTypes { get; set; }
        public string FieldBindingTypes { get; set; }
        public Loader Loader { get; set; }
    }
}