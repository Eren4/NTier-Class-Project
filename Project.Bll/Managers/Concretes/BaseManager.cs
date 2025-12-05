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
    public abstract class BaseManager<T,U> : IManager<T,U> where T : class,IDto where U : BaseEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Delegates for error handling
        protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                throw new Exception($"Manager error: {ex.Message}", ex);
            }
        }

        protected async Task ExecuteSafeAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                throw new Exception($"Manager error: {ex.Message}", ex);
            }
        }

        protected T ExecuteSafe<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing operation.", ex);
            }
        }

        public async Task CreateAsync(T entity)
        {
            await ExecuteSafeAsync(async () =>
            {
                U domainEntity = _mapper.Map<U>(entity);

                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Entities.Enums.DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            });
        }

        public List<T> GetActives()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                List<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U value = await _repository.GetByIdAsync(id);
                return _mapper.Map<T>(value);
            });
        }

        public  List<T> GetPassives()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status == Entities.Enums.DataStatus.Deleted).ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public List<T> GetUpdateds()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status == Entities.Enums.DataStatus.Updated).ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null || originalValue.Status != Entities.Enums.DataStatus.Deleted)
                    return "Sadece bulunabilen ve pasif veriler silinebilir";

                await _repository.DeleteAsync(originalValue);

                return $"{id} id'li veri silinmiştir";
            });
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null || originalValue.Status == Entities.Enums.DataStatus.Deleted)
                    return "Veri ya zaten pasif ya da bulunamadı";

                originalValue.Status = Entities.Enums.DataStatus.Deleted;
                originalValue.DeletedDate = DateTime.Now;

                await _repository.SaveChangesAsync();

                return $"{id} id'li veri pasife cekilmiştir";
            });
        }

        public async Task UpdateAsync(T entity)
        {
            await ExecuteSafeAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);

                U newValue = _mapper.Map<U>(entity);
                newValue.UpdatedDate = DateTime.Now;
                newValue.Status = Entities.Enums.DataStatus.Updated;

                await _repository.UpdateAsync(originalValue, newValue);
            });
        }
    }
}
