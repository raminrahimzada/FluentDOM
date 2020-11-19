using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDOM
{
    public class PropertyGetterSetterModel
    {
        public bool? IsDefault { get; set; }
        public PropertyGetterSetterModel Default()
        {
            IsDefault = true;
            return this;
        }
    }
}
