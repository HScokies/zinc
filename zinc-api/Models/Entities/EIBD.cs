using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zinc_api.Models.Entities
{
    public abstract class EIBD // Абстрактная модель сущности для последующего наследования
    {
        [Key]
        public virtual int id { get; set; }
        public  int num { get; set; } //Индекс столбца дампа (0 = 3)
        [Column(TypeName = "date")]
        public  DateTime date { get; set; }
        [Column(TypeName = "time")]
        public  DateTime time { get; set; }
        public  double val { get; set; } //Знч-е столбца дампа
    }
    public class KEC1 : EIBD { }//CHPEW2
    public class KEC2 : EIBD { }//CHPEW3
    public class KEC_Kadmievoe : EIBD { }//KADMIEVOE
    public class GMC_Velc1 : EIBD { }//IUS_VELC1
    public class GMC_Velc2 : EIBD { }//IUS_VELC2
    public class SKC1 : EIBD { }//IUS_SKC42
    public class SKC2 : EIBD { }//IUS_SKC43
    public class GMC_Larox : EIBD { }//LAROX
    public class OBG1 : EIBD { }//IUS_OBG511
    public class OBG2 : EIBD { }//IUS_OBG52
    public class Velc_KVP5 : EIBD { }//VELC5PC21
    public class Velc_KVP6 : EIBD { }//KVP61
    public class Vysh : EIBD { }//IUS_V5
    public class HVP : EIBD { }//HVP_station
}
