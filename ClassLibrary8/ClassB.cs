using Autofac;
using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8
{
    public static class ClassB
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JetBehaviour>().Keyed<IBehaviour>(Service.Jet);
            builder.RegisterType<AmazonBehaviour>().Keyed<IBehaviour>(Service.Amazon);
            builder.RegisterType<Executor>();
            var container = builder.Build();
            var a = container.Resolve<Executor>();
            a.Do(Service.Jet, 55);
            a.Do(Service.Amazon, 55);
        }
        
        private class Executor
        {
            private readonly IIndex<Service, IBehaviour> _behaviourIndex;

            public Executor(IIndex<Service, IBehaviour> behaviourIndex)
            {
                _behaviourIndex = behaviourIndex;
            }

            public void Do(Service service, int x)
            {
                var s = _behaviourIndex[service].Do(x) + "!" + this.GetType().Name;
                Console.WriteLine(s);
            }
        }

        private interface IBehaviour
        {
            string Do(int i);
        }

        private class JetBehaviour : IBehaviour
        {
            public string Do(int i )
            {
                return i + " = " + nameof(JetBehaviour);
            }
        }

        private class AmazonBehaviour : IBehaviour
        {
            public string Do(int i)
            {
                return i + " = " + nameof(AmazonBehaviour);
            }
        }
    }

}
