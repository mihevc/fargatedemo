using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace testloader
{
    class Program
    {
        static int __iteration = 0;

        static void Main(string[] args)
        {
            for (var z = 0; z < int.Parse(args[1]); z++)
            {
                Task[] tasks = new Task[10];

                for (var i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = SendAsync(args[0]);
                }

                Task.WaitAll(tasks);
            }
            Console.WriteLine("done");
        }

        static async Task SendAsync(string url) 
        {
            Console.WriteLine(__iteration++ + " - " + "Call");

            var iteration = __iteration;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var output = await client.GetStringAsync(url);

            Console.WriteLine(iteration + " - " + output);
        }
    }
}
