using Microsoft.EntityFrameworkCore;

namespace QuestionPlatform2.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
            new Question() { Id = 1, Title = "Soru Başlığı 1", Content = "İçerik 1", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Question() { Id = 2, Title = "Soru Başlığı 2", Content = "İçerik 2", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Question() { Id = 3, Title = "Soru Başlığı 3", Content = "İçerik 3", IsActive = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
        }
    }
}