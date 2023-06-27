using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
    public interface IFeriadosRepositorio
    {
        Task<List<FeriadoModel>> BuscarTodosFeriados();

        Task<FeriadoModel> BuscarPorId(int id);

        Task<FeriadoModel> Adicionar(FeriadoModel feriado);

        Task<FeriadoModel> Atualizar(FeriadoModel feriado, int id);

        Task<bool> Apagar(int id);
    }
}
