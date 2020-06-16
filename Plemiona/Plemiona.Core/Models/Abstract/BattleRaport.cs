namespace Plemiona.Core.Models.Abstract
{
    public abstract class BattleRaport
    {
        public Player AttackPlayer { get; set; }

        public Player DefendPlayer { get; set; }

        public Player BattleWinner { get; set; }

        public Troops AttackPlayerDiedTroops { get; set; }
        
        public Troops DefenderPlayerDiedTroops { get; set; }
    }
}