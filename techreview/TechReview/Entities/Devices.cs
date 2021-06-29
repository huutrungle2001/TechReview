using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechReview.Entities
{
    public class Devices
    {
        [JsonPropertyName("id")]
        [Column("id", TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id must be not empty")]
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        [Column("Name", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name must be not empty")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [Column("Type", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Type must be not empty")]
        public string Type { get; set; }

        [JsonPropertyName("urlImage")]
        [Column("UrlImage", TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "UrlImage must be not empty")]
        public string UrlImage { get; set; }

        [JsonPropertyName("shortContent")]
        [Column("shortContent", TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "ShortContent must be not empty")]
        public string ShortContent { get; set; }

        [JsonPropertyName("content")]
        [Column("content", TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "content must be not empty")]
        public string Content { get; set; }

        [JsonPropertyName("outstanding")]
        [Column("outstanding", TypeName = "bit")]
        [Required(ErrorMessage = "outstanding must be not empty")]
        public bool Outstanding { get; set; }
    }
}
