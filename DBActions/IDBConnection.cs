using System.Data;
using System.Data.SQLite;

namespace WebApplication2.DBActions
{
    public interface IDBConnection
    {
        IDataReader Read(string sql);
        object ReadValue(string sql);
        int create(string sql);
        int update(string sql);
        int delete(string sql);
        void openConnection();
        void closeConnection();
        void beginTransaction();
        void commitTransaction();
        void rollbackTransaction();
        
    }
}
