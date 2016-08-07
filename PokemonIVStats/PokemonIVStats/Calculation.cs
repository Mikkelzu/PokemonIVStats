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
        public static void CalcIVs(MainWindow main, int hp, int atk, int def, int spatk, int spdef, int speed)
        {
            var pokemon = (Pokemon)main.cmbSelectPoke.SelectedItem;

            float maxHealth = pokemon.Hp;
            float maxAttack = pokemon.Attack;
            float maxDefense = pokemon.Defense;
            float maxSpAtk = pokemon.SpecialAttack;
            float maxSpDef = pokemon.SpecialDefense;
            float maxSpeed = pokemon.Speed;

            var totalMax = maxHealth + maxAttack + maxDefense + maxSpAtk + maxSpDef + maxSpeed;


            double totalIv = (hp + atk + def + spatk + spdef + speed);

            var perfectionIvPercent = (totalIv / totalMax) * 100;

            perfectionIvPercent = Math.Round(perfectionIvPercent);

            main.lblOutput.Content = perfectionIvPercent > 100 ? $"Wow your {pokemon.Name} has exceeded the maximum stats!\nThat can't be right.\nAt {perfectionIvPercent}%... are you sure?"
                : $"Your {pokemon.Name}\nis statistically {perfectionIvPercent}% perfect.";
        }
    }
}
