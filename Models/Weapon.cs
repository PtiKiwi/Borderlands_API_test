using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BorderlandsDataServices.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int WeaponAccuracy { get; set; }
        public int WeaponDamages { get; set; }
        public int WeaponInerty { get; set; }
        public int WeaponMagazine { get; set; }
        public IEnumerable<WeaponFightMode> WeaponAvailableModes { get; set; }
        public WeaponFightMode WeaponCurrentMode { get; set; }
        public string WeaponBrand { get; set; }
        public bool WeaponAreaOfEffect { get; set; }
        public ElementType WeaponElement { get; set; }
        public int WeaponPrice { get; set; }
    }

    public enum ElementType
    {
        None = 0,
        Incendiary = 10,
        Corrosive = 20,
        Electric = 30,
        Explosive = 40
    }

    public enum WeaponFightMode
    {
        CorpsACorps = 0,
        CoupParCoup = 10,
        Rafale = 20,
        Automatique = 30
    }
}