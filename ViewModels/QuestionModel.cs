using System.ComponentModel.DataAnnotations;

namespace QuestionPlatform2.ViewModels
{
    public class QuestionModel
    {
        public int Id { get; set; }




        [Display(Name = "Soru Başlığı")]
        [Required(ErrorMessage = "Soru Başlığı Giriniz!")]
        public string Title { get; set; }



        [Display(Name = "Soru Detayları")]
        [Required(ErrorMessage = "Soru Detaylarını Giriniz!")]
        public string Content { get; set; }




        [Display(Name = "Resim URL (Zorunlu değil.)")]
        public string? ImageUrl { get; set; }




        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;




        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;




        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();


    }
}