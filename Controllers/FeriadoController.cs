using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly IFeriadosRepositorio _feriadoRepositorio;

        public FeriadoController(IFeriadosRepositorio feriadoRepositorio)
        {
            _feriadoRepositorio = feriadoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FeriadoModel>>> BuscarTodosFeriados()
        {
            List<FeriadoModel> feriados = await _feriadoRepositorio.BuscarTodosFeriados();
            return Ok(feriados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeriadoModel>> BuscarPorId(int id)
        {
            FeriadoModel feriado = await _feriadoRepositorio.BuscarPorId(id);
            return Ok(feriado);
        }

        [HttpPost]
        public async Task<ActionResult<FeriadoModel>> Cadastrar([FromBody] FeriadoModel feriado)
        {
            var retorno = await _feriadoRepositorio.Adicionar(feriado);
            return Ok(retorno);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<FeriadoModel>> Deletar(int id)
        {
            bool validacao = await _feriadoRepositorio.Apagar(id);
            return Ok(validacao);   
        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult<FeriadoModel>> Atualizar([FromBody] FeriadoModel feriado, int id)
        {
            feriado.idFeriado = id;
            FeriadoModel update = await _feriadoRepositorio.Atualizar(feriado, id);
            return Ok(update);
        }
    }

    
}
