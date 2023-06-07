using System.ComponentModel.DataAnnotations;

namespace PeopleBookAPI.Models;

public class GroupForCreationDto
{
    [Required]
    [MinLength(5)]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(20)]
    [StringLength(200)]
    public string Description { get; set; }
}
