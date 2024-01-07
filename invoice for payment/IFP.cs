using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace invoice_for_payment
{

    [Serializable]
    [DataContract]
    public class IFP
    {
        [DataMember]   
        public int PayForDay { get; set; }//ОплатаЗаДень 
        [DataMember]
        public int AmountOfDAys { get; set; }//КоличествоДней 
        [DataMember]
        public int Payford { get; set; }//Штраф За Один День Задержки Оплаты 
        [DataMember]
        public int AmountDayPD { get; set; }//КоличествоДнейЗадержкиОплаты 

        [DataMember]
        public decimal AmountCOpaymentWithout_Penalty //СуммаКОплатеБезШтрафа 
        {
            get { return PayForDay * AmountOfDAys; }
            set { }
        }
        [DataMember]
        public decimal Forfeit//Штраф /// добавить реализацию исключения !!!!
        { get { return AmountDayPD * PayForDay; }
            set { }
        } 

        [DataMember]
        public decimal TotalAmountCOPayment //ОбщаяСуммаКОплате 
        { get{ return AmountCOpaymentWithout_Penalty + Forfeit;  }
            set { }
        }
        

        public IFP() { }
        public IFP (int payForDay, int amountOfDAys, int payford, int amountDayPD)
        {
            PayForDay = payForDay;
            AmountOfDAys = amountOfDAys;
            Payford = payford;
            AmountDayPD = amountDayPD;
        }
    

        public static bool SerializeCalculated { get; set; }=true;

        public override string ToString()
        {
            return $"ОплатаЗаДень:{PayForDay}\n" +
                $" КоличествоДней :{AmountOfDAys}\n" +
                $" Штраф За Один День Задержки Оплаты :{Payford}\n"+
                $"КоличествоДнейЗадержкиОплаты : {AmountDayPD}\n"+
                $"СуммаКОплатеБезШтрафа:{AmountCOpaymentWithout_Penalty}\n"+
                  $"Штраф:{Forfeit}\n" +
                    $"ОбщаяСуммаКОплате:{TotalAmountCOPayment}\n";
        }


    }

}
