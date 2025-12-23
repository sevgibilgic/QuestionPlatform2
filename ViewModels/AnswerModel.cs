using System.ComponentModel.DataAnnotations;

namespace QuestionPlatform2.ViewModels
{
    public class AnswerModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [Display(Name = "Cevap Detayları")]
        [Required(ErrorMessage = "Cevap Detaylarını Giriniz!")]
        public string AnswerContent { get; set; }



        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;




        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}