using System.ComponentModel.DataAnnotations;

namespace BLTS.WebApi.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}