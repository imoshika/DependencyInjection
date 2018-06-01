using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDependencyInjectionApp
{
    public interface IMemoDueNotifier
    {
        void MemoIsDue(Memos memo);
    }
}
