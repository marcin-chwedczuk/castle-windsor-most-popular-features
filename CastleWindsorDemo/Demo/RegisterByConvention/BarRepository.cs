using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RegisterByConvention
{
    public class Bar
    {
        public long Id { get; private set; }

        public Bar(long id)
        {
            this.Id = id;
        }
    }

    public class BarRepository : IRepository<Bar>
    {
        public Bar Find(long id)
        {
            return new Bar(id);
        }
    }
}
