using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_for_payment
{
    public class IFP
    {
        public int PayForDay { get; set; }//ОплатаЗаДень 
        public int AmountOfDAys { get; set; }//КоличествоДней 
        public int Payford { get; set; }//Штраф За Один День Задержки Оплаты 
        public int AmountDayPD { get; set; }//КоличествоДнейЗадержкиОплаты 

        public decimal AmountCOpaymentWithout_Penalty { get { return PayForDay * AmountOfDAys; } }//СуммаКОплатеБезШтрафа 
        public decimal Forfeit { get { return AmountDayPD * PayForDay; } }//Штраф 
        public decimal TotalAmountCOPayment { get{ return AmountCOpaymentWithout_Penalty + Forfeit;  } }//ОбщаяСуммаКОплате 

        public static bool Serialize_Computed_Fields { get; set; }= true;

    }
}
