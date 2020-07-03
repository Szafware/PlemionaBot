namespace Plemiona.Core.Models.Features
{
    public class SendingTroopsInfo
    {
        public int CurrentActionNumber { get; set; }
        
        public int ActionsSequenceCount { get; set; }

        public bool IsLastActionInSequence => CurrentActionNumber == ActionsSequenceCount;

        public static SendingTroopsInfo Create(int currentActionNumber, int actionsSequenceCount) => new SendingTroopsInfo { CurrentActionNumber = currentActionNumber, ActionsSequenceCount = actionsSequenceCount };
    }
}