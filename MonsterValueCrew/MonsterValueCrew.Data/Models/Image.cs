using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] ImageInBase64 { get; set; }
        
        public int Order { get; set; }

        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }
    }
}
