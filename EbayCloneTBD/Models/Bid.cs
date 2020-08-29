namespace EbayCloneTBD.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public User User { get; set; }
    }
}