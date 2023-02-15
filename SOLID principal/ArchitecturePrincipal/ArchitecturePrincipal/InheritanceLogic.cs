using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePrincipal
{

    public class Parent
    {
        public virtual string GetName(object obj)
        {
            return "GetName";
        }
    }

    public class Child : Parent
    {
        public string GetChild(object obj)
        {
            return GetName(obj);
        }

        public static Child GetObject()
        {
            return new Child();
        }

    }

}
