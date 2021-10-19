using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
