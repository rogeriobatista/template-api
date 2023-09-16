using FluentValidation.Results;

namespace NostraHC.Shared.Dtos
{
    public class BaseResponseDto<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
    }
}
