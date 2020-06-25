using System;

namespace Plemiona.Core.Models
{
    [Serializable]
    public class OwnVillage : Village
    {
        public Resources Resources { get; set; }

        public Buildings Buildings { get; set; }

        public Troops Troops { get; set; }

        public int CurrentPopulation { get; set; }

        public int MaxPopulation { get; set; }

        public int Backing { get; set; }
    }
}