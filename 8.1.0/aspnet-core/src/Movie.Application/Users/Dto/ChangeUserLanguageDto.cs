using System.ComponentModel.DataAnnotations;

namespace Movie.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}