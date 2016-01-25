using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwiftBookingTest.Web.Models
{
    /// <summary>
    /// This is a view based model of a Booking, contains extra params for display convinience
    /// </summary>
    public class BookingViewModel
    {
        //Guid may be more appropriate here depending on volumes.
        public int Id { get; set; }
        [Required]
        [DisplayName("Contact Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Contact Phone")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Delivery Address")]
        public string Address { get; set; }

        public static BookingViewModel FromDb(BookingDataModel bookingDataModel)
        {
            return new BookingViewModel
            {
                Id = bookingDataModel.Id,
                Name = bookingDataModel.Name,
                Address = bookingDataModel.Address,
                Phone = bookingDataModel.Phone
            };
        }
    }
}