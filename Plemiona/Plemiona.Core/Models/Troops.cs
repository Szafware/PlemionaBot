﻿using System;

namespace Plemiona.Core.Models
{
    [Serializable]
    public class Troops
    {
        public int Spearmen { get; set; }

        public int Swordmen { get; set; }

        public int Axemen { get; set; }

        public int Bowmen { get; set; }

        public int Scouts { get; set; }

        public int LightCavalary { get; set; }

        public int HorseArchers { get; set; }

        public int HeavyCavalary { get; set; }

        public int Rams { get; set; }

        public int Catapultes { get; set; }

        public int Knights { get; set; }

        public int Noblemen { get; set; }

        public int Peasants { get; set; }

        public bool AreUnsaddledTroopsPresent => (Spearmen > 0) || (Swordmen > 0) || (Axemen > 0) || (Bowmen > 0);

        public bool AreSaddledTroopsPresent => (Scouts > 0) || (LightCavalary > 0) || (HorseArchers > 0) || (HeavyCavalary > 0);

        public bool AreWarMachinesTroopsPresent => (Rams > 0) || (Catapultes > 0);

        public static Troops operator +(Troops orginalTroops, Troops addingTroops)
        {
            orginalTroops.Spearmen += addingTroops.Spearmen;
            orginalTroops.Swordmen += addingTroops.Swordmen;
            orginalTroops.Axemen += addingTroops.Axemen;
            orginalTroops.Bowmen += addingTroops.Bowmen;
            orginalTroops.Scouts += addingTroops.Scouts;
            orginalTroops.LightCavalary += addingTroops.LightCavalary;
            orginalTroops.HorseArchers += addingTroops.HorseArchers;
            orginalTroops.HeavyCavalary += addingTroops.HeavyCavalary;
            orginalTroops.Rams += addingTroops.Rams;
            orginalTroops.Catapultes += addingTroops.Catapultes;
            orginalTroops.Knights += addingTroops.Knights;
            orginalTroops.Noblemen += addingTroops.Noblemen;
            orginalTroops.Peasants += addingTroops.Peasants;

            return orginalTroops;
        }
    }
}