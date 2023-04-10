using System.ComponentModel.DataAnnotations;

namespace EFTutorial_20024.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        // navigation property
        public virtual List<Post> Posts { get; set; }
    }
}
