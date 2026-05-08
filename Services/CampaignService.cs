using Campaign_Demo_Wahtsapp.Data;
using Campaign_Demo_Wahtsapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Campaign_Demo_Wahtsapp.Services
{
    public class CampaignService(AppDbContext context)
    {
        public async Task CreateCampaignAsync(string campaignName, long templateId)
        {
            var template = await context.Templates.FirstOrDefaultAsync(x=>x.Id == templateId);
            if (template == null)
            {
                throw new Exception("Template not found");
            }
            var campaign = new Campaign
            {
                 Name = campaignName,
                 TemplateId = templateId,
                 Status = "Processing",
                 CreatedAt = DateTime.UtcNow,
            };
            context.Campaigns.Add(campaign);
            await context.SaveChangesAsync();

            var contacts = await context.Contacts.ToListAsync();
            var messages = new List<Message>();
            foreach (var contact in contacts) {
                string message = template.Body.Replace("{{1}}", contact.Name);
                messages.Add(new Message
                {
                    CampaignId = campaign.Id,
                    ContactId = contact.Id,
                    Payload = message,
                    CreatedAt = DateTime.UtcNow,
                    Status = "Pending"
                });
            }
            await context.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }
    }
}
