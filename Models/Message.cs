namespace Campaign_Demo_Wahtsapp.Models
{
    public class Message
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long CampaignId { get; set; }
        public string Payload { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
