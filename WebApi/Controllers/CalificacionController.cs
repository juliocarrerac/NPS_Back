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
    public class CalificacionController : Controller
    {
        private readonly ICalificacionApplication _calificacionApplication;

        public CalificacionController(ICalificacionApplication calificacionApplication)
        {
            _calificacionApplication = calificacionApplication;
        }

        //[AllowAnonymous]
        [HttpPost]
        public IActionResult RegistrarCalificacion(CalificacionDto objCalificacionDto)
        {
            var response = _calificacionApplication.RegistrarCalificacion(objCalificacionDto);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        //[AllowAnonymous]
        [HttpPost]
        public IActionResult ActualizarCalificacionPorUsuario(CalificacionDto objCalificacionDto)
        {
            var response = _calificacionApplication.ActualizarCalificacionPorUsuario(objCalificacionDto);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        //[AllowAnonymous]Microsoft.AspNetCore.Mvc.
        [HttpGet]
        public IActionResult ListarCalificaciones()
        {
            var response = _calificacionApplication.ListarCalificaciones();
            return Ok(response);
        }
    }
}
