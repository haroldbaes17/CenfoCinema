using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public override void Create(BaseDto baseDto)
        {

            throw new NotImplementedException();
        }

        public override void Update(BaseDto baseDto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDto baseDto)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
