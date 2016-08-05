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

        public void Ivysaur()
        {
            GetIV.HP = 60;
            GetIV.Attack = 62;
            GetIV.Defense = 63;
            GetIV.SpecialAttack = 80;
            GetIV.SpecialDefense = 80;
            GetIV.Speed = 60;
        }

        public void Venasaur()
        {
            GetIV.HP = 80;
            GetIV.Attack = 82;
            GetIV.Defense = 83;
            GetIV.SpecialAttack = 100;
            GetIV.SpecialDefense = 100;
            GetIV.Speed = 80;
        }
    }
}
