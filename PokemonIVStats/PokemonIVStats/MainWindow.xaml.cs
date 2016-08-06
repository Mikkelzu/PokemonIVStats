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
            FillNatureList();

        }

        public void InitAll()
        {
            Pokemon.Init();
            Nature.Init();
        }

        //fills the list in combobox for pokemonnames
        public void FillPokemonList()
        {
            Pokemon.Init();

            foreach (Pokemon pok in Pokemon.pokemonList)
            {
                cmbSelectPoke.Items.Add(pok);
            }
        }

        public void FillNatureList()
        {
            foreach (Nature nat in Nature.NatureList)
            {
                cmbSelectNature.Items.Add(nat);
            }
        }
        private void cmbSelectPoke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblOutput.Content = "";
            var currentPokemonIndex = cmbSelectPoke.SelectedValue;


            // missing the sprites for mega evolutions. coming soon
            //show normal sprite
            pokemonSpriteImageBox.Source = GetSprite.getNormalSprite(currentPokemonIndex, this);

            // show shiny sprite
            pokemonShinySpriteImageBox.Source = GetSprite.getShinySprite(currentPokemonIndex, this);

            if (pokemonSpriteImageBox.Source == null)
            {
                lblOutput.Content = "No Sprite not found.";
            }
            else if (pokemonShinySpriteImageBox.Source == null)
            {
                lblOutput.Content = "Shiny Sprite not found.";
            }
        }


        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            if (txtHP.Text == "" || txtAttack.Text == "" || txtDefense.Text == "" || txtSpAtk.Text == "" || txtSpDef.Text == "" || txtSpeed.Text == "" || txtLevel.Text == "")
            {
                lblOutput.Content = "One or more values not filled in.\nPlease fill these in.";
            }
            else
            {

                Calculation.CalcIVs(this, Convert.ToInt32(txtHPEV.Text), Convert.ToInt32(txtHP.Text), Convert.ToInt32(txtATKEV.Text), Convert.ToInt32(txtAttack.Text), Convert.ToInt32(txtDEFEV.Text),
                Convert.ToInt32(txtDefense.Text), Convert.ToInt32(txtSPATKEV.Text), Convert.ToInt32(txtSpAtk.Text), Convert.ToInt32(txtSPDEFEV.Text), Convert.ToInt32(txtSpDef.Text),
                Convert.ToInt32(txtSPEEDEV.Text), Convert.ToInt32(txtSpeed.Text), Convert.ToInt32(txtLevel.Text));
            }
        }
    }
}
