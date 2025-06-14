using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;
using DTOs;

namespace DataAccess.CRUD
{
    //Clase padre abstracta de los CRUDs
    //Define como se hacen los CRUDs en la arquitectura 

    public abstract class CrudFactory
    {
        protected SqlDao _sqlDao;

        //Definir los metodos que forman parte del contrato
        //C = Create
        //R = Retrieve
        //U = Update
        //D = Delete

        public abstract void Create(BaseDto baseDto);
        public abstract void Update(BaseDto baseDto);
        public abstract void Delete(BaseDto baseDto);

        public abstract T Retrieve<T>();
        public abstract T RetrieveById<T>(int Id);
        public abstract List<T> RetrieveAll<T>();



    }
}
