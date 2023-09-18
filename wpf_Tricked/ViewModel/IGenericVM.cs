using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_Tricked.ViewModel
{
    public interface IGenericVM<T> where T : class
    {
        void Update();
        void Remove();
        void Add();
    }
}
