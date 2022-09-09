using Empresa.Aplicacion.Application.DTO;
using Empresa.Aplicacion.Application.Interface;
using Empresa.Aplicacion.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [EnableCors("policyApiEcommerce")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly AppSettings _appSettings;

        public UsuarioController(IUsuarioApplication usuarioApplication, IOptions<AppSettings> appSettings)
        {
            _usuarioApplication = usuarioApplication;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ValidarUsuario(UsuarioDto objUsuarioDto)
        {
            var response = _usuarioApplication.ValidarUsuario(objUsuarioDto);
            if(response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    response.Token = response.Data.Token;
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        private string BuildToken(ResponseBase<UsuarioDto> objUsuarioDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, objUsuarioDto.Data.Usuario_Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
