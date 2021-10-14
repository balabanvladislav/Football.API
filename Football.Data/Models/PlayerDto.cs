using System.ComponentModel.DataAnnotations;

namespace FotbalAPI.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
    }
}
