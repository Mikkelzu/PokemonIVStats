using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.IO;

namespace PokemonIVStats
{
    public class GetSprite
    {
        public static string path = Directory.GetCurrentDirectory();
        public static BitmapImage getNormalSprite(object currentPokemonIndex, MainWindow _main)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path + @"\Sprites\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                _main.lblOutput.Content = "No sprite found.";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path + @"\Sprites\0.png");
                bitmap.EndInit();
                return null;
            }
        }

        public static BitmapImage getShinySprite(object currentPokemonIndex, MainWindow _main)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path + @"\Sprites Shiny\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                _main.lblOutput.Content = "No sprite found.";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path + @"\Sprites Shiny\0.png");
                bitmap.EndInit();
                return null;
            }
        }
    }
}
