using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NawOpdracht.Data.DataObjects
{
    [Table("Address", Schema = "Naw")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string HouseNumber { get; set; }
    }
}
