using System.ComponentModel.DataAnnotations;

namespace PustokBookStore.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title1 { get; set; }
        [MaxLength(50)]
        public string Title2 { get; set; }
        [MaxLength(150)]
        public string Desc { get; set; }
        [MaxLength(50)]
        public string BtnText { get; set; }
        [MaxLength(150)]
        public string BtnUrl { get; set; }
        [Required]
        [MaxLength(150)]
        public string ImageName { get; set; }
        public int Order { get; set; }
    }
}
