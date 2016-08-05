using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonIVStats
{
    public class Nature
    {
        public static List<Nature> NatureList = new List<Nature>();
        private string name_ = "";

        public static void InitNatures(MainWindow _main)
        {
            try
            {
                string PathToNatures = @"Pokemon\list_Natures.txt";

                string[] NatureFileList = File.ReadAllLines(PathToNatures);

                foreach (var line in NatureFileList)
                {
                    string[] NatureName = line.Split();
                    _main.cmbSelectNature.Items.Add(NatureName?[0]);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
