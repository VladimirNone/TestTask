using System.ComponentModel.DataAnnotations;

namespace ForInterview.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}