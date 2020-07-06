using Plemiona.Core.Models;
using System;
using System.Collections.Generic;

namespace Plemiona.DestopApp.Models
{
    [Serializable]
    public class PlemionaToolLocalData
    {
        public List<TroopsTemplate> TroopsTemplates { get; set; }

        public List<TroopsOrder> TroopsOrders { get; set; }

        public List<Village> TargetVillages { get; set; }

        public PlemionaToolLocalData()
        {
            TroopsTemplates = new List<TroopsTemplate>();
            TroopsOrders = new List<TroopsOrder>();
        }
    }
}