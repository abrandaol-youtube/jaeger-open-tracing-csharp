using Domain;
using JaegerOpenTrace.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class InformationRepository : IInformationRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        public InformationRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public IList<Information> GetData()
        {
            try
            {
                var informations = new List<Information>();

                using var conn = new SqlConnection("server=devstation01;database=testdb;user=sa;password=Sistema1");

                using var cmd = new SqlCommand("select * from testtbl", conn);

                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var info = reader.GetString(1);

                    informations.Add(new Information { Id = id, Info = info });
                }

                return informations;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
