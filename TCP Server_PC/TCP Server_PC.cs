using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

/* Referencing the following websites:
 * http://www.switchonthecode.com/tutorials/csharp-tutorial-simple-threaded-tcp-server
 * http://www.codeproject.com/KB/IP/TCPIPChat.aspx
 * http://www.java2s.com/Code/CSharp/Network/TcpClientSample.htm
 * This is very unrefined and brute forced. Just threw it together for testing. Lots of exceptions get thrown...
 * 
 * Daniel Rowan, 12/22/11
 */
namespace TCPServerTutorial
{
    class Server
    {
        //private TcpClient myTcpClient;
        private TcpListener myTcpListener;
        private Thread myListenThread;
        private int iPortNoStore;
        private string sEndPointNameStore, sIPAddressStore, sIPRemoteStore, sStringToSend;
        private bool boThreadRun = false;

        public delegate void PacketReceivedEventHandler(object sender);

        public event PacketReceivedEventHandler TCPPacketReceived;

        public string sRXStringStore = "NODATA";

        public Server(string sIPAddress, string sIPRemoteEndPoint, int iPortNo, string sEndPointName)
        {

            //assign the PortNo so I can know which port is returning data
            iPortNoStore = iPortNo;
            sEndPointNameStore = sEndPointName;
            sIPAddressStore = sIPAddress;
            sIPRemoteStore = sIPRemoteEndPoint;

            //assigning it the IP address I entered for now...
            IPAddress myIPAddressToListen = IPAddress.Parse(sIPAddress);
            this.myTcpListener = new TcpListener(myIPAddressToListen, iPortNo);

            System.Diagnostics.Debug.Write("Creating " + sEndPointName + " Server, listening on: " + myTcpListener.LocalEndpoint + "@" + iPortNo + "\n");

            this.myListenThread = new Thread(new ThreadStart(ListenForClient));
            boThreadRun = true;
            this.myListenThread.Start();

        }

        private void ListenForClient()
        {

            this.myTcpListener.Start();

            System.Diagnostics.Debug.Write("Listening For " + sEndPointNameStore + " on Port No: " + iPortNoStore + "\n");
            while (boThreadRun)
            {
                //blocks until a client has connected to the server, guessing it means it will sit 
                // in its own loop...
                System.Diagnostics.Debug.Write("Waiting for " + sEndPointNameStore + " connection...\n");
                try
                {
                    TcpClient myClient = this.myTcpListener.AcceptTcpClient();

                    System.Diagnostics.Debug.Write(sEndPointNameStore + " Connected!\n");
                    //create a thread to handle communication
                    //with connected client
                    Thread myClientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    myClientThread.Start(myClient);

                }
                catch (SocketException)
                {
                    System.Diagnostics.Debug.Write(sEndPointNameStore + " Not Connected!\n");
                    //just eating it...
                }



            }

            System.Diagnostics.Debug.Write("Exiting ListeForClient Thread");

        }


        private void HandleClientComm(object myClient)
        {
            TcpClient myTCPClient = (TcpClient)myClient;
            NetworkStream myClientStream = myTCPClient.GetStream();

            byte[] baMessage = new byte[4096];
            int iBytesRead;

            while (true)
            {
                System.Diagnostics.Debug.Print("Listen Thread running!");
                iBytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    iBytesRead = myClientStream.Read(baMessage, 0, 4096);
                    //System.Diagnostics.Debug.Write(sEndPointNameStore + " rcv success!\n");

                }

                catch (SocketException ex)
                {
                    //a socket error has occured, not sure how to get at the error yet
                    System.Diagnostics.Debug.Write(sEndPointNameStore + " socket ERR: " + ex.ToString());
                    break;

                }

                catch (System.IO.IOException ex)
                {
                    System.Diagnostics.Debug.Write(sEndPointNameStore + " IO ERR: " + ex.ToString());
                    break;
                }

                //finally
                //{
                    if (iBytesRead == 0)
                    {
                        //the client has disconnected from the server
                        System.Diagnostics.Debug.Write(sEndPointNameStore + " client D/C\n");
                        break;
                    }

                    //message has successfully been received

                    ASCIIEncoding myEncoder = new ASCIIEncoding();
                    //System.Diagnostics.Debug.Write(myEncoder.GetString(baMessage, 0, iBytesRead));

                    lock (sRXStringStore)
                    {
                        sRXStringStore = myEncoder.GetString(baMessage, 0, iBytesRead);
                    }

                    //broadcast that packet is ready
                    this.TCPPacketReceived(sRXStringStore);

                
                if(sStringToSend != "")
                {
                    SendMessageToClient(myClient);
                }

            }

            //Close the stream then the client
            /*if (myTCPClient.GetStream() != null)
            {
                myTCPClient.GetStream().Close();
                myTCPClient.Close();
            }*/

        }

        public void ClientSend(string sender)
        {
            sStringToSend = sender;

        }
        //part of orignal code example...
        private void SendMessageToClient(object sender)
        {
            //System.Diagnostics.Debug.Write("SndMsg2 " + sEndPointNameStore + "\n");
            TcpClient myTCPCLient = (TcpClient)sender;
            NetworkStream myClientStream = myTCPCLient.GetStream();
            ASCIIEncoding myEncoder = new ASCIIEncoding();

            byte[] baBuffer = myEncoder.GetBytes(sStringToSend + "\n");

            myClientStream.Write(baBuffer, 0, baBuffer.Length);
            myClientStream.Flush();

            //clear the string
            sStringToSend = "";

            //myTCPClient.Close();
        }

        ~Server()
        {
            Dispose();
        }

        public void Dispose()
        {

            myTcpListener.Stop();
            myTcpListener.Server.Close();


            if (myListenThread != null)
                boThreadRun = false;
                myListenThread.Abort();
   
        }

    }

}
