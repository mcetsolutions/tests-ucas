using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mcet.Ucas.Event.Service.Query.Api
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            try
            {
                // Check performance ...
                Type interfaceType = typeof(IAutoMapperConfiguration);
                IEnumerable<Type> types =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .Where(a => a.FullName.StartsWith("Mcet.Ucas.Event.Service"))
                        .SelectMany(a => a.GetTypes())
                        .Where(t => t.IsClass && interfaceType.IsAssignableFrom(t));

                foreach (Type type in types)
                {
                    var autoMapperConfiguration = (IAutoMapperConfiguration)Activator.CreateInstance(type);
                    autoMapperConfiguration.Configure();
                }

                Mapper.AssertConfigurationIsValid();
            }
            catch (ReflectionTypeLoadException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Caught ReflectionTypeLoadException. Loader Exception(s) are as follows:");
                foreach (var exception in e.LoaderExceptions) sb.AppendLine(exception.ToString());
                throw new Exception(sb.ToString());
            }
        }
    }
}
