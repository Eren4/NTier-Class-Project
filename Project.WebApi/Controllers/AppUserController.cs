using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.WebApi.Models.RequestModels.AppUsers;
using Project.WebApi.Models.ResponseModels.AppUsers;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUsersList()
        {
            List<AppUserDto> values = await _appUserManager.GetAllAsync();
            List<AppUserResponseModel> responseModel = _mapper.Map<List<AppUserResponseModel>>(values);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(appUser);
            return Ok("Veri ekleme basarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(appUser);
            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUser(int id)
        {
            string mesaj = await _appUserManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            string mesaj = await _appUserManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
