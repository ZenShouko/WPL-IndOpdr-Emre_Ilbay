using System.ComponentModel.DataAnnotations;

namespace ClassLib.Business.Entities
{
    public class Card
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int HP { get; set; }

        [Required]
        public string Element { get; set; }

        public string? Weakness { get; set; }
        public string? Resistance { get; set; }

        [Required]
        public int Stage { get; set; }
    }
}
