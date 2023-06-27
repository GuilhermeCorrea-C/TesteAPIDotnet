using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class FeriadoRepositorio : IFeriadosRepositorio
    {
        private readonly SistemaFeriadosDBContext _dbContext;

        public FeriadoRepositorio(SistemaFeriadosDBContext sistemaFeriadosDBContext)
        {
            _dbContext = sistemaFeriadosDBContext;
        }

        public async Task<FeriadoModel> BuscarPorId(int identi)
        {
            return await _dbContext.Feriados.FirstOrDefaultAsync(x => x.idFeriado ==  identi);
        }

        public async Task<List<FeriadoModel>> BuscarTodosFeriados()
        {
            return await _dbContext.Feriados.ToListAsync();
        }

        public async Task<FeriadoModel> Adicionar(FeriadoModel feriado)
        {
            await _dbContext.Feriados.AddAsync(feriado);
            await _dbContext.SaveChangesAsync(); 

            return feriado;
        }

        public async Task<FeriadoModel> Atualizar(FeriadoModel feriado, int id)
        {
            var feriadoPorId = await BuscarPorId(id); 

            if (feriadoPorId == null)
            {
                throw new Exception($"Feriado para o Id: {id} não encontrado!");
            }
            feriadoPorId.idFeriado = feriado.idFeriado;
            feriadoPorId.nomeFeriado = feriado.nomeFeriado;
            feriadoPorId.dataFeriado = feriado.dataFeriado;

            _dbContext.Feriados.Update(feriadoPorId); 
            await _dbContext.SaveChangesAsync();

            return feriadoPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            var feriadoPorId = await BuscarPorId(id);

            if (feriadoPorId == null)
            {
                throw new Exception($"Feriado para o Id {id} não encontrado!");
            }

            _dbContext.Feriados.Remove(feriadoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }



    }
}
