namespace SwiftBookingTest.Core.SwiftApi
{
    public interface ISwiftClient
    {
        string CreateDelivery(string dropOffAddress);
    }
}