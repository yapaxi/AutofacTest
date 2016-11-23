using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8
{
    public static class ClassC
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JetBehaviour>();
            builder.RegisterType<AmazonBehaviour>();
            builder.RegisterType<JetExecutor>();
            builder.RegisterType<AmazonExecutor>();
            var container = builder.Build();

            var x = container.Resolve<JetExecutor>();
            var y = container.Resolve<AmazonExecutor>();

            x.Do(55);
            y.Do(55);
        }

        private sealed class JetExecutor : Executor
        {
            public JetExecutor(JetBehaviour behaviour) : base(behaviour)
            {
            }
        }

        private sealed class AmazonExecutor : Executor
        {
            public AmazonExecutor(AmazonBehaviour behaviour) : base(behaviour)
            {
            }
        }

        private class Executor
        {
            private readonly IBehaviour _behaviour;

            public Executor(IBehaviour behaviour)
            {
                _behaviour = behaviour;
            }

            public void Do(int x)
            {
                var s = _behaviour.Do(x) + "!" + this.GetType().Name;
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
