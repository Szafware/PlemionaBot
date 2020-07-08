using Plemiona.Core.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Plemiona.DestopApp.Models
{
    public class TroopsOrderRaport
    {
        public TroopsOrder TroopsOrder { get; set; }

        public Dictionary<Point, FeatureResults> AttackResults { get; set; }

        public TroopsOrderRaport()
        {
            AttackResults = new Dictionary<Point, FeatureResults>();
        }
    }
}