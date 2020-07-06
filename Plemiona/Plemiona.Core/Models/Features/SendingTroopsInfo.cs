namespace Plemiona.Core.Models.Features
{
    public class SendingTroopsInfo
    {
        public int CurrentOrderNumber { get; set; }
        
        public int OrderSequenceCount { get; set; }

        public bool IsLastOrderInSequence => CurrentOrderNumber == OrderSequenceCount;

        public static SendingTroopsInfo Create(int currentOrderNumber, int orderSequenceCount) => new SendingTroopsInfo { CurrentOrderNumber = currentOrderNumber, OrderSequenceCount = orderSequenceCount };
    }
}