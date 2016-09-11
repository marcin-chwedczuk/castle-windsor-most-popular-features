using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RegisterByConvention
{
    public class Foo
    {
        public long Id { get; private set; }

        public Foo(long id)
        {
            this.Id = id;
        }
    }

    public class FooRepository : IRepository<Foo>
    {
        public Foo Find(long id)
        {
            return new Foo(id);
        }
    }
}
