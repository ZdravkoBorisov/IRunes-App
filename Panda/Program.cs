using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace Panda
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           await WebHost.StartAsync(new Startup());
        }
    }
}
