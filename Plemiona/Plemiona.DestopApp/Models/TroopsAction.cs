using Plemiona.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plemiona.DestopApp.Models
{
    [Serializable]
    public class TroopsAction
    {
        public string Name { get; set; }

        public TroopsTemplate TroopsTemplate { get; set; }

        public List<Point> VillagesCoordinates { get; set; }

        public DateTime ExecutionDate { get; set; }

        public bool Everyday { get; set; }

        public TroopsAction()
        {
            VillagesCoordinates = new List<Point>();
        }
    }
}