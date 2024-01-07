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
            IFP iFP = new IFP(150,20,15,30);
            FileStream fileStream = new FileStream("IFP3.json",FileMode.Create);
            DataContractJsonSerializer data=new DataContractJsonSerializer(typeof(IFP));
            data.WriteObject(fileStream, iFP);
            fileStream.Close();
        }
    }
}
