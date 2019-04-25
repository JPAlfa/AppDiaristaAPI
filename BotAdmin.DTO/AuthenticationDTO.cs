using System.ComponentModel.DataAnnotations;

namespace AppDiarista.DTO
{
    public class AuthenticationDTO
    {
        [Required]
        public string idAppDiarista { get; set; }
        [Required]
        public string grant_type { get; set; }
        public string refresh_token { get; set; }
    }
}
