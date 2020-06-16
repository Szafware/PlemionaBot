using System;

namespace Plemiona.Core.Models
{
    public class IncomingAttack
    {
        public Village AttackingVillage { get; set; }

        public DateTime AttackArrivalDate { get; set; }
    }
}