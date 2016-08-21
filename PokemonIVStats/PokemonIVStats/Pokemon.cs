//thanks CJ!
using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonIVStats
{
    public class Pokemon
    {
        public static List<Pokemon> pokemonList = new List<Pokemon>();

        private int id_ = 0;

        public Pokemon(int id, string name, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
        {
            id_ = id;
            Name = name;
            Hp = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;

            pokemonList.Add(this);
        }


        public string Name { get; } = "";

        public int Hp { get; } = 0;

        public int Attack { get; } = 0;

        public int Defense { get; } = 0;

        public int SpecialAttack { get; } = 0;

        public int SpecialDefense { get; } = 0;

        public int Speed { get; } = 0;

        public override string ToString()
        {
            return Name;
        }

        internal class Initialize
        {
            public static void Init()
            {
                try
                {
                    using (var sr = new StreamReader("Pokemon/pokemondata.txt"))
                    {
                        var line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] spl = line.Split(';');
                            if (spl.Length == 8)
                            {
                                try
                                {
                                    new Pokemon(Convert.ToInt32(spl[0]), spl[1], Convert.ToInt32(spl[2]), Convert.ToInt32(spl[3]), Convert.ToInt32(spl[4]), Convert.ToInt32(spl[5]), Convert.ToInt32(spl[6]), Convert.ToInt32(spl[7]));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}