using System.ComponentModel.DataAnnotations;


namespace MyWebSite.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заповніть назву статті")]
        [Display(Name = "Назва статті")]
        public override string Title { get; set; }
        [Display(Name = "Короткий опис статті")]
        public override string Subtitle { get; set; }
        [Display(Name = "Повна стаття")]
        public override string Text { get; set; }
    }
}
