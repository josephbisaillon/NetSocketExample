using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSockets; //add the namespace for NetSockets

namespace NetSocketClientExample
{
    class Program
    {
        static readonly NetObjectClient client = new NetObjectClient(); // Add the client object

        static void Main(string[] args)
        {
            // Introduce your clients!
            Console.WriteLine("Welcome to the NetSocket client application");

            // Attach event handlers
            client.OnConnected += client_OnConnected;
            client.OnDisconnected += client_OnDisconnected;
            client.OnReceived += client_OnReceived;

            // Connect to the NetSockets server
            client.TryConnect("127.0.0.1", 7482);
        }

        static void client_OnReceived(object sender, NetReceivedEventArgs<NetObject> e)
        {
            Console.WriteLine("Client received - Name: " + e.Data.Name + " Message: " + e.Data.Object.ToString());
        }

        static void client_OnDisconnected(object sender, NetDisconnectedEventArgs e)
        {
            Console.WriteLine("Client Disconnected!");
        }

        static void client_OnConnected(object sender, NetConnectedEventArgs e)
        {
            Console.WriteLine("Client Connected!");
        }
    }
}
