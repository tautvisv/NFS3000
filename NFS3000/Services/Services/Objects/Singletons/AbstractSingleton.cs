using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Objects.Singletons
{
    public abstract class AbstractSingleton<T> where T : class, new()
    {
        protected static T instance;
        protected static object lockInstanceObj = new object();
        protected AbstractSingleton()
        {
            
        }

        public static T GetInstance()
        {
            lock (lockInstanceObj)
            {
                if (instance == null)
                {
                    instance = new T();
                }
            }
            return instance;
        }
    }
}
