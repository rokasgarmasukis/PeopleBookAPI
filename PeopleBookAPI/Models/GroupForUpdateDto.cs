using System.ComponentModel.DataAnnotations;

namespace PeopleBookAPI.Models;

public class GroupForUpdateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
}
