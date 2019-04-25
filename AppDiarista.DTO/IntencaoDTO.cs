using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiarista.DTO
{
    public class IntencaoDTO
    {
        public int IntentId { get; set; }
        public Guid BotId { get; set; }
        public int? IntentAnswerTypeId { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? FatherIntentId { get; set; }
        public bool? Authenticated { get; set; }
        [StringLength(200)]
        public string AmbiguousText { get; set; }
        public string DefaultAnswer { get; set; }
        public bool? RedirectToAttendant { get; set; }
        public Guid? IntentIdLuis { get; set; }
    }
}
