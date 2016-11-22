using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Game
    {
        private static TcpListener listener;
        private static List<Player> players = new List<Player>();
        private static Map map = new Map(new IVector2(0, 0), 2);

        public static void Main(string[] Args)
        {
            listener = new TcpListener(IPAddress.Any, 56789);
            listener.Start(0);

            while (true) {
                if (listener.Pending()) {
                    Player player = new Player(20, 20, 10, listener.AcceptTcpClient());
                    players.Add(player);

                    Thread thread = new Thread(player.Communicate);
                    thread.Start(); 
                }
            }
        }
    }
}
