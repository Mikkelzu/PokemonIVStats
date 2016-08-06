//not in use, probably useful sometime

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonIVStats
{
    public class BaseStats
    {
        public static int[] findBaseStats(int pkmn_id)
        {
            string path = Directory.GetCurrentDirectory();

            int[] stats_int = new int[] { 0, 0, 0, 0, 0, 0 };
            string[] stats_str = new string[] { "0", "0", "0", "0", "0", "0" }; ;
            int line_num = (pkmn_id - 1) * 6;

            for (int i = 0; i < 6; i++)
            {
                stats_str[i] = File.ReadLines(path + "/data/PokemonBaseStats.txt").Skip(line_num).Take(1).First();
                line_num++;
            }

            string[] output;
            int[] baseStats = new int[] { 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 6; i++)
            {
                output = stats_str[i].Split(',');
                baseStats[i] = Int32.Parse(output[2]);
                Console.WriteLine(baseStats[i]);
            }

            return baseStats;
        }
    }
}
