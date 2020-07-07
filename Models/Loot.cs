using System.Collections;
using System.Collections.Generic;

namespace BorderlandsDataServices.Models
{
    public class Loot
    {
        public int Id { get; set; }
        public int LootXP { get; set; }
        public int LootMoney { get; set; }
        public int LootNumberOfWeapons { get; set; }
        public IEnumerable<int> WeaponIds { get; set; }
        public IEnumerable<Weapon> LootWeapons { get; set; }
        public int LootNumberOfShields { get; set; }
        public IEnumerable<int> ShieldIds { get; set; }
        public IEnumerable<Shield> LootShields { get; set; }
        public int LootNumberOfArmors { get; set; }
        public IEnumerable<int> ArmorIds { get; set; }
        public IEnumerable<Armor> LootArmors { get; set; }
    }
}