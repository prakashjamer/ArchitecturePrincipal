using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePrincipal
{
    interface IMath1 {
        void Add();
    }
    interface IMath2
    {
        void Add();
    }


    class MultipleInterface : IMath1, IMath2
    {
        string s1 = "abc";
        string s2 = "abc";
        void IMath1.Add()
        { 
        }
        void IMath2.Add()
        {
        }
    }
}
