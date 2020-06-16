using System.Collections.Generic;

namespace Plemiona.Core.Models
{
    public class Tribe
    {
        public string Name { get; set; }

        public List<Player> Members { get; set; }

        public List<Tribe> AlianceTribes { get; set; }

        public List<Tribe> EnemyTribes { get; set; }

        public List<Tribe> NonAggressionPactTribes { get; set; }


        public Tribe()
        {
            AlianceTribes = new List<Tribe>();
            EnemyTribes = new List<Tribe>();
            NonAggressionPactTribes = new List<Tribe>();
        }
    }
}