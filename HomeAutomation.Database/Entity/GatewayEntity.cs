using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomation.Database.Entity
{
    [Table("Gateway")]
    public class GatewayEntity
    {
        [Key]
        public int Id { get; set; }
        public string Supplier { get; set; }
        public string Code { get; set; }
        public string IP { get; set; }
        public string Username { get; set; }
    }
}