using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRSample
{
    public partial class Form1 : Form
    {
        const string URL = "http://localhost:8080";
        IHubProxy hub;
        SynchronizationContext context;

        public Form1()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            Connection().Async();
        }

        async void send_Click(object sender, EventArgs e)
        {
            input.ReadOnly = true;
            send.Enabled = false;
            await hub.Invoke("Send", input.Text);
            input.ReadOnly = false;
            send.Enabled = true;
            input.Text = string.Empty;
        }

        async Task Connection()
        {
            var connection = new HubConnection(URL);
            hub = connection.CreateHubProxy("MyHub");

            try
            {
                await connection.Start();
                hub.On<string>("addMessage", Display);
                send.Enabled = true;
            }
            catch
            {
                //Seems like no server is here - let's start one!
                WebApplication.Start<Startup>(URL);//
                Connection().Async();
            }
        }

        void Display(string msg)
        {
            context.Send(_ => dialog.AppendText(msg + "\n"), null);
        }

        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                // Turn cross domain on 
                var config = new HubConfiguration { EnableCrossDomain = true };

                // This will map out to http://localhost:8080/signalr by default
                app.MapHubs(config);
            }
        }

        public class MyHub : Hub
        {
            public void Send(string message)
            {
                Clients.All.addMessage(message);
            }
        }
    }

    public static class Extensions
    {
        public static void Async(this Task t)
        {
        }
    }
}
