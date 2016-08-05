using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PokemonIVStats
{
    public class GetSprite
    {
        public static BitmapImage getNormalSprite(object currentPokemonIndex, MainWindow _main)
        {
            //needs fixing on the URI
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"C:\Users\Michael\Documents\GitHub\PokemonIVStats\PokemonIVStats\PokemonIVStats\bin\Debug\Sprites\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                _main.lblOutput.Content = "No sprite found.";
                return null;
            }

            
        }

        public static BitmapImage getShinySprite(object currentPokemonIndex, MainWindow _main)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"C:\Users\Michael\Documents\GitHub\PokemonIVStats\PokemonIVStats\PokemonIVStats\bin\Debug\Sprites Shiny\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                _main.lblOutput.Content = "No sprite found.";
                return null;
            }
        }
    }
}
