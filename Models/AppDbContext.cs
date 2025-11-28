using Microsoft.EntityFrameworkCore;

namespace QuestionPlatform2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}