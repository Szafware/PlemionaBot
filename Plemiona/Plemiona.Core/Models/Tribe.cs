using System;
using System.Collections.Generic;
using System.Linq;

namespace Plemiona.Core.Models
{
    [Serializable]
    public class Tribe
    {
        public string Name { get; set; }

        public List<Player> Members { get; set; }

        public List<Tribe> AlianceTribes { get; set; }

        public List<Tribe> EnemyTribes { get; set; }

        public List<Tribe> NonAggressionPactTribes { get; set; }

        public int Points => Members.Sum(m => m.Points);

        public Tribe()
        {
            AlianceTribes = new List<Tribe>();
            EnemyTribes = new List<Tribe>();
            NonAggressionPactTribes = new List<Tribe>();
        }
    }
}