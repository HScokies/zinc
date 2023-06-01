using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zinc_api.Models.Entities
{
    public class Tech_pok
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "date")]
        DateTime period { get; set; } // Для уточнения наименования аттрибутов
        public int num { get; set; }
        public int dep_id { get; set; }
        public Department department { get; set; } = new();
        public int station_id { get; set; }
        public Station station { get; set; } = new();
        public string? name { get; set; } = null!;
        public string? uom { get; set; }
    }
}
