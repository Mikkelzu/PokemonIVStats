//thanks CJ!
using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonIVStats
{
    public class Pokemon
    {

        public static List<Pokemon> pokemonList = new List<Pokemon>();

        private string name_ = "";
        private int total_ = 0;
        private int hp_ = 0;
        private int attack_ = 0;
        private int defense_ = 0;
        private int specialAttack_ = 0;
        private int specialDefense_ = 0;
        private int speed_ = 0;

        public static void Init()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Pokemon/attack_stats.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] spl = line.Split(';');
                        if (spl.Length == 2) //change
                        {
                            try
                            {
                                new Pokemon(spl[0], Convert.ToInt32(spl[1])); //todo add more
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

        public Pokemon(string name, int attack)
        {
            name_ = name;
            attack_ = attack;
            
            pokemonList.Add(this);
        }

       
        public string Name
        {
            get { return name_; }
        }

        public int Hp
        {
            get { return hp_; }
        }

        public int Attack
        {
            get { return attack_; }
        }

        public int Defense
        {
            get { return defense_; }
        }

        public int SpecialAttack
        {
            get { return specialAttack_; }
        }

        public int SpecialDefense
        {
            get { return specialDefense_; }
        }

        public int Speed
        {
            get { return speed_; }
        }

        public int Total
        {
            get { return total_; }
        }

        public override string ToString()
        {
            return name_;
        }
    }
}