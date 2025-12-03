using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class AppUserProfileManager(IAppUserProfileRepository repository,IMapper mapper) : BaseManager<AppUserProfileDto, AppUserProfile>(repository,mapper),IAppUserProfileManager
    {
        private readonly IAppUserProfileRepository _repository = repository;
    }
}
