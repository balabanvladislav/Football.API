using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Entities
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
