using Plemiona.Core.Models;
using System;

namespace Plemiona.DestopApp.Models
{
    [Serializable]
    public class TroopsTemplate
    {
        public string Name { get; set; }

        public Troops Troops { get; set; }
    }
}