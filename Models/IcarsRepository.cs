using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2.Models
{
    // repository for mock cars data for unit testing

    public interface IcarsRepository
    {
        IQueryable<car> cars { get; }
        car save(car car);
        void Delete(car car);

    }
}
