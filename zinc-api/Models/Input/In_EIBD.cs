using System.ComponentModel.DataAnnotations;

namespace zinc_api.Models.Input
{
    public class In_EIBD  // Модель входной сущности 
    {
        public int num { get; set; } //Индекс столбца дампа (0 = 3)
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
        public double val { get; set; } //Знч-е столбца дампа
    }

}
