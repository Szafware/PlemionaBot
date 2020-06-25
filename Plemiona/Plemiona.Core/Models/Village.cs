using System;
using System.Drawing;

namespace Plemiona.Core.Models
{
    [Serializable]
    public class Village
    {
        public string Name { get; set; }

        public Point Location { get; set; }

        public int Points { get; set; }

        public bool IsNomadOrBarbarian { get; set; }
    }
}