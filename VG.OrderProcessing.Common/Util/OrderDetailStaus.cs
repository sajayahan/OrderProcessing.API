
namespace VG.OrderProcessing.Common
{
    /// <summary>
    /// Enum for Order detail status meta data
    /// </summary>
    public enum OrderDetailStausEnum
    {
        ACTIVE = 1,
        PENDING_CONFORMATION = 2,
        RETRY = 3,
        CONFIRMED = 4,
        CANCELLED = 5,
        REJECTED = 6,
        COMPLETED = 7
    }
}
