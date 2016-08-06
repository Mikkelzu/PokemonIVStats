using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonIVStats
{
    public class Nature
    {
        public static List<Nature> NatureList = new List<Nature>();
        private string name_ = "";

        public static void Init()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Pokemon/naturedata.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] spl = line.Split(';');
                        if (spl.Length == 1)
                        {
                            try
                            {
                                new Nature(spl[0]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Nature(string naturename)
        {
            name_ = naturename;

            NatureList.Add(this);
        }

        public string Name
        {
            get { return name_; }
        }

        
        public override string ToString()
        {
            return name_;
        }
    }
}
