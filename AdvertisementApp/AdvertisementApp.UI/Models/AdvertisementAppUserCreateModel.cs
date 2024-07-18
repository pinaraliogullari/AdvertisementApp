using AdvertisementApp.Shared.Enums;

namespace AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public AdvertisementAppUserCreateModel()
        {
            AdvertisementAppUserStatusId= (int)AdvertisementAppUserStatusType.Basvurdu; 
        }
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }  
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvPath { get; set; }
    }
}
