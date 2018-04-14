using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using RuneFinders.Connection;

namespace RuneFinders.Server
{
    class GameServer
    {
        private IPAddress _localAddr = IPAddress.Parse("127.0.0.1");
        private const int _port = 8888;
        private TcpListener _server;

        public State OldState;
        public State NewState;
        public GameServer() {
            try
            {
                _server = new TcpListener(_localAddr, _port);
                _server.Start();
                var socket = _server.AcceptTcpClient();

                NetworkStream stream = socket.GetStream();
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
    }
}
