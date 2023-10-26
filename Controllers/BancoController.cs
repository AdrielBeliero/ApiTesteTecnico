using ApiTesteTecnico.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTesteTecnico.Controllers
{
    [ApiController]
    [Route("api/bancos")]
    public class BancoController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IBancoRepository _bancoRepository;

        public BancoController(IMapper Mapper, IBancoRepository bancoRepository)
        {
            _Mapper = Mapper;
            _bancoRepository = bancoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanco([FromBody] BancoDTO bancoDTO)
        {
            if (bancoDTO == null)
            {
                return BadRequest("Dados Inválidos!");
            }

            var context = new ValidationContext(bancoDTO, null, null);

            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(bancoDTO, context, results, true))
            {
                return BadRequest(results);
            }

            var banco = _Mapper.Map<Banco>(bancoDTO);

            _bancoRepository.Add(banco);
            await _bancoRepository.SaveChangesAsync();

            var bancoCreated = _Mapper.Map<BancoDTO>(banco);

            return CreatedAtAction("GetBancoById", new { id = banco.Id }, bancoCreated);
        }

        [HttpGet]
        public async Task<IActionResult> GetBancos()
        {
            var bancosDTO = _Mapper.Map<List<BancoDTO>>(await _bancoRepository.GetBancos().ToListAsync());

            return Ok(bancosDTO);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetBancoByID(int Id)
        {
            var banco = await _bancoRepository.GetBancoById(Id).FirstOrDefaultAsync();

            if (banco == null)
            {
                return NotFound();
            }

            var bancoDTO = _Mapper.Map<BancoDTO>(banco);
            return Ok(bancoDTO);

        }
    }
}
