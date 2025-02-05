using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleatorio
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IService userService = new ProgreCon();
            User userConsole = new User(userService);
            await userConsole.RunAsync();
        }
    }
}
