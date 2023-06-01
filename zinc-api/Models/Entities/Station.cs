using System.ComponentModel.DataAnnotations;

namespace zinc_api.Models.Entities
{
    public class Station
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int departmentid { get; set; }
        public Department department { get; set; } = new();
        public string name_table { get; set; } = null!;

    }
}
