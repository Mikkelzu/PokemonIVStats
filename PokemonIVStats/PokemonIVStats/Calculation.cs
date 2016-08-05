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
        public static int CalculatePerfection(int health, int atk, int def, int spatk, int spdef, int speed, MainWindow _main)
        {
            var totalOwnedPokemon = health + atk + def + spatk + spdef + speed;

            //this is 100%
            switch (_main.cmbSelectPoke.SelectedValue.ToString())
            {
                case "Bulbasaur":
                    var totalMaxPokemon = PokemonStats.PokemonMaxStats.Bulbasaur();
                    int percentage = (int)Math.Round((double)(100 * totalOwnedPokemon) / totalMaxPokemon);
                    return percentage;
                default:
                    return -1;
            }
        }
    }
}
