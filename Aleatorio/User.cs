using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleatorio
{
    public class User
    {
        private readonly IService _userService;

        public User(IService userService)
        {
            _userService = userService;
        }

        public async Task DAsync()
        {
            while (true)
            {
                Console.Write("¿Cuántos usuarios aleatorios deseas obtener? ");
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
                {
                    await _userService.UsersAsync(num);
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                Console.Write("¿Deseas buscar más usuarios? (si/no): ");
                if (Console.ReadLine().ToLower() != "si")
                {
                    break;
                }
            }
        }
    }
}


