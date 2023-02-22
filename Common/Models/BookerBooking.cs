namespace Common.Models
{
    public class BookerBooking
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double TotalPrice { get; set; }
        public bool DepositPaid { get; set; }
        public BookingDates BookingDates { get; set; }
        public string AdditionalNeeds { get; set; }
    }
}