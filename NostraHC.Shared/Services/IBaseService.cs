using NostraHC.Shared.Dtos;

namespace Template.Shared.Services
{
    public interface IBaseService<TId, TEntityDto, TEntityResponseDto>
        where TId : struct
        where TEntityDto : class
        where TEntityResponseDto : BaseResponseDto<TId>
    {
        Task<List<TEntityResponseDto>> Get();
        Task<TEntityResponseDto> Get(TId id);
        Task<TEntityResponseDto> Add(TEntityDto entityDto);
        Task<TEntityResponseDto> Update(TId id, TEntityDto entityDto);
        Task Delete(TId id);
    }
}
