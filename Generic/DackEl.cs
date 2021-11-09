using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class DackEl<T>
    {
        public T Value;
        public DackEl<T> Next, Previous;

        public DackEl(T value)
        { Value = value; }
    }
}
