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
        public static void CalcIVs(MainWindow _main, int hp, int atk, int def, int spatk, int spdef, int speed)
        {
            Pokemon pokemon = (Pokemon)_main.cmbSelectPoke.SelectedItem;

            float maxHealth = pokemon.Hp;
            float maxAttack = pokemon.Attack;
            float maxDefense = pokemon.Defense;
            float maxSpAtk = pokemon.SpecialAttack;
            float maxSpDef = pokemon.SpecialDefense;
            float maxSpeed = pokemon.Speed;

            var TotalMax = maxHealth + maxAttack + maxDefense + maxSpAtk + maxSpDef + maxSpeed;


            double totalIV = (hp + atk + def + spatk + spdef + speed);

            //155
            double perfectionIvPercent = (totalIV / TotalMax) * 100;

            perfectionIvPercent = Math.Round(perfectionIvPercent);

            if (perfectionIvPercent > 100)
            {
                _main.lblOutput.Content = $"Wow your {pokemon.Name} has exceeded the maximum stats!\nThat can't be right.\nAt {perfectionIvPercent}%... are you sure?";
            }
            else
            {
                _main.lblOutput.Content = $"Your {pokemon.Name}\nhas {perfectionIvPercent}% perfect IV's.";
            }
        }
    }
}
