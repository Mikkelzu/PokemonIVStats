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
        private string name_ = "";
        private int total_ = 0;
        private int hp_ = 0;
        private int attack_ = 0;
        private int defense_ = 0;
        private int specialAttack_ = 0;
        private int specialDefense_ = 0;
        private int speed_ = 0;

        private int _level = 0;

        public static void Init()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Pokemon/pokemondata.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] spl = line.Split(';');
                        if (spl.Length == 9)
                        {
                            try
                            {
                                new Pokemon(Convert.ToInt32(spl[0]), spl[1], Convert.ToInt32(spl[2]), Convert.ToInt32(spl[3]), Convert.ToInt32(spl[4]), Convert.ToInt32(spl[5]), Convert.ToInt32(spl[6]), Convert.ToInt32(spl[7]), Convert.ToInt32(spl[8]));
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

        public Pokemon(int id, string name, int total, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
        {

            id_ = id;
            name_ = name;
            total_ = total;
            hp_ = hp;
            attack_ = attack;
            defense_ = defense;
            specialAttack_ = specialAttack;
            specialDefense_ = specialDefense;
            speed_ = speed;

            pokemonList.Add(this);
        }

        public int Id
        {
            get { return id_; }
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


        public int Level
        {
            get { return _level; }
        }

        public override string ToString()
        {
            return name_;
        }
    }
}