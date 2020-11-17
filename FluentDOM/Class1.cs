using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDOM
{
    public class PropertyGetterSetterBuilder
    {
        public bool? IsDefault { get; set; }
        public PropertyGetterSetterBuilder Default()
        {
            IsDefault = true;
            return this;
        }
    }

    public class StatementsBuilder
    {

    }
}
