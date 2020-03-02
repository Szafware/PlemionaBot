using PleAutomiX.Bots.Core.Enums;
using System;

namespace PleAutomiX.Bots.Steps.Models.Gui
{
    public class TownhallBuildingBuildQueueRow
    {
        public BuildingTypes Building { get; set; }

        public int QueuePosition { get; set; }

        public int FromLevel { get; set; }

        public int ToLevel { get; set; }

        public DateTime FinishDate { get; set; }

        public bool FreeSkip { get; set; }
    }
}