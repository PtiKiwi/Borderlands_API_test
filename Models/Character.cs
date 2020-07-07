using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BorderlandsDataServices.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required]
        public string CharacterName { get; set; }
        public string CharacterRace { get; set; }
        public string CharacterFaction { get; set; }
        public string CharacterBehaviour { get; set; }
        public int CharacterHealthPoints { get; set; }
        public string CharacterInitiative { get; set; }

        public int LootId { get; set; }
        public Loot CharacterLoot { get; set; }
        public IEnumerable<int> WeaponIds { get; set; }
        public IEnumerable<Weapon> CharacterWeapons { get; set; }
        public IEnumerable<int> ArmorIds { get; set; }
        public IEnumerable<Armor> CharacterArmors { get; set; }
        public IEnumerable<int> ShieldIds { get; set; }
        public IEnumerable<Shield> CharacterShields { get; set; }
    }
}