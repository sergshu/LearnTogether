using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson7
{
    class TestEvent
    {
        private bool _cancel = false;

        public event EventHandler<int> NewSecond;

        internal void Start()
        {
            int second = 0;
            while (!_cancel)
            {
                second += 5;
                Thread.Sleep(1000);
                //NewSecond?.Invoke(this, ++second);
                NewSecond?.Invoke(this, second);
            }
        }

        internal void Stop()
        {
            _cancel = true;
        }
    }
}
