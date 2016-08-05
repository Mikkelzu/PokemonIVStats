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
        private string increasedStat = "";
        private string decreasedStat = "";

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
                        if (spl.Length == 3)
                        {
                            try
                            {
                                new Nature(spl[0], spl[1], spl[2]);
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

        public Nature(string naturename, string increased, string decreased)
        {
            name_ = naturename;
            increased = increasedStat;
            decreased = decreasedStat;

            NatureList.Add(this);
        }

        public string Name
        {
            get { return name_; }
        }

        public string StatIncrName
        {
            get { return increasedStat; }
        }

        public string StatDecrName
        {
            get { return decreasedStat; }
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
