using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.StoreLayer
{
    public interface Store
    {
        List<Models.Product> GetAll();

        Models.Product GetById(int id);

        void Create(Models.Product product);

        void Update(Models.Product product);

        void Delete(Models.Product product);

        void Close();
    }
}
