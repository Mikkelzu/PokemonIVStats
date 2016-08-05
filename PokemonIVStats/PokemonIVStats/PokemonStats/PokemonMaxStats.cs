using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonIVStats.PokemonStats
{
    public class PokemonMaxStats
    {
        public static int Bulbasaur()
        {
            var hp = GetIV.HP = 45;
            var atk = GetIV.Attack = 49;
            var def = GetIV.Defense = 49;
            var spatk = GetIV.SpecialAttack = 65;
            var spdef = GetIV.SpecialDefense = 65;
            var speed = GetIV.Speed = 45;

            return hp + atk + def + spatk + spdef + speed;
        }

        public static int Ivysaur()
        {
            var hp = GetIV.HP = 60;
            var atk = GetIV.Attack = 62;
            var def = GetIV.Defense = 63;
            var spatk = GetIV.SpecialAttack = 80;
            var spdef = GetIV.SpecialDefense = 80;
            var speed = GetIV.Speed = 60;

            return hp + atk + def + spatk + spdef + speed;
        }

        public static int Venasaur()
        {
            var hp = GetIV.HP = 80;
            var atk = GetIV.Attack = 82;
            var def = GetIV.Defense = 83;
            var spatk = GetIV.SpecialAttack = 100;
            var spdef = GetIV.SpecialDefense = 100;
            var speed = GetIV.Speed = 80;

            return hp + atk + def + spatk + spdef + speed;
        }
    }
}
