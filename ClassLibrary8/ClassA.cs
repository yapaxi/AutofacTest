using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8
{
    public static class ClassA
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JetBehaviour>();
            builder.RegisterType<AmazonBehaviour>();
            builder.RegisterType<Executor<JetBehaviour>>();
            builder.RegisterType<Executor<AmazonBehaviour>>();
            var container = builder.Build();
            var x = container.Resolve<Executor<JetBehaviour>>();
            var y = container.Resolve<Executor<AmazonBehaviour>>();

            x.Do(55);
            y.Do(55);
        }
        
        private class Executor<TBehaviour>
            where TBehaviour : IBehaviour
        {
            private readonly IBehaviour _Behaviour;

            public Executor(TBehaviour Behaviour)
            {
                _Behaviour = Behaviour;
            }

            public void Do(int x)
            {
                var s = _Behaviour.Do(x) + "!" + this.GetType().Name;
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
