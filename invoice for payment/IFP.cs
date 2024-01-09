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
    namespace invoice_for_payment
    {
        [Serializable]
        [DataContract]
        public class IFP
        {
            [DataMember]
            public int PayForDay { get; set; } //ОплатаЗаДень 

            [DataMember]
            public int AmountOfDays { get; set; } //КоличествоДней 

            [DataMember]
            public int PayForDelay { get; set; } //Штраф За Один День Задержки Оплаты 

            [DataMember]
            public int AmountDaysForDelay { get; set; } //КоличествоДнейЗадержкиОплаты 

            [DataMember]
            public decimal AmountCOpaymentWithout_Penalty //СуммаКОплатеБезШтрафа 
            {
                get { return PayForDay * AmountOfDays; }
                set { }
            }

            [DataMember]
            public decimal Forfeit //Штраф
            {
                get
                {
                    if (_serializeComputed)
                    {
                        return AmountDaysForDelay * PayForDay;
                    }
                    else
                    {
                        return 0;
                    }
                }
                set { }
            }

            [DataMember]
            public decimal TotalAmountCOPayment //ОбщаяСуммаКОплате 
            {
                get { return AmountCOpaymentWithout_Penalty + Forfeit; }
                set { }
            }

            private static bool _serializeComputed = true;

            public static bool SerializeComputed
            {
                get { return _serializeComputed; }
                set { _serializeComputed = value; }
            }

            public IFP() { }

            public IFP(int payForDay, int amountOfDays, int payForDelay, int amountDaysForDelay)
            {
                PayForDay = payForDay;
                AmountOfDays = amountOfDays;
                PayForDelay = payForDelay;
                AmountDaysForDelay = amountDaysForDelay;
            }

            public override string ToString()
            {
                string result = $"ОбщаяСуммаКОплате:{TotalAmountCOPayment}\n" +
                       $"ОплатаЗаДень:{PayForDay}\n" +
                       $"КоличествоДней :{AmountOfDays}\n" +
                       $"Штраф За Один День Задержки Оплаты :{PayForDelay}\n" +
                       $"КоличествоДнейЗадержкиОплаты : {AmountDaysForDelay}\n";

                if (_serializeComputed)
                {
                    result += $"СуммаКОплатеБезШтрафа:{AmountCOpaymentWithout_Penalty}\n" +
                              $"Штраф:{Forfeit}\n";

                }
                    return result;
                }
            }

        }
    }

