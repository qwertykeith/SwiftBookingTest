namespace SwiftBookingTest.Web.Models
{
    /// <summary>
    /// This is a simple representation of the database entity.
    /// </summary>
    public class BookingDataModel
    {
        //Guid may be more appropriate here depending on volumes.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}