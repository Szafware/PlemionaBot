using System;
using System.Collections.Generic;

namespace Plemiona.DestopApp.Models
{
    [Serializable]
    public class PlemionaToolLocalData
    {
        public List<TroopsTemplate> TroopsTemplates { get; set; }

        public List<TroopsAction> TroopsActions { get; set; }

        public PlemionaToolLocalData()
        {
            TroopsTemplates = new List<TroopsTemplate>();
            TroopsActions = new List<TroopsAction>();
        }
    }
}