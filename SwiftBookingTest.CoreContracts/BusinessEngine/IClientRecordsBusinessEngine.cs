

namespace SwiftBookingTest.CoreContracts.BusinessEngine
{
    public interface IClientRecordsBusinessEngine : IBusinessEngine
    {
        bool IsClientHasPhone(long? clientId);
    }
}
