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

            switch (_main.cmbSelectPoke.SelectedValue.ToString())
            {
                case "Bulbasaur":
                    var bulb = PokemonStats.PokemonMaxStats.Bulbasaur();
                    int percentagebulb = (int)Math.Round((double)(100 * totalOwnedPokemon) / bulb);
                    return percentagebulb;
                case "Ivysaur":
                    var ivy = PokemonStats.PokemonMaxStats.Ivysaur();
                    int percentageivy = (int)Math.Round((double)(100 * totalOwnedPokemon) / ivy);
                    return percentageivy;
                case "Venasaur":
                    var vena = PokemonStats.PokemonMaxStats.Ivysaur();
                    int percentagevena = (int)Math.Round((double)(100 * totalOwnedPokemon) / vena);
                    return percentagevena;
                default:
                    return -1;
            }
        }
    }
}
