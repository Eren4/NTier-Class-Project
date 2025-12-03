using Project.Entities.Enums;

namespace Project.WebApi.Models.ResponseModels.AppUsers
{
    public class AppUserResponseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DataStatus Status { get; set; }
    }
}
