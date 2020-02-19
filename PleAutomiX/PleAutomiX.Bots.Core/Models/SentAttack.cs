using System;

namespace PleAutomiX.Bots.Core.Models
{
    public class SentAttack
    {
        public Village TargetVillage { get; set; }

        public DateTime AttackArrivalDate { get; set; }

        public Troops Troops { get; set; }

        public bool IsCommingBack { get; set; }

        public Resources StolenResources { get; set; }
    }
}