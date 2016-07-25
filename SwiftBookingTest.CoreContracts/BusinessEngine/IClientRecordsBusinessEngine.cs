

namespace SwiftBookingTest.CoreContracts.BusinessEngine
{
    public interface IClientRecordsBusinessEngine : IBusinessEngine
    {
        bool HasPhone(long? clientId);
    }
}
