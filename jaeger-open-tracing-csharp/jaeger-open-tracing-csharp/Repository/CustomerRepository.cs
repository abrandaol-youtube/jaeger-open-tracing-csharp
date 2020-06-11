using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaegerOpenTrace.Domain;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ILogger = DnsClient.Internal.ILogger;

namespace JaegerOpenTrace.Repository
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public void Insert(Customer customer)
        {
            try
            {
                var dbClient = new MongoClient("mongodb://127.0.0.1:27018");

                var dbCustomer = dbClient.GetDatabase("customer");

                var clCustomer = dbCustomer.GetCollection<Customer>("customer");

                clCustomer.InsertOne(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao tentar inserir", ex);
                throw;
            }
        }

        public IQueryable<Customer> Query()
        {
            try
            {
                var dbClient = new MongoClient("mongodb://127.0.0.1:27018");

                var dbCustomer = dbClient.GetDatabase("customer");

                var clCustomer = dbCustomer.GetCollection<Customer>("customer");

                return clCustomer.AsQueryable();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao tentar inserir", ex);
                throw;
            }
        }
    }
}
