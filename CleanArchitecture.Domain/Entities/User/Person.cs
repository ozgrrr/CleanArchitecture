using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities.User
{
    public class Person : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MinLength(6)]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}
