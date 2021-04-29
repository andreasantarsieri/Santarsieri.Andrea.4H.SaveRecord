using System.IO.Enumeration;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace Santarsieri.Andrea._4H.SaveRecord.Models
{
    public class Comune

    {
        public int ID {get; set;}
        public string NomeComune {get; set;}
        public string CodiceCastale{get; set;}
    
        
        public Comune(){}

        public Comune(string riga, int id)
        {
            string[] colonne = riga.Split(',');
            ID = id;
            CodiceCastale = colonne[0];
            NomeComune = colonne[1];
            
            

        }
    }

    public class Comuni : List<Comune> // Comuni è una List<Comune>
    {
        public string NomeFile{get;}
        public Comuni(){}

        public Comuni(string fileName)
        {
            NomeFile = fileName;

            using (FileStream fin = new FileStream(fileName, FileMode.Open) )
            {
                StreamReader reader = new StreamReader(fin);
                int id = 1;

                while(!reader.EndOfStream)
                {
                    string riga = reader.ReadLine();
                    Comune c = new Comune(riga, id++);
                    Add( c );

                }
            }
        }
        public void Save()
        {
            string fn = NomeFile.Split(".")[0] + ".bin";
            Save( fn );
        }
        public void Save( string fileName )
        {
            

            FileStream fout = new FileStream(fileName, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fout);

            foreach (Comune comune in this)
            {
                writer.Write(comune.ID);
                writer.Write(comune.CodiceCastale);
                writer.Write(comune.NomeComune);
            }
            writer.Flush();
            writer.Close();
        }
        public void Load()
        {
            string fn = NomeFile.Split(".")[0] + ".bin";
            Load( fn );
        }
        public void Load( string fileName )
        {
            Clear();
            
            FileStream fin = new FileStream( fileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(fin);
            
            Comune c = new Comune();
            //Legge l'ID,il codice Castale e il NomeComune
            c.ID = reader.ReadInt32();

            c.CodiceCastale = reader.ReadString(); 

            c.NomeComune = reader.ReadString();

            Add( c );
            
            c.ID = reader.ReadInt32();
            c.CodiceCastale = reader.ReadString(); 
            c.NomeComune = reader.ReadString();
            Add( c );

            // Manca un while che legge tutte le righe...
            // Come si fa ad accorgersi della fine del file...??
            
        }
    }
}