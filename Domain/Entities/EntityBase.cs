using System;
using System.ComponentModel.DataAnnotations;


namespace MyWebSite.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow; // при створенні кожного об'єкта дата створення буде дорівнювати UtcNow

        [Required]
        public Guid Id { get; set; }
        [Display(Name = "Назва (заголовок)")]
        public virtual string Title { get; set; }
        [Display(Name = "Короткий опис")]
        public virtual string Subtitle { get; set; }
        [Display(Name = "Повний опис")]
        public virtual string Text { get; set; }
        [Display(Name = "Титульна картинка")]
        public virtual string TitleImagePath { get; set; }
        [Display(Name = "SEO мeтатег Title")]
        public  string MetaTitle { get; set; }
        [Display(Name = "SEO мeтатег Description")]
        public string MetaDescription { get; set; }
        [Display(Name = "SEO мeтатег Keywords")]
        public string MetaKeywords { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
