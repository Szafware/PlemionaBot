using System.Collections.Generic;
using System.Linq;

namespace Plemiona.Core.Models
{
    public class Player
    {
        public string Name { get; set; }

        public int Points => Villages.Sum(v => v.Points);

        public List<Village> Villages { get; set; }

        public Player()
        {
            Villages = new List<Village>();
        }
    }
}