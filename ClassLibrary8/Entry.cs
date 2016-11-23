using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace ClassLibrary8
{
    public partial class Entry
    {
        private static void Main(string[] args)
        {
            ClassA.Run();
            ClassB.Run();
            ClassC.Run();
            ClassD.Run();
            ClassX.Run();
        }
    }
    
    public enum Service
    {
        Jet = 1,
        Amazon = 2
    }
}
