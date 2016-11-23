using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary8
{
    public static class ClassD
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
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
            protected override string Behave(int x)
            {
                return x + " = " + nameof(JetExecutor);
            }
        }

        private sealed class AmazonExecutor : Executor
        {
            protected override string Behave(int x)
            {
                return x + " = " + nameof(AmazonExecutor);
            }
        }

        private abstract class Executor
        {
            public void Do(int x)
            {
                var s = Behave(x) + "!" + this.GetType().Name;
                Console.WriteLine(s);
            }

            protected abstract string Behave(int x);
        }
    }

}
