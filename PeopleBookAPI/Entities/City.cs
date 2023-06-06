using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleBookAPI.Entities;

public class City
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public ICollection<User> People { get; set; } = new List<User>();

    public City(string name)
    {
        Name = name;
    }
}
