using System.ComponentModel.DataAnnotations;

namespace QuestionPlatform2.ViewModels
{
    public class AnswerModel
    {
        public int Id { get; set; }


        [Display(Name = "Soru Detayları")]
        [Required(ErrorMessage = "Soru Detaylarını Giriniz!")]
        public string AnswerContent { get; set; }



        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }




        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdatedAt { get; set; }

    }
}