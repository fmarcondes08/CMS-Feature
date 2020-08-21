using System.ComponentModel.DataAnnotations;

namespace FabricioAssignment.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}