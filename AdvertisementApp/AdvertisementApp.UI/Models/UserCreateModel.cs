using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Models
{
    public class UserCreateModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        //public SelectList GenderList { get; set; }
        public List<SelectListItem> GenderListItems { get; set; }
    }
}
