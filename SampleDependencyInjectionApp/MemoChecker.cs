using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDependencyInjectionApp
{
    public class MemoChecker 
    {
        IQueryable<Memos> memos;
        IMemoDueNotifier memoDue;
        DateTime date;

        public MemoChecker(IQueryable<Memos> _memos, IMemoDueNotifier _notifier)
        {
            memos = _memos;
            memoDue = _notifier;
        }


        public void CheckNow()
        {
            var overdue = memos.Where(m => m.dueAt < DateTime.Now);

            foreach(var _memos in overdue)
            {
                memoDue.MemoIsDue(_memos);
            }
        }

       


           
    }

}
