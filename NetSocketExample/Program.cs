using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSockets;
using System.Net; // Add namespace

namespace NetSocketExample
{
    class Program
    {
        static NetObjectServer server = new NetObjectServer(); // create the server object

        static void Main(string[] args)
        {
            if (!server.IsOnline)
            {
                // Set everything that is received to be echod by the server
                server.EchoMode = NetEchoMode.EchoAll;

                // Attach event handlers for server events
                server.OnClientAccepted += server_OnClientAccepted;
                server.OnClientConnected += server_OnClientConnected;
                server.OnClientDisconnected += server_OnClientDisconnected;
                server.OnClientRejected += server_OnClientRejected;
                server.OnReceived += server_OnReceived;
                server.OnStarted += server_OnStarted;
                server.OnStopped += server_OnStopped;
                server.OnError += server_OnError;

                // Start the server on all network interfaces and on port 7482
                server.Start(IPAddress.Any, 7482);
            }
        }

        static void server_OnError(object sender, NetExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }
        static void server_OnStopped(object sender, NetStoppedEventArgs e)
        {
            Console.WriteLine("Server Stopped --" + DateTime.Now);
        }
        static void server_OnStarted(object sender, NetStartedEventArgs e)
        {
            Console.WriteLine("Server Start --" + DateTime.Now);
        }
        static void server_OnReceived(object sender, NetClientReceivedEventArgs<NetObject> e)
        {
            Console.WriteLine("Server received");
        }
        static void server_OnClientRejected(object sender, NetClientRejectedEventArgs e)
        {
            Console.WriteLine(e.Guid.ToString() + " -- Client rejected by server");
        }
        static void server_OnClientDisconnected(object sender, NetClientDisconnectedEventArgs e)
        {
            Console.WriteLine(e.Guid.ToString() + " -- Client disconnected by server");
        }
        static void server_OnClientConnected(object sender, NetClientConnectedEventArgs e)
        {
            Console.WriteLine(e.Guid.ToString() + " -- Client connected by server");
        }
        static void server_OnClientAccepted(object sender, NetClientAcceptedEventArgs e)
        {
            Console.WriteLine(e.Guid.ToString() + " -- Client accepted by server");
        }

    }
}
