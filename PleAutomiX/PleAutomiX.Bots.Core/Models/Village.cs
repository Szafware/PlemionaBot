using System.Drawing;

namespace PleAutomiX.Bots.Core.Models
{
    public class Village
    {
        public string Name { get; set; }

        public Point Location { get; set; }

        public int Points { get; set; }

        public Resources Resources { get; set; } 

        public Buildings Buildings { get; set; }

        public Troops Troops { get; set; }
        
        public int CurrentPopulation { get; set; }

        public int MaxPopulation { get; set; }

        public int Backing { get; set; }

        public bool IsBarbarian { get; set; }
    }
}