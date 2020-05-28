using System.ComponentModel.DataAnnotations;

namespace BLTS.Web.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}