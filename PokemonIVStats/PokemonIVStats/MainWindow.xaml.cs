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
            InitAll();

            //call to filling the list
            FillPokemonList();
        }

        public void InitAll()
        {
            Pokemon.Init();
            Nature.Init(); //does nothing yet
        }

        //fills the list in combobox for pokemonnames
        public void FillPokemonList()
        {
            foreach (var pok in Pokemon.pokemonList)
            {
                cmbSelectPoke.Items.Add(pok);
            }
        }
       
        private void cmbSelectPoke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblOutput.Content = "";
            var currentPokemonIndex = cmbSelectPoke.SelectedValue;

            //show normal sprite
            pokemonSpriteImageBox.Source = GetSprite.GetNormalSprite(currentPokemonIndex, this);
            // show shiny sprite
            pokemonShinySpriteImageBox.Source = GetSprite.GetShinySprite(currentPokemonIndex, this);

            ShowMaxStats();

            if (pokemonSpriteImageBox.Source == null)
            {
                lblOutput.Content = "No Sprite not found.";
                pokemonSpriteImageBox.Source = GetSprite.NoImageFound();
            }
            else if (pokemonShinySpriteImageBox.Source == null)
            {
                lblOutput.Content = "Shiny Sprite not found.";
                pokemonShinySpriteImageBox.Source = GetSprite.NoImageFound();
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            if (txtHP.Text == "" || txtAttack.Text == "" || txtDefense.Text == "" || txtSpAtk.Text == "" || txtSpDef.Text == "" || txtSpeed.Text == "")
            {
                lblOutput.Content = "One or more values not filled in.\nPlease fill these in.";
            }
            else
            {

                Calculation.CalcIVs(this, Convert.ToInt32(txtHP.Text), Convert.ToInt32(txtAttack.Text), Convert.ToInt32(txtDefense.Text),
                    Convert.ToInt32(txtSpAtk.Text), Convert.ToInt32(txtSpDef.Text),
                    Convert.ToInt32(txtSpeed.Text));
            }
        }

        public void ShowMaxStats()
        {
            var pokemon = (Pokemon)cmbSelectPoke.SelectedItem;

            lblHP.Content = $"Max HP: {pokemon.Hp}";
            lblAtk.Content = $"Max Attack: {pokemon.Attack}";
            lblDef.Content = $"Max Defense: {pokemon.Defense}";
            lblSpAtk.Content = $"Max Sp. Attack: {pokemon.SpecialAttack}";
            lblSpDef.Content = $"Max Sp. Defense: {pokemon.SpecialDefense}";
            lblSpeed.Content = $"Max Speed: {pokemon.Speed}";
        }
    }
}
