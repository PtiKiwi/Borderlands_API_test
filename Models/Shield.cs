using System.Drawing;

namespace BorderlandsDataServices.Models
{
    public class Shield
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Charges { get; set; }
        public int Absorption { get; set; }
        public string SpecialEffect { get; set; }
    }
}