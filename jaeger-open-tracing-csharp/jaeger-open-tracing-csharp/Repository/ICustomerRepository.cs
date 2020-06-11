using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaegerOpenTrace.Domain;

namespace JaegerOpenTrace.Repository
{
    public interface ICustomerRepository
    {
        public void Insert(Customer customer);
        IQueryable<Customer> Query();
    }
}
