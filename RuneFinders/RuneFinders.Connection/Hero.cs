using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneFinders.Connection
{
    public class Hero
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int LevelPoints { get; set; }
        public int Speed { get; set; }
        public List<Item> Backpack; 
    }
}
