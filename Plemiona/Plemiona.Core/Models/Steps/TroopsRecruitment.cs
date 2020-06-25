using Plemiona.Core.Enums;

namespace Plemiona.Core.Models.Steps
{
    public class TroopsRecruitment
    {
        public TroopTypes TroopTypes { get; set; }

        public int Count { get; set; }

        public static TroopsRecruitment Create(TroopTypes troopType, int count) => new TroopsRecruitment { TroopTypes = troopType, Count = count };
    }
}