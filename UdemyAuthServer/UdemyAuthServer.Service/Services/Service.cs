using SharedLibrary.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Repositories;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Core.UnitOfWorks;

namespace UdemyAuthServer.Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class where TDto : class
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository , IUnitOfWork unitOfWork )
        {
            _repository = repository; 
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(entity);

            return Response<TDto>.Success(newDto,201);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var entityDtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>( await _repository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(entityDtos, 201);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return Response<TDto>.Fail($"Id si {id}  içersinde bulunamadı.{nameof(TEntity)}", 404,true);
            var entityDto = ObjectMapper.Mapper.Map<TDto>(entity);

            return Response<TDto>.Success(entityDto, 201);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {

            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return Response<NoDataDto>.Fail($"Id si {id}  içersinde bulunamadı.{nameof(entity)}", 404, true);

            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success( 201);

        }

        public async Task<Response<NoDataDto>> Update(TDto entityDto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return Response<NoDataDto>.Fail($"Id si {id}  içersinde bulunamadı.{nameof(entity)}", 404, true);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(201);
        }

        public Response<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
