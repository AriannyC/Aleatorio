using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aleatorio
{
    public interface IService
    {
        Task UsersAsync(int userCount);
        Task ConAsync(HttpClient client);
    }
}
