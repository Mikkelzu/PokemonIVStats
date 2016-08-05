using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using System.Text.RegularExpressions;

namespace PokemonIVStats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //call to filling the list
            FillPokemonList();
        }

        //fills the list in combobox for pokemonnames
        public void FillPokemonList()
        {
            string PathToPokes = @"Pokemon\list_Pokes.txt";

            string[] PokemonFileList = File.ReadAllLines(PathToPokes);

            foreach (var line in PokemonFileList)
            {
                string[] PokemonName = line.Split();
                cmbSelectPoke.Items.Add(PokemonName?[0]);
            }
        }

        private void cmbSelectPoke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentPokemonIndex = cmbSelectPoke.SelectedValue;

            //show normal sprite
            pokemonSpriteImageBox.Source = GetSprite.getNormalSprite(currentPokemonIndex);

            // show shiny sprite
            pokemonShinySpriteImageBox.Source = GetSprite.getShinySprite(currentPokemonIndex);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var statsCalculated = Calculation.CalculatePerfection(Convert.ToInt32(txtHP.Text), Convert.ToInt32(txtAttack.Text), Convert.ToInt32(txtDefense.Text),
                Convert.ToInt32(txtSpAtk.Text), Convert.ToInt32(txtSpDef.Text), Convert.ToInt32(txtSpeed.Text), this);

            if (statsCalculated == -1)
            {
                MessageBox.Show("Pokemon Stats not found!");
            }
            else
            {
                MessageBox.Show(statsCalculated.ToString() + "%");
            }
        }
    }
}
