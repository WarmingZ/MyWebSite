using System.ComponentModel.DataAnnotations;


namespace MyWebSite.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заповніть назву статьї")]
        [Display(Name = "Назва статьї")]
        public override string Title { get; set; }
        [Display(Name = "Короткий опис статьї")]
        public override string Subtitle { get; set; }
        [Display(Name = "Повна статья")]
        public override string Text { get; set; }
    }
}
