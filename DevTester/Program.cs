using DataAccess.DAO;

public class Program
{
    public static void Main(string[] args)
    {
        /*
        // SP de Crear Usuario

        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "hbarrantes");
        sqlOperation.AddStringParameter("P_Name", "Harold");
        sqlOperation.AddStringParameter("P_Email", "hbarrantese@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Cenfotec123!");
        sqlOperation.AddDateTimeParam("P_BirthDate", new DateTime(2005, 12, 17));
        sqlOperation.AddStringParameter("P_Status", "A");

        var sqlDao = SqlDao.GetInstance();
        
        sqlDao.ExecuteProcedure(sqlOperation);
        */

        // SP de Actualizar Usuario
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "UPD_USER_PR";

        sqlOperation.AddIntParam("P_Id", 1);
        sqlOperation.AddStringParameter("P_UserCode", "hbarrantes");
        sqlOperation.AddStringParameter("P_Name", "Harold Barrantes");
        sqlOperation.AddStringParameter("P_Email", "hbarrantese@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Cenfotec123!");
        sqlOperation.AddDateTimeParam("P_BirthDate", new DateTime(2005, 12, 17));
        sqlOperation.AddStringParameter("P_Status", "Activo");

        var sqlDao = SqlDao.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);





    }
}