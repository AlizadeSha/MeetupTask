using Microsoft.EntityFrameworkCore;
using MeetupTask.Models.Speaker;

namespace MeetupTask.DAL
{
    public class SpeakerDB :DbContext
    {
        public SpeakerDB(DbContextOptions options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CA-R214-PC11\\SQLEXPRESS;Database=SpeakerDb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<MeetupTask.Models.Speaker.Speaker> Speaker { get; set; } = default!;
    }
}
