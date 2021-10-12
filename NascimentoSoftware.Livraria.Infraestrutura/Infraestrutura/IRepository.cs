using System.Collections.Generic;

namespace NascimentoSoftware.Livraria.Infraestrutura.Infraestrutura
{
    public interface IRepository<T>
    {
        string GetConnection();
        int add(T objeto);
        int delete(int id);
        int update(T objeto);
        List<T> GetAll();
        T GetOne(int id);

    }
}
