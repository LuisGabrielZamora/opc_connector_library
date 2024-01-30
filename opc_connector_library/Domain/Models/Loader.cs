using System;

namespace opc_connector_library.Domain.Models
{
    public class Loader
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool RecordStatus { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}