using JaegerOpenTrace.Domain;
using OpenTracing.Util;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OpenTracing.Propagation;
using OpenTracing;

namespace Core
{
    public class CustomerValidation
    {
        public bool Validate(Customer customer, ITracer tracer)
        {
            using var scope = tracer.BuildSpan("CustomerValidation").StartActive(true);

            System.Threading.Thread.Sleep(1000);
            if (customer != null)
            {

                using var scopeA = tracer.BuildSpan("Customer.Document Validation").StartActive(true);

                scopeA.Span.SetTag("customer.document", customer.Document);

                Task.Delay(250);
                if (customer.Document != null)
                {

                    using var scopeB = tracer.BuildSpan("Customer.Name Validation").StartActive(true);

                    Task.Run(() => System.Threading.Thread.Sleep(300)).Wait();
                    if (!string.IsNullOrEmpty(customer.Name))
                    {
                        scopeB.Span.Finish();

                        Task.Run(() => System.Threading.Thread.Sleep(20)).Wait();

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
