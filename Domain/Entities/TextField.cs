using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }
        [Display(Name = "Назва сторінки (заголовок)")]
        public override string Title { get; set; } = "Інформаційна сторінка";
        [Display(Name = "Вміст сторінки")]
        public override string Text { get; set; } = "Вміст заповнюється адміністратором";
    }
}
