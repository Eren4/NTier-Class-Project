using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.WebApi.Models.RequestModels.AppUserProfiles;
using Project.WebApi.Models.RequestModels.AppUsers;
using Project.WebApi.Models.RequestModels.Categories;
using Project.WebApi.Models.ResponseModels.AppUserProfiles;
using Project.WebApi.Models.ResponseModels.AppUsers;
using Project.WebApi.Models.ResponseModels.Categories;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;

        public AppUserProfileController(IAppUserProfileManager appUserProfileManager, IMapper mapper)
        {
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfilesList()
        {
            List<AppUserProfileDto> values = await _appUserProfileManager.GetAllAsync();
            List<AppUserProfileResponseModel> responseModel = _mapper.Map<List<AppUserProfileResponseModel>>(values);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfile(int id)
        {
            AppUserProfileDto value = await _appUserProfileManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserProfileResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.CreateAsync(appUserProfile);
            return Ok("Veri ekleme basarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.UpdateAsync(appUserProfile);
            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUserProfile(int id)
        {
            string mesaj = await _appUserProfileManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            string mesaj = await _appUserProfileManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
