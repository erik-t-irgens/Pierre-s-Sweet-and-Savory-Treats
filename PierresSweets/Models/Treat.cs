using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresSweets.Models
{
    public class Treat
    {
        public int TreatId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(60000)]
        public string Ingredients { get; set; }

        public int Rating { get; set; }

        public ICollection<FlavorTreat> Flavors { get; set; } // optional setter?
        public virtual ApplicationUser User { get; set; }

        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat>();
        }
    }
}