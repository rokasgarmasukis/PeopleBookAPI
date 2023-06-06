using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleBookAPI.Entities;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [Required]
    [StringLength(300)]
    public string Body { get; set; }

    public User Author { get; set; }
    public int AuthorId { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;
}
