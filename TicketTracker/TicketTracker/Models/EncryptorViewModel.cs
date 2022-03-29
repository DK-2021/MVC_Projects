namespace TicketTracker.Models
{
    public class EncryptorViewModel
    {
        public int Shift { get; set; }
        public string StringToEncrypt { get; set; }

        public string EncryptedString { get; set; } 
    }
}
