using SemestralniPrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralniPrace.Repository
{
    public interface IRepository<T>
    {
        List<T> GetList(BaseModel filter);

        T Get(int id);

        bool Save(T entity);

        bool Delete(int id);

        bool ImportCsv(string filePath);

        bool ExportCsv(string filePath, BaseModel filter);
    }
}
