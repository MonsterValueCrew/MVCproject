using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Data.Models
{
    public class Image
    {
        //public Image(string name, byte[] imageInBase64, int order)
        //{
        //    Name = name;
        //    ImageInBase64 = imageInBase64;
        //    Order = order;
        //}

        public Image()
        {

        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] ImageInBase64 { get; set; }

        [Required]
        public int Order { get; set; }

        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }
    }
}
