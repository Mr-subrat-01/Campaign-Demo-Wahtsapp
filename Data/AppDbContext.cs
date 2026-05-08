using Campaign_Demo_Wahtsapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Campaign_Demo_Wahtsapp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
