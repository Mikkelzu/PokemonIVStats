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

        public void calculateIVs(int[] baseStats)
        {

            //labelerror.Text = "";

            //parse all the text into integers

            int HPEV = int.Parse(healthEV.Text); ;
            int HPStat = int.Parse(txtHP.Text); ;

            int ATKEV = int.Parse(attackEV.Text);
            int ATKStat = int.Parse(txtAttack.Text);

            int DEFEV = int.Parse(defenseEV.Text); ;
            int DEFStat = int.Parse(txtDefense.Text); ;

            int SPATKEV = int.Parse(spatkEV.Text); ;
            int SPATKStat = int.Parse(txtSpAtk.Text); ;

            int SPDEFEV = int.Parse(spdefEV.Text); ;
            int SPDEFStat = int.Parse(txtSpDef.Text); ;

            int SPDEV = int.Parse(speedEV.Text); ;
            int SPDStat = int.Parse(txtSpeed.Text); ;

            int level = int.Parse(txtLevel.Text);

            float natATK = 1;
            float natDEF = 1;
            float natSPATK = 1;
            float natSPDEF = 1;
            float natSPD = 1;

            //string output = "";
            string nature = cmbSelectNature.SelectedItem.ToString().ToUpper();

            /*Positive Nature Buffs*/
            if (nature == "LONELY" || nature == "BRAVE" || nature == "ADAMANT" || nature == "NAUGHTY") { natATK = 1.1f; } //Attack pos+ natures
            if (nature == "BOLD" || nature == "RELAXED" || nature == "IMPISH" || nature == "LAX") { natDEF = 1.1f; } //Defense pos+ natures
            if (nature == "TIMID" || nature == "HASTY" || nature == "JOLLY" || nature == "NAIVE") { natSPD = 1.1f; }  //Speed pos+ natures
            if (nature == "MODEST" || nature == "MILD" || nature == "QUIET" || nature == "RASH") { natSPATK = 1.1f; } //SpecialAttack pos+ natures
            if (nature == "CALM" || nature == "GENTLE" || nature == "SASSY" || nature == "CAREFUL") { natSPDEF = 1.1f; } //SpecialDefense pos+ natures

            /*Negative Nature DeBuffs*/
            if (nature == "BOLD" || nature == "TIMID" || nature == "MODEST" || nature == "CALM") { natATK = 0.9f; } //Attack neg- natures
            if (nature == "LONELY" || nature == "HASTY" || nature == "MILD" || nature == "GENTLE") { natDEF = 0.9f; } //Defense neg- natures
            if (nature == "BRAVE" || nature == "RELAXED" || nature == "QUIET" || nature == "SASSY") { natSPD = 0.9f; } //Speed neg- natures
            if (nature == "ADAMANT" || nature == "IMPISH" || nature == "JOLLY" || nature == "CAREFUL") { natSPATK = 0.9f; } //SpecialAttack neg- natures
            if (nature == "NAUGHTY" || nature == "LAX" || nature == "NAIVE" || nature == "RASH") { natSPDEF = 0.9f; } //SpecialDefense neg- natures


            double HPIVMax = 0;

            double ATKIVMax = ((Math.Ceiling(ATKStat / natATK) - 5) * 100 / level) - 2 * baseStats[1] - Math.Floor(ATKEV / 4f);
            double DEFIVMax = ((Math.Ceiling(DEFStat / natDEF) - 5) * 100 / level) - 2 * baseStats[2] - Math.Floor(DEFEV / 4f);
            double SPATKIVMax = ((Math.Ceiling(SPATKStat / natSPATK) - 5) * 100 / level) - 2 * baseStats[3] - Math.Floor(SPATKEV / 4f);
            double SPDEFIVMax = ((Math.Ceiling(SPDEFStat / natSPDEF) - 5) * 100 / level) - 2 * baseStats[4] - Math.Floor(SPDEFEV / 4f);
            double SPDIVMax = ((Math.Ceiling(SPDStat / natSPD) - 5) * 100 / level) - 2 * baseStats[5] - Math.Floor(SPDEV / 4f);


            ATKIVMax = Math.Round(ATKIVMax);

            if (HPIVMax < 0 || ATKIVMax < 0 || DEFIVMax < 0 || SPATKIVMax < 0 || SPDEFIVMax < 0 || SPDIVMax < 0 ||
                HPIVMax > 31 || ATKIVMax > 31 || DEFIVMax > 31 || SPATKIVMax > 31 || SPDEFIVMax > 31 || SPDIVMax > 31)
            {
                //labelerror.Text = "Error : Double check your Stats and EVs";
                lblOutput.Content = "Error???!?!?!?!? " + HPIVMax + ATKIVMax + +DEFIVMax + SPATKIVMax;
            }
            else
            {
                //display IVs
                lblOutput.Content = 
                 (HPIVMax).ToString() + " " + (ATKIVMax).ToString() + " " + (DEFIVMax).ToString() + " " +(SPATKIVMax).ToString() + " " + (SPDEFIVMax).ToString() + " " + (SPDIVMax).ToString();

                //print output to output textbox
               // textBox2.Text = BoxSpecies.Text.ToUpper() + "," + BoxNature.Text + "," + (HPIVMax).ToString() + "," + (ATKIVMax).ToString() + "," + (DEFIVMax).ToString() + "," +
                    //(SPATKIVMax).ToString() + "," + (SPDEFIVMax).ToString() + "," + (SPDIVMax).ToString();

            }
            return;
        }


        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string name = cmbSelectPoke.SelectedItem.ToString().ToLower();

            int id = ListOfPokes.pkmnIDs[name];

            int[] basestats = BaseStats.findBaseStats(id);
            calculateIVs(basestats);









            //if (txtHP.Text == "" || txtAttack.Text == "" || txtDefense.Text == "" || txtSpAtk.Text == "" || txtSpDef.Text == "" || txtSpeed.Text == "" || txtLevel.Text == "")
            //{
            //    lblOutput.Content = "One or more values not filled in.\nPlease fill these in.";
            //}
            //else
            //{
            //    var statsCalculated = Calculation.CalculatePerfection(Convert.ToInt32(txtHP.Text), Convert.ToInt32(txtAttack.Text), Convert.ToInt32(txtDefense.Text),
            //   Convert.ToInt32(txtSpAtk.Text), Convert.ToInt32(txtSpDef.Text), Convert.ToInt32(txtSpeed.Text), Convert.ToInt32(txtLevel.Text), this);

            //    // -1 is default case of saying that the pokemon doesnt exist (if theres a new one not implemented yet)
            //    if (statsCalculated == -1)
            //    {
            //        lblOutput.Content = "No Pokemon data found.";
            //    }
            //    else
            //    {
            //        //something doesnt seem right... calculation is wrong or stats are wrong?
            //        Pokemon poke = (Pokemon)cmbSelectPoke.SelectedItem;
            //        //lblOutput.Content = "Your " + poke.Name + " has " + statsCalculated + "% Perfect IV stats.";
            //        lblOutput.Content = "Your " + poke.Name + " has " + statsCalculated + " EV stats.";
            //    }
            //}
        }
    }
}
