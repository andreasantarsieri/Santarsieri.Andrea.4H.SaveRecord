using System;
using Santarsieri.Andrea._4H.SaveRecord.Models;
 
namespace Santarsieri.Andrea._4H.SaveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SaveRecord - 2021 - andrea.santarsieri@ittsrimini.studenti.edu.it");

            //Leggere un file CSV con i comuni e trasformarlo in una list<Comune>
            
            Comuni c = new Comuni( "Comuni.csv" );           
            
            Console.WriteLine($"Ho letto {c.Count} righe dal file csv.");
            //Scrivere la list<Comune> in un file binario
            c.Save();
            //Rileggere il file binario in una list<Comune>
            c.Load();
            Console.WriteLine($"Ho letto {c.Count} righe dal file binario");
            int index = 100;
            Console.WriteLine($"Ecco la riga {index}: {c[index]}");

        }
    }
}
