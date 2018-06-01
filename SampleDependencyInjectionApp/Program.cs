using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDependencyInjectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueryable<Memos> memos = new List<Memos>()
            {
                new Memos { Title = "something1", dueAt = new DateTime(2007, 12, 24 ) },
                new Memos { Title = "something2", dueAt = new DateTime(2007, 2, 24 ) },
                new Memos { Title = "something3", dueAt = new DateTime(2007, 3, 24 ) }
            }.AsQueryable();

            var builder = new ContainerBuilder();
            builder.Register(c => new
                MemoChecker(c.Resolve<IQueryable<Memos>>(),
                        c.Resolve<IMemoDueNotifier>()));
            builder.Register(c => new
              PrintingNotifier(c.Resolve<TextWriter>())).As<IMemoDueNotifier>();
            builder.RegisterInstance(memos);
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();

            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }
        }
    }
}
