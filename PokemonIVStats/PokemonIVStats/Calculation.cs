using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PokemonIVStats
{
    public class Calculation
    {
        public static void CalcIVs(MainWindow _main, int hpev, int hp, int atkev, int atk, int defev, int def, int spatkev, int spatk, int spdefev, int spdef, int speedev, int speed, int level)
        {
            Pokemon pokemon = (Pokemon)_main.cmbSelectPoke.SelectedItem;

            float baseAttack = pokemon.Attack;
            float baseDefense = pokemon.Defense;
            float baseSpAtk = pokemon.SpecialAttack;
            float baseSpDef = pokemon.SpecialDefense;
            float baseSpeed = pokemon.Speed;


            float natureAttack = 0;
            float natureDefense = 0;
            float natureSpAtk = 0;
            float natureSpDef = 0;
            float natureSpeed = 0;

            string nature = _main.cmbSelectNature.SelectedItem.ToString();

            if (nature == "Lonely" || nature == "Brave" || nature == "Adamant" || nature == "Naughty") { natureAttack = 1f; }
            if (nature == "Bold" || nature == "Relaxed" || nature == "Impish" || nature == "Lax") { natureDefense = 1f; }
            if (nature == "Timid" || nature == "Hasty" || nature == "Jolly" || nature == "Naive") { natureSpeed = 1f; }
            if (nature == "Modest" || nature == "Mild" || nature == "Quiet" || nature == "Rash") { natureSpAtk = 1f; }
            if (nature == "Calm" || nature == "Gentle" || nature == "Sassy" || nature == "Careful") { natureSpDef = 1f; }

            if (nature == "Bold" || nature == "Timid" || nature == "Modest" || nature == "Calm") { natureAttack = 0.9f; }
            if (nature == "Lonely" || nature == "Hasty" || nature == "Mild" || nature == "Gentle") { natureDefense = 0.9f; }
            if (nature == "Brave" || nature == "Relaxed" || nature == "Quiet" || nature == "Sassy") { natureSpeed = 0.9f; }
            if (nature == "Adamant" || nature == "Impish" || nature == "Jolly" || nature == "Careful") { natureSpAtk = 0.9f; }
            if (nature == "Naughty" || nature == "Lax" || nature == "Naive" || nature == "Rash") { natureSpDef = 0.9f; }

            double attackIVMax = (((atk / natureAttack) - 5) * 100 / level) - 2 * baseAttack - (atkev / 4);
            double defenseIVMax = (((def / natureDefense) - 5) * 100 / level) - 2 * baseDefense - (defev / 4);
            double spAtkIVMax = (((spatk / natureSpAtk) - 5) * 100 / level) - 2 * baseSpAtk - (spatkev / 4);
            double spDefIVMax = (((spdef / natureSpDef) - 5) * 100 / level) - 2 * baseSpDef - (spdefev / 4);
            double speedIVMax = (((speed / natureSpeed) - 5) * 100 / level) - 2 * baseSpeed - (speedev / 4);

            RoundUpDown(attackIVMax);
            RoundUpDown(defenseIVMax);
            RoundUpDown(spAtkIVMax);
            RoundUpDown(spDefIVMax);
            RoundUpDown(speedIVMax);

            if (attackIVMax < 0 || defenseIVMax < 0 || spAtkIVMax < 0 || spDefIVMax < 0 || speedIVMax < 0 ||
               attackIVMax > 31 || defenseIVMax > 31 || spAtkIVMax > 31 || spDefIVMax > 31 || speedIVMax > 31)
            {
                string x = "Error: IV's are incorrect. Don't ask me why.\nMake sure the EV Yield is between 0 and 3.";
                _main.lblOutput.Content = x;
            }
            else
            {

                double totalIV = (attackIVMax + defenseIVMax + spAtkIVMax + spDefIVMax + speedIVMax) / 5;

                //155
                double perfectionIvPercent = totalIV / 155 * 100;

                _main.lblOutput.Content = $"Your {pokemon.Name} has {perfectionIvPercent}% perfect IV's.";
            }

        }

        public static int RoundUpDown(double input)
        {
            input = Math.Round(input);

            return (int)input;
        }
    }
}
