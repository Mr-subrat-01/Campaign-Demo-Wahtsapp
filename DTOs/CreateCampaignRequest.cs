namespace Campaign_Demo_Wahtsapp.DTOs
{
    public class CreateCampaignRequest
    {
        public string CampaignName { get; set; } = string.Empty;
        public long TemplateId { get; set; }
    }
}
