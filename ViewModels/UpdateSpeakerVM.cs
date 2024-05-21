using System.ComponentModel.DataAnnotations;

namespace MeetupTask.ViewModels
{
    public class UpdateSpeakerVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string SosialUrl1 { get; set; }
        public string SosialUrl2 { get; set; }
        public string SosialUrl3 { get; set; }
    }
}
