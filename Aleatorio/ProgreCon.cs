using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aleatorio
{
    public class ProgreCon: IService
    {
        public async Task UsersAsync(int userCount)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.Title = "Cargando";
                Console.CursorVisible = false;
                Console.SetCursorPosition(1, 1);

                for (int i = 0; i < 50; i++)
                {

                    for (int j = 0; j < i; j++)
                    {


                        string bp = "\u2551";
                        Console.Write(bp);


                    }
                    Console.Write(i + "n/ 50");
                    Console.SetCursorPosition(1, 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Threading.Thread.Sleep(50);
                }
                Console.Clear();

                List<Task> tasks = new List<Task>();
                for (int i = 0; i < userCount; i++)
                {
                    tasks.Add(ConAsync(client));
                }

                await Task.WhenAll(tasks);
            }
        }

        public async Task ConAsync(HttpClient client)
        {
            try
            {
                string url = "https://randomuser.me/api/";
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var res = await response.Content.ReadAsStringAsync();
                dynamic r = JObject.Parse(res)["results"][0] as JObject;

                Console.WriteLine($"Nombre: {r["name"]["first"]} {r["name"]["last"]}");
                Console.WriteLine($"Género: {r["gender"]}");
                Console.WriteLine($"Correo electrónico: {r["email"]}");
                Console.WriteLine($"País: {r["location"]["country"]}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener el usuario: {e.Message}");

            }
        }

    }
}
