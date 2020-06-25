using System.Collections.Generic;
using System.Linq;

namespace Plemiona.Core.Models
{
    public class OwnPlayer
    {
        public string Name { get; set; }

        public int Points => Villages.Sum(v => v.Points);

        public List<OwnVillage> Villages { get; set; }

        public OwnPlayer()
        {
            Villages = new List<OwnVillage>();
        }
    }
}