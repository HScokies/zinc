using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zinc_api.Models.Entities
{
    public class Tech_pok
    {
        [Key]
        public int id { get; set; }
        public int station_id { get; set; }
        public Station station { get; set; } = new();
        public int num { get; set; }
        DateOnly period { get; set; } // Для уточнения наименования аттрибутов
        public string? name { get; set; } = null!;
        public string? uom { get; set; }

    }
}
