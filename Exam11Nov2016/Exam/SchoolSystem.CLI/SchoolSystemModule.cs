using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Ninject.Parameters;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });


            Bind<IReader>().To<ConsoleReaderProvider>();
            Bind<IWriter>().To<ConsoleWriterProvider>();
            Bind<IParser>().To<CommandParserProvider>().WithConstructorArgument("commandFactory", Kernel.Get<ICommandFactory>());


            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}