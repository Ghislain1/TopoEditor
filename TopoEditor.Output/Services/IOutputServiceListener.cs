using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Output.Services
{
    public interface IOutputServiceListener
    {
        object OrderBy(Func<object, object> p);
    }
}