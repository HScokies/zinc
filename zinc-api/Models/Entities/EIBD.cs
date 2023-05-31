using System.ComponentModel.DataAnnotations;

namespace zinc_api.Models.Entities
{
    public class EIBD // Абстрактная модель сущности для последующего наследования
    {
        [Key]
        public virtual int id { get; set; }
        public  int num { get; set; }
        public  DateTime date { get; set; }
        public  DateTime time { get; set; }
        public  double val { get; set; }
    }
    public class KEC1 : EIBD { }
}
