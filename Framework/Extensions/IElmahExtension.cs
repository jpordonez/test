using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public interface IElmahExtension
    {
        void LogToElmah(System.Exception ex);
    }
}
