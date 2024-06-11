using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cartório21.Business.Validadores.Abstrações
{
    public interface IValidadorTitulo
    {
        Task<List<string>> Validar();
    }
}
