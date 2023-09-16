using AutoMapper;
using NostraHC.Shared.Domain;
using NostraHC.Shared.Repository;

namespace NostraHC.Shared.Services
{
    public abstract class BaseService<TId, TEntity, TEntityDto, TEntityResponseDto>
        where TId : struct
        where TEntity : Entity<TId, TEntity>
        where TEntityDto : class
        where TEntityResponseDto : class
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TId, TEntity> _repository;

        public BaseService(IMapper mapper, IBaseRepository<TId, TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<List<TEntityResponseDto>> Get()
        {
            return _mapper.Map<List<TEntityResponseDto>>(await _repository.ToListAsync());
        }

        public virtual async Task<TEntityResponseDto> Get(TId id)
        {
            return _mapper.Map<TEntityResponseDto>(await _repository.GetByIdAsync(id));
        }

        public virtual async Task<TEntityResponseDto> Add(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);

            if (entity.Validate())
                return _mapper.Map<TEntityResponseDto>(await _repository.AddAsync(entity));

            return _mapper.Map<TEntityResponseDto>(entity);
        }

        public virtual async Task<TEntityResponseDto> Update(TId id, TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);

            entity.WithId(id);

            if (entity.Validate())
            {
                _repository.Update(entity);
            }

            return _mapper.Map<TEntityResponseDto>(entity);
        }

        public virtual async Task Delete(TId id)
        {
            var role = await _repository.GetByIdAsync(id);

            _repository.Remove(role);
        }
    }
}
