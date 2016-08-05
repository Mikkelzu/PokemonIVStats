//////////////////////
//TODO
//FINISH DOCUMENT
/////////////////////

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
                using (StreamReader sr = new StreamReader("Pokemon/nature.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] spl = line.Split(';');
                        if (spl.Length == 9)
                        {
                            try
                            {
                                new Pokemon(Convert.ToInt32(spl[0]), spl[1], Convert.ToInt32(spl[2]), Convert.ToInt32(spl[3]), Convert.ToInt32(spl[4]), Convert.ToInt32(spl[5]), Convert.ToInt32(spl[6]), Convert.ToInt32(spl[7]), Convert.ToInt32(spl[8]));
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
        }

        public string Name
        {
            get { return name_; }
        }

        public float Increased
        {
            get { return 10; }
        }

        public float Decreased
        {
            get { return 10; }
        }

        public override string ToString()
        {
            return name_;
        }
    }
}
