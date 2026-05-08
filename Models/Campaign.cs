namespace Campaign_Demo_Wahtsapp.Models
{
    public class Campaign
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long TemplateId { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
