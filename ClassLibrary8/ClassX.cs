using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8
{
    public static class ClassX
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Executor>();
            var container = builder.Build();
            var x = container.Resolve<Executor>();
            x.Do(Service.Jet, 55);
            x.Do(Service.Amazon, 55);
        }
        
        private class Executor
        {
            public void Do(Service service, int x)
            {
                string s;
                if (service == Service.Jet)
                {
                    s = GetAccordingToJetBehaviour(x) + "!" + this.GetType().Name;
                }
                else if (service == Service.Amazon)
                {
                    s = GetAccordingToAmazonBehaviour(x) + "!" + this.GetType().Name;
                }
                else
                {
                    throw new NotSupportedException();
                }
                Console.WriteLine(s);
            }

            private string GetAccordingToJetBehaviour(int x)
            {
                return x + " = " + nameof(Service.Jet);
            }

            private string GetAccordingToAmazonBehaviour(int x)
            {
                return x + " = " + nameof(Service.Amazon);
            }
        }
    }

}
