using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresSweets.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<FlavorTreat> Treats { get; }
        public virtual ApplicationUser User { get; set; }

        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }
    }
}