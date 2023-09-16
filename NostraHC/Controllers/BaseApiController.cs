using Microsoft.AspNetCore.Mvc;
using NostraHC.Shared.Domain;
using NostraHC.Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using Template.Shared.Services;

namespace NostraHC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TId, TEntity, TEntityDto, TEntityResponseDto> : ControllerBase
        where TId : struct
        where TEntity : Entity<TId, TEntity>
        where TEntityDto : class
        where TEntityResponseDto : BaseResponseDto<TId>
    {
        IBaseService<TId, TEntityDto, TEntityResponseDto> _service;

        public BaseApiController(IBaseService<TId, TEntityDto, TEntityResponseDto> service)
        {
            _service = service;
        }

        protected string GetUser()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var handler = new JwtSecurityTokenHandler();
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var User = tokenS?.Claims.First(claim => claim.Type == "unique_name").Value;
            return User;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get() =>
            Ok(await _service.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(TId id) =>
            Ok(await _service.Get(id));


        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityDto entityDto)
        {
            var response = await _service.Add(entityDto);

            if (!response.Errors.Any())
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] TId id, [FromBody] TEntityDto entityDto)
        {
            var response = await _service.Update(id, entityDto);

            if (!response.Errors.Any())
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(TId id)
        {
            await _service.Delete(id);
        }
    }
}
