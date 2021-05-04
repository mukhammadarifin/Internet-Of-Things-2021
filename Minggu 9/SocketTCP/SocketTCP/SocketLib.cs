using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SocketTCP
{
    public static class GlobalVariable
    {       
        public static string ipserver;
        public static string iptujuan;
        public static int port;        
        public static string pesanTerima;
    }

    class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public static class SocketLib
    {
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ManualResetEvent receiveDone = new ManualResetEvent(false);
        public static String response = String.Empty;        

        // ###############################
        //          SOCKET CLIENT
        // ###############################

        public static void StartClient(string pesan)
        {            
            IPAddress ip = IPAddress.Parse(GlobalVariable.iptujuan);
            IPEndPoint remoteEP = new IPEndPoint(ip, GlobalVariable.port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var result = client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
            result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            System.Threading.Thread.Sleep(10);
            
            if (client.Connected)
            {
                Send(client, pesan);
                System.Threading.Thread.Sleep(10);
                sendDone.WaitOne();                
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        public static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                connectDone.Set();
            }
            catch
            {
                //MessageBox.Show("Koneksi Audio Kelas Terputus\n\rAudio Kelas Dalam Kondisi Down", "Perangkat Client Down", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        public static void Send(Socket client, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                sendDone.Set();
            }
            catch
            {

            }
        }

        public static void Receive(Socket client)
        {
            StateObject state = new StateObject();
            state.workSocket = client;
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                receiveDone.Set();
            }
        }

        // ###############################
        //      SOCKET SERVER LISTENER
        // ###############################
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        //Listening
        public static void StartListening()
        {
            IPAddress ipAddress = IPAddress.Parse(GlobalVariable.ipserver);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, GlobalVariable.port);
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();
                    //MessageBox.Show("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                content = state.sb.ToString();
                GlobalVariable.pesanTerima = content;                
            }
        }
    }
}
