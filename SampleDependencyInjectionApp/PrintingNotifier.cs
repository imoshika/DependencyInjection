using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDependencyInjectionApp
{
    class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;

        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }

        public void MemoIsDue(Memos memo)
        {
            _writer.WriteLine("Memo '{0}' is due", memo.Title);
        }
    }
}
