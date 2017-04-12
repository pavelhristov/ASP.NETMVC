using Ninject;
using SchoolSystem.Framework.Core;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            // please run each test on its own, IdGenerator screws them :/
            var kernel = new StandardKernel(new SchoolSystemModule());

            var engine = kernel.Get<Engine>();
            engine.Start();
        }
    }
}