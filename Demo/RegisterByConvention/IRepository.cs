using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RegisterByConvention
{
    public interface IRepository<T>
    {
        T Find(long id);
    }
}
