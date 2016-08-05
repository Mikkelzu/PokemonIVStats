using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PokemonIVStats
{
    public class GetSprite
    {
        public static BitmapImage getNormalSprite(object currentPokemonIndex)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\Michael\Documents\GitHub\PokemonIVStats\PokemonIVStats\PokemonIVStats\bin\Debug\Sprites\" + currentPokemonIndex + ".png");
            bitmap.EndInit();

            return bitmap;
        }

        public static BitmapImage getShinySprite(object currentPokemonIndex)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\Michael\Documents\GitHub\PokemonIVStats\PokemonIVStats\PokemonIVStats\bin\Debug\Sprites Shiny\" + currentPokemonIndex + ".png");
            bitmap.EndInit();

            return bitmap;
        }
    }
}
