using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IInformationRepository
    {
        IList<Information> GetData();
    }
}
