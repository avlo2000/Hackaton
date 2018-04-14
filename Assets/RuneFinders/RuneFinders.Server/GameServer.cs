using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ObjectPort;
using RuneFinders.Connection;

namespace RuneFinders.Server
{
    class GameServer
    {
        private IPAddress _localAddr = IPAddress.Parse("127.0.0.1");
        private const int _port = 8888;
        private TcpListener _server;
        private TcpClient client1;
        private TcpClient client2;
        private TcpClient client3;
        private TcpClient client4;

        private NetworkStream stream1;
        private NetworkStream stream2;
        private NetworkStream stream3;
        private NetworkStream stream4;

        public State OldState;
        public State NewState;

        
        public GameServer() {
            try
            {
                _server = new TcpListener(_localAddr, _port);
                _server.Start();
                Console.WriteLine("Connecting to player 1");
                client1 = _server.AcceptTcpClient();
                Console.WriteLine("Connecting to player 1");
                client2 = _server.AcceptTcpClient();
                Console.WriteLine("Connecting to player 1");
                client3 = _server.AcceptTcpClient();
                Console.WriteLine("Connecting to player 1");
                client4 = _server.AcceptTcpClient();

                stream1 = client1.GetStream();
                stream2 = client2.GetStream();
                stream3 = client3.GetStream();
                stream4 = client4.GetStream();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_server != null)
                    _server.Stop();
            }
        }

        public void ProcessGame()
        {
            Serializer.RegisterTypes(new[] { typeof(State) });

            while (true)
            {
                NewState = (State)Serializer.Deserialize(stream1);

                NewState.ChangeState();

                Serializer.Serialize(stream1, NewState);
            }

        }
    }
}
