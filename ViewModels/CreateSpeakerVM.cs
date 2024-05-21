using System.ComponentModel.DataAnnotations;

namespace MeetupTask.ViewModels
{
    public class CreateSpeakerVM
    {
        [MaxLength(15),Required]
        public string Name { get; set; }
        [MaxLength(30),Required]
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public string SosialUrl1 { get; set; }
        public string SosialUrl2 { get; set; }
        public string SosialUrl3 { get; set; }
    }
}
