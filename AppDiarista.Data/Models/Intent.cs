using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDiarista.Data.Models
{
    [Table("Intent", Schema = "BOTDEV")]
    public partial class Intent
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
