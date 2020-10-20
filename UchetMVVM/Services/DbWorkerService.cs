using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace UchetMVVM.Services
{
    class DbWorkerService
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UchetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlConnection Connection { get; private set; }

        public DataSet Data { get; private set; }

        public DataView Workers => Data.Tables[0].DefaultView;

        public SqlDataAdapter WorkersAdapter { get; private set; }

        public DbWorkerService()
        {
            Connection = new SqlConnection(connectionString);
            Open();
            WorkersAdapter = new SqlDataAdapter("Select * from [Workers]", Connection);
            new SqlCommandBuilder(WorkersAdapter);
            Data = new DataSet("Data");
            WorkersAdapter.Fill(Data, "Workers");
            Close();
        }

        public void Update()
        {
            Open();
            WorkersAdapter.Update(Data.Tables[0]);
            Close();
        }

        public void Open() => Connection.Open();

        public void Close() => Connection.Close();
    }
}
