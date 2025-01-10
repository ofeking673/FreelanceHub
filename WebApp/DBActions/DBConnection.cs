using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SQLite;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;

namespace WebApplication2.DBActions
{
    public class DBConnection : IDBConnection
    {
        private SQLiteConnection conn;
        SQLiteCommand cmd = new SQLiteCommand();
        private string connectionStr { get; set; }
        private SQLiteTransaction transaction;

        static object obj = new object();
        static DBConnection db;

        public static DBConnection getInstance()
        {
            if(db == null)
            {
                db = new DBConnection();
            }
            return db;
        }
        private DBConnection()
        {
            connectionStr = "Data Source=C:\\Users\\Magshimim\\FreelanceHub\\WebApp\\App_Data\\test.sqlite";
            conn = new SQLiteConnection(connectionStr);
            cmd.Connection = conn;
        }

        public void openConnection()
        {
            conn.Open();
        }

        public void closeConnection() 
        {
            conn.Close();
            if (transaction != null) { transaction.Dispose(); }
        }

        public void beginTransaction()
        {
            transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;
        }

        public void commitTransaction()
        {
            transaction.Commit();
        }

        public void rollbackTransaction()
        {
            transaction.Rollback();
        }

        public int create(string sql)
        {
            return ChangeDb(sql);
        }

        public int update(string sql)
        {
            return ChangeDb(sql);
        }

        public int delete(string sql)
        {
            return ChangeDb(sql);
        }

        public IDataReader Read(string q)
        {
            IDataReader reader;
            cmd.CommandText = q;
            reader = cmd.ExecuteReader();
            return reader;
        }
        
        public object ReadValue(string sql)
        {
            cmd.CommandText = sql;
            return cmd.ExecuteScalar();
        }

        private int ChangeDb(string sql)
        {
            cmd.CommandText = sql;
            int rows = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return rows;
        }

        public void addParameter(string name, string value)
        {
            cmd.Parameters.Add(new SQLiteParameter(name, value));
        }

        public void clearParams()
        {
            cmd.Parameters.Clear();
        }

        public string GetLastId()
        {
            string sql = "SELECT @@ID";
            return ReadValue(sql).ToString();
        }

    }
}
