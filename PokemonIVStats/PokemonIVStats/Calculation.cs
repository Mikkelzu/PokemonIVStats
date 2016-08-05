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
        public static int percentagePerfectionIV = 0;

        public static int CalculatePerfection(int health, int atk, int def, int spatk, int spdef, int speed, int level, MainWindow _main)
        {
            Nature selectedNat = (Nature)_main.cmbSelectNature.SelectedItem;

            var nameNature = selectedNat.Name;

            var decreasedStat = selectedNat.StatDecrName;

            var increasedStat = selectedNat.StatIncrName;
           
            if (nameNature == "Adamant")
            {
                var newAtk = (atk / 10) + atk;
                var newSpAtk = spatk - (spatk / 10);
                var NewCalc = health + newAtk + def + newSpAtk + spdef + speed;


                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;
                
                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * NewCalc) / MaxTotal);
                
            }
            else if (nameNature == "Brave")
            {
                var newAtk = (atk / 10) + atk;
                var newSpeed = speed - (speed / 10);
                var newCalc = health + newAtk + def + spatk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Lonely")
            {
                var newAtk = (atk / 10) + atk;
                var newDef = def - (def / 10);
                var newCalc = health + newAtk + newDef + spatk + spdef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Naughty")
            {
                var newAtk = (atk / 10) + atk;
                var newSpDef = def - (def / 10);
                var newCalc = health + newAtk + def + spatk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Bold")
            {
                var newDef = (def / 10) + def;
                var newAtk = atk - (atk / 10);
                var newCalc = health + newAtk + newDef + spatk + spdef + speed;

                 Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Impish")
            {
                var newDef = (def / 10) + def;
                var newSpAtk = spatk - (spatk / 10);
                var newCalc = health + atk + newDef + newSpAtk + spdef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Lax")
            {
                var newDef = (def / 10) + def;
                var newSpDef = spdef - (spdef / 10);
                var newCalc = health + atk + newDef + spatk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Relaxed")
            {
                var newDef = (def / 10) + def;
                var newSpeed = speed - (speed / 10);
                var newCalc = health + atk + newDef + spatk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Modest")
            {

                /*
                 Formula for IV?
 HP = ((2*Base + IV + EV/4 + 100) * Level) / 100 + 10
Stat = (((2*Base + IV + EV/4) * Level) / 100 + 5) * Nature


                ((HP - 10) * 100) / Level = 2*Base + IV + EV/4 + 100

IV = ((HP - 10) * 100) / Level - 2*Base - EV/4 - 100
EV = (((HP - 10) * 100) / Level - 2*Base - IV - 100) * 4



((Stat/Nature - 5) * 100) / Level = 2*Base + IV + EV/4

IV = ((Stat/Nature - 5) * 100) / Level - 2*Base - EV/4
EV = (((Stat/Nature - 5) * 100) / Level - 2*Base - IV) * 4

*/
                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var maxHP =selectedPok.Hp;
                var maxAtk = selectedPok.Attack;
                var maxDef = selectedPok.Defense;
                var maxSpAtk = selectedPok.SpecialAttack;
                var maxSpDef = selectedPok.SpecialDefense;
                var maxSpeed = selectedPok.Speed;

                var MaxTotal = selectedPok.Total;

                var EV = ((atk - 5) * 100 / level - 2*maxAtk - atk) * 4; 


                //var newSpAtk = (spatk / 10) + spatk;
                //var newAtk = atk - (atk / 10);
                //var newCalc = health + newAtk + def + newSpAtk + spdef + speed;
           
                percentagePerfectionIV = (int)Math.Round((double)(100 * EV) / MaxTotal);
            }
            else if (nameNature == "Mild")
            {
                var newSpAtk = (spatk / 10) + spatk;
                var newDef = def - (def / 10);
                var newCalc = health + atk + newDef + newSpAtk + spdef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Quiet")
            {
                var newSpAtk = (spatk / 10) + spatk;
                var newSpeed = speed - (speed / 10);
                var newCalc = health + atk + def + newSpAtk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Rash")
            {
                var newSpAtk = (spatk / 10) + spatk;
                var newSpDef = spdef - (spdef / 10);
                var newCalc = health + atk + def + newSpAtk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Calm")
            {
                var newSpDef = (spdef / 10) + spdef;
                var newAtk = atk - (atk / 10);
                var newCalc = health + newAtk + def + spatk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Careful")
            {
                var newSpDef = (spdef / 10) + spdef;
                var newSpAtk = spatk - (spatk / 10);
                var newCalc = health + atk + def + newSpAtk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Gentle")
            {
                var newSpDef = (spdef / 10) + spdef;
                var newDef = def - (def / 10);
                var newCalc = health + atk + newDef + spatk + newSpDef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Sassy")
            {
                var newSpDef = (spdef / 10) + spdef;
                var newSpeed = speed - (speed / 10);
                var newCalc = health + atk + def + spatk + newSpDef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Hasty")
            {
                var newSpeed = (speed / 10) + speed;
                var newDef = def - (def / 10);
                var newCalc = health + atk + newDef + spatk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Jolly")
            {
                var newSpeed = (speed / 10) + speed;
                var newSpAtk = spatk - (spatk / 10);
                var newCalc = health + atk + def + newSpAtk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Naive")
            {
                var newSpeed = (speed / 10) + speed;
                var newSpDef = spdef - (spdef / 10);
                var newCalc = health + atk + def + spatk + newSpDef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else if (nameNature == "Timid")
            {
                var newSpeed = (speed / 10) + speed;
                var newAtk = atk - (atk / 10);
                var newCalc = health + newAtk + def + spatk + spdef + newSpeed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * newCalc) / MaxTotal);
            }
            else
            {
                var NatureNoEffect = health + atk + def + spatk + spdef + speed;

                Pokemon selectedPok = (Pokemon)_main.cmbSelectPoke.SelectedItem;

                var MaxTotal = selectedPok.Total;

                percentagePerfectionIV = (int)Math.Round((double)(100 * NatureNoEffect) / MaxTotal);
            }


            return percentagePerfectionIV;
        }
    }
}
