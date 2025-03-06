namespace Models
{
    public class Order
    {
        public int OrderId { get; set; } // Unikt ID for ordren
        public string CustomerName { get; set; } = string.Empty; // Kundens navn
        public string CustomerEmail { get; set; } = string.Empty; // Kundens e-mail
        public string CustomerPhone { get; set; } = string.Empty; // Kundens telefonnummer
        public string CustomerAddress { get; set; } = string.Empty; // Kundens adresse

        public int CompanyId { get; set; } // Hvilken virksomhed ordren tilhører
        
        public List<OrderItem> Items { get; set; } = new(); // Liste over produkter i ordren
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Dato for bestilling
    }
}
