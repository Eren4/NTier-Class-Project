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
    public class AppUserManager(IAppUserRepository repository,IMapper mapper) : BaseManager<AppUserDto,AppUser>(repository,mapper), IAppUserManager
    {
        private readonly IAppUserRepository _repository = repository;  

        //public AppUserManager(IAppUserRepository repository) : base(repository)
        //{
        //    _repository = repository;

            

            
        //}
    }
}
