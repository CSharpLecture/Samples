using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let's create an instance of our WebSurfer-Class
            MyWebSurfer surfi = new MyWebSurfer();

            //Now we add a function to the event which will be called when the event is fired
            surfi.pageLoaded += Surfi_pageLoaded;

            /*
            //You can do the same as above with an anonymous function
            surfi.pageLoaded +=(sender, arg) =>
            {
                if (!arg.isFaulted)
                    Console.WriteLine(arg.message);
                else
                    Console.WriteLine("Es gab einen fehler");
            };
            */

            //now start a request that will fire the event in the end
            surfi.StartWebrequest("http://google.de");

            //keep the console open.
            //If not, the program will end before the event is fired
            Console.ReadKey();

        }

        //This is the function that will be called when the pageLoaded-event is fired
        //it takes MyWebSurferEventArgs to transmit the message and whether the request was successful
        private static void Surfi_pageLoaded(object sender, MyWebSurferEventArgs e)
        {
            //give out result which is saved in the message property
            Console.WriteLine(e.message); 
        }
    }

    //Class of my Websurfer
    class MyWebSurfer
    {
        //here define the event
        public event EventHandler<MyWebSurferEventArgs> pageLoaded;

        // You could get a similar behaviour when using the following public delegate 
        //public delegate void pageLoaded(object sender, MyWebSurferEventArgs args);


        //this asynchronous function does the web request and fires the event pageLoaded when a result is obtained
        public async void StartWebrequest(string url)
        {
            //Code from the lecture
            var request = WebRequest.Create(url);
            var response = await request.GetResponseAsync(); //await the result
            using (var stream = new StreamReader(response.GetResponseStream())) //use a streamreader with using to take care of the closing/disposing of the stream
            {
                var content = stream.ReadToEnd(); //read all data
                
                //create a new instance of MyWebSurferEventargs where the content is saved
                var parameter = new MyWebSurferEventArgs(content);

                //check if the event has listeners - important for proper code
                if (pageLoaded != null)
                    pageLoaded(this, parameter); //fire the event with sender = this and the MyWebSurferEventArgs from above
                
            }
            response.Close(); //dispose the response
        }
    }

    //My personal MyWebSurferEventArgs which inherit from EventArgs
    public class MyWebSurferEventArgs : EventArgs
    {
        //A getter-only property to a string where the webpage-content is saved
        public string message { get; }

        //a constructor to set the content
        public MyWebSurferEventArgs(string message)
        {
            this.message = message;
        }
    }
}
