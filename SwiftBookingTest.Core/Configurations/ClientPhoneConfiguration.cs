using SwiftBookingTest.Model;
using System.Data.Entity.ModelConfiguration;

namespace SwiftBookingTest.Core.Configurations
{
    /// <summary>
    /// Business rule class for phone number
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SwiftBookingTest.Model.ClientPhone}" />
    public class ClientPhoneConfiguration : EntityTypeConfiguration<ClientPhone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientPhoneConfiguration"/> class.
        /// </summary>
        public ClientPhoneConfiguration()
        {
            //Set rules for Num
            //this.Property(t => t.ClientRecordId)
            //    .IsRequired()
            //    .HasColumnAnnotation(
            //    IndexAnnotation.AnnotationName,
            //    new IndexAnnotation(
            //    new IndexAttribute("UQ_ClientPhone_ClientRecord", 1) { IsUnique = true }));

            //this.Property(t => t.PhoneNumberId)
            //    .IsRequired()
            //    .HasColumnAnnotation(
            //        IndexAnnotation.AnnotationName,
            //        new IndexAnnotation(
            //        new IndexAttribute("UQ_ClientPhone_PhoneNumber", 1) { IsUnique = true }));
           
        }
    }
}
