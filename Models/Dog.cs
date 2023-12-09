using System.ComponentModel.DataAnnotations;

namespace Dogs.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите название породы!")]
        [MaxLength(50)]
        [Display(Name ="Название породы")]
        
        public string Breed { get; set; }
        [Required(ErrorMessage = "Введите название породы по-английски!")]
        [MaxLength(50)]
        [Display(Name = "Название породы по-английски")]
        public string BreedInEnglish { get; set; }
        [Required(ErrorMessage = "Введите происхождение породы!")]
        [MaxLength(30)]
        [Display(Name = "Происхождение породы")]
        public string Origin { get; set;}
        
        [Required]
        [Display(Name = "Добавьте изображение")]
        [DataType(DataType.Upload)]
        public string ImageUrl { get; set; }
        [Display(Name = "Описание поведения и характера")]
        public string BehaviorCharacter { get; set; }
        [Display(Name = "История породы")]
        public string HistoryOfBreed { get; set; }

        [Display(Name = "Выберите группу FCI")]
        public int FCICategoryId { get; set; }
        
        public FCICategory FCICategory { get; set; }
        [Display(Name = "Выберите назначение")]
        public IEnumerable<DogTag> DogTags { get; set; }

    }
}
