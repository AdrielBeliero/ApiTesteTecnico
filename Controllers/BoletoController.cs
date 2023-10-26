using ApiTesteTecnico.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTesteTecnico.Controllers
{
    [ApiController]
    [Route("api/boletos")]
    public class BoletoController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoRepository _bancoRepository;
        private readonly AppDbContext _dbContext;

        public BoletoController(IMapper Mapper, IBoletoRepository boletoRepository, IBancoRepository bancoRepository, AppDbContext dbContext)
        {
            _Mapper = Mapper;
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoleto([FromBody] BoletoDTO boletoDTO)
        {
            if (boletoDTO == null)
            {
                return BadRequest("Dados Inválidos!");
            }

            var context = new ValidationContext(boletoDTO, null, null);

            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(boletoDTO, context, results, true))
            {
                return BadRequest(results);
            }

            var boleto = _Mapper.Map<Boleto>(boletoDTO);

            _boletoRepository.Add(boleto);
            await _boletoRepository.SaveChangesAsync();

            var boletoCreated = _Mapper.Map<BoletoDTO>(boleto);

            return CreatedAtAction("GetBoletoById", new { id = boleto.Id }, boletoCreated);
        }

        [HttpGet]
        public async Task<IActionResult> GetBoletos()
        {
            var dataAtual = DateTime.Now.Date;
            var boletosDTO = _Mapper.Map<List<BoletoDTO>>(await _boletoRepository.GetBoletos().ToListAsync());

            foreach (var boletoDTO in boletosDTO)
            {
                if (boletoDTO.DataVencimento.Date < dataAtual)
                {
                    var banco = _dbContext.Bancos.FirstOrDefault(b => b.Id == boletoDTO.IdBanco);

                    if (banco != null)
                    {
                        boletoDTO.Valor += (boletoDTO.Valor * banco.PercentualJuros) / 100;
                    }
                }
            }

            return Ok(boletosDTO);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetBoletosById(int Id)
        {
            var boleto = await _boletoRepository.GetBoletosById(Id).FirstOrDefaultAsync();

            if (boleto == null)
            {
                return NotFound();
            }

            var boletoDTO = _Mapper.Map<BoletoDTO>(boleto);
            return Ok(boletoDTO);

        }
    }
}
