using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcs
{
    class TaskQueue
    {
        public void StartNewTask(Action action)
        {
            if (_task == null)
            {
                _task = Task.Factory.StartNew(action);
            }

            else
            {
                _task = _task.ContinueWith((prevTask) => action(), TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        public void Wait()
        {
            if (_task != null)
            {
                _task.Wait();
            }
        }

        public static object syncRoot = new object();

        //public T StartNewGenericTask<T>(Func<T> func)
        //{
        //    Task<T> t;
        //    if (_task == null)
        //    {
        //        t = Task.Factory.StartNew<T>(func);
        //    }

        //    else
        //    {
        //        t = _task.ContinueWith<T>((prevTask) => func());
        //    }

        //    _task = t;
        //    return t.Result;
        //}

        private Task _task;
    }
}
