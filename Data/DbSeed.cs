using Campaign_Demo_Wahtsapp.Models;

namespace Campaign_Demo_Wahtsapp.Data
{
    public static class DbSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            try
            {
                if (!context.Templates.Any())
                {
                    await context.Templates.AddAsync(new Template
                    {
                        Name = "offer",
                        Body = "Hello {{1}}, this offer is only for you hurry up...!"
                    });
                }

                if (!context.Contacts.Any())
                {
                    var contacts = new List<Contact>();
                    for (int i = 0; i < 10000; i++)
                    {
                        contacts.Add(new Contact
                        {
                            Name = $"User {i + 1}",
                            Phone = $"99999{i:D5}"
                        });
                    }
                    await context.AddRangeAsync(contacts);
                }


                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
