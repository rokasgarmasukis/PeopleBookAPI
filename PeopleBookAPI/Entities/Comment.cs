using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleBookAPI.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Content { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    [ForeignKey("PostId")]
    public required Post Post { get; set; }
    public int PostId { get; set; }

    public Comment(int id, string content)
    {
        Id = id;
        Content = content;
    }
}
