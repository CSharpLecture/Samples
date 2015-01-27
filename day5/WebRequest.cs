using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRequestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a valid URL:");
            string url = Console.ReadLine();

            //Creating the Task - we cannot use async here (thus: no await) ...
            //Hence back to good old tasks!
            ReadUrl(url).ContinueWith(task =>
            {
                //Did the request complete successfully?
                if (task.IsFaulted)
                {
                    Console.WriteLine("That did not work ...");
                    return;
                }

                Console.WriteLine("Content:");
                Console.WriteLine(task.Result);
            });

            //We need this otherwise the main thread is finished!
            Console.Read();
        }

        static async Task<string> ReadUrl(string url)
        {
            //Get the request
            var request = WebRequest.Create(url);
            //Get the response
            var response = await request.GetResponseAsync();
            //Get the response content
            var stream = new StreamReader(response.GetResponseStream());
            //Read it!
            var content = stream.ReadToEnd();
            return content;
        }
    }
}
