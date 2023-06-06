using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleBookAPI.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public required string UserName { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public ICollection<User> Friends { get; set; } = new List<User>();

}
