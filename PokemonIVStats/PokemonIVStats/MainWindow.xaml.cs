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

            //call to filling natures
            FillNatureList();
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

        //fills the list in combobox for natures
        public void FillNatureList()
        {
            string PathToNatures = @"Pokemon\list_Natures.txt";

            string[] NatureFileList = File.ReadAllLines(PathToNatures);

            foreach (var line in NatureFileList)
            {
                string[] NatureName = line.Split();
                cmbSelectNature.Items.Add(NatureName?[0]);
            }
        }
    }
}
