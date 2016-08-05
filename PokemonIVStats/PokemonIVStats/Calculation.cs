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

            Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

            var MaxTotal = selectedPok.Total;

            int percentagePerfectionIV = (int)Math.Round((double)(100 * totalOwnedPokemon) / MaxTotal);

            return percentagePerfectionIV;   
        }
    }
}
