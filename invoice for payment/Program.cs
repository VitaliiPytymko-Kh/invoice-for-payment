using invoice_for_payment.invoice_for_payment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace invoice_for_payment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFP iFP = new IFP(250, 50, 15, 30);
            FileStream fileStream = new FileStream("IFPt.json", FileMode.Create);
            DataContractJsonSerializer data = new DataContractJsonSerializer(typeof(IFP));
            data.WriteObject(fileStream, iFP);
            fileStream.Close();

            fileStream = new FileStream("IFPt.json", FileMode.Open);
            IFP rez = (IFP)data.ReadObject(fileStream);
            Console.WriteLine(rez);
            fileStream.Close();

            IFP.SerializeComputed = false;

            IFP iFP1 = new IFP(50, 20, 10, 0);
            FileStream fileStream1 = new FileStream("IFPf.json", FileMode.Create);
            DataContractJsonSerializer data1 = new DataContractJsonSerializer(typeof(IFP));
            data1.WriteObject(fileStream1, iFP1);
            fileStream1.Close();

            fileStream1 = new FileStream("IFPf.json", FileMode.Open);
            IFP rez2 = (IFP)data1.ReadObject(fileStream1);
            Console.WriteLine(rez2);
            fileStream1.Close();



        }
    }
}
