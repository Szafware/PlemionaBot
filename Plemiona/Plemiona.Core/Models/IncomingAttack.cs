using System;

namespace Plemiona.Core.Models
{
    [Serializable]
    public class IncomingAttack
    {
        public Village AttackingVillage { get; set; }

        public DateTime AttackArrivalDate { get; set; }
    }
}