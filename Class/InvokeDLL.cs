#define newDomain

using System;
using System.IO;
using System.Reflection;
using System.Security.Policy;

namespace BelSoft
{
    public class InvokeDLL
    {
        private AppDomain domain = null;
        private Proxy value;

        public InvokeDLL()
        {
#if newDomain
            CreateAppDomain();
#endif
        }

        public void Run(string DLLPath, string method, params object[] parameters)
        {
            try
            {
#if newDomain
                value.Run(DLLPath, method, parameters);
#else
                //Also works without creating any new app domain:
                Proxy p = new Proxy();
                p.Run(DLLPath, method, parameters);
#endif
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CreateAppDomain()
        {
            AppDomainSetup domInfo = new AppDomainSetup();
            domInfo.ApplicationBase = System.Environment.CurrentDirectory;
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;
            domain = AppDomain.CreateDomain("MyDomain", adevidence, domInfo);

            Type type = typeof(Proxy);
            value = (Proxy)domain.CreateInstanceAndUnwrap(
                type.Assembly.FullName,
                type.FullName);
        }

        public void UnloadDomain()
        {
            if (domain != null)
            {
                AppDomain.Unload(domain);
                domain = null;
            }
        }
    }

    internal class Proxy : MarshalByRefObject
    {
        public void Run(string DLLPath, string method, params object[] parameters)
        {
            if (!File.Exists(DLLPath))
                throw new FileNotFoundException();

            var assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(DLLPath));

            Type[] mytypes = assembly.GetTypes();
            BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (Type t in mytypes)
            {
                MethodInfo[] mi = t.GetMethods(flags);
                Object obj = Activator.CreateInstance(t);
                bool IsFound = false;
                foreach (MethodInfo m in mi)
                {
                    if (m.Name.Equals(method))
                    {
                        m.Invoke(obj, parameters);
                        IsFound = true;
                    }
                }
                if (!IsFound)
                    throw new MissingMethodException();
            }
        }
    }
}
