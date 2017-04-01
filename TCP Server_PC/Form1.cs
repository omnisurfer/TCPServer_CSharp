using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //using 242 (lan) or 116 (wifi)
        const string sLocalEndPointIP0 = "127.0.0.1"/*"192.168.45.116"*/, sRemoteEndPointIP0 = /*"192.168.45.242"*/"127.0.0.1";
        const string sEndPoint0Name = "Arduino_GPS", sEndPoint1Name = "Arduino_Compass", sEndPoint2Name = "Arduino_ODB", sEndPoint3Name = "Arduino_CMD";
        const int iEndPointPort0 = 3000, iEndPointPort1 = 3001, iEndPointPort2 = 3002, iEndPointPort3 = 3003;

        TCPServerTutorial.Server myEndPoint0 = new TCPServerTutorial.Server(sLocalEndPointIP0, sRemoteEndPointIP0, iEndPointPort0, sEndPoint0Name);
        TCPServerTutorial.Server myEndPoint1 = new TCPServerTutorial.Server(sLocalEndPointIP0, sRemoteEndPointIP0, iEndPointPort1, sEndPoint1Name);
        TCPServerTutorial.Server myEndPoint2 = new TCPServerTutorial.Server(sLocalEndPointIP0, sRemoteEndPointIP0, iEndPointPort2, sEndPoint2Name);
        TCPServerTutorial.Server myEndPoint3 = new TCPServerTutorial.Server(sLocalEndPointIP0, sRemoteEndPointIP0, iEndPointPort3, sEndPoint3Name);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // write your code here


            myEndPoint0.TCPPacketReceived += new TCPServerTutorial.Server.PacketReceivedEventHandler(myEndPoint0_TCPPacketReceived);
            myEndPoint1.TCPPacketReceived += new TCPServerTutorial.Server.PacketReceivedEventHandler(myEndPoint1_TCPPacketReceived);
            myEndPoint2.TCPPacketReceived += new TCPServerTutorial.Server.PacketReceivedEventHandler(myEndPoint2_TCPPacketReceived);
            myEndPoint3.TCPPacketReceived += new TCPServerTutorial.Server.PacketReceivedEventHandler(myEndPoint3_TCPPacketReceived);

            System.Diagnostics.Debug.Write("Running...\n");

            Thread.Sleep(100);

        }

        void myEndPoint0_TCPPacketReceived(object sender)
        {

            string sTemp = (string)sender;
            if (gpsTextBox.InvokeRequired)
            {
                gpsTextBox.Invoke(new MethodInvoker(delegate { gpsTextBox.AppendText(sTemp); }));
            }
            //throw new NotImplementedException();

        }

        void myEndPoint1_TCPPacketReceived(object sender)
        {

            string sTemp = (string)sender;
            if (compassTextBox.InvokeRequired)
            {
                compassTextBox.Invoke(new MethodInvoker(delegate { compassTextBox.AppendText(sTemp); }));
            }
            //throw new NotImplementedException();

        }

        void myEndPoint2_TCPPacketReceived(object sender)
        {

            string sTemp = (string)sender;
            if (odbTextBox.InvokeRequired)
            {
                odbTextBox.Invoke(new MethodInvoker(delegate { odbTextBox.AppendText(sTemp); }));
            }
            //throw new NotImplementedException();

        }

        void myEndPoint3_TCPPacketReceived(object sender)
        {

            string sTemp = (string)sender;
            if (cmdTextBox != null && cmdTextBox.InvokeRequired)
            {

                    cmdTextBox.Invoke(new MethodInvoker(delegate { cmdTextBox.AppendText(sTemp); }));
                
            }
            //throw new NotImplementedException();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {            
            myEndPoint0.Dispose();
            myEndPoint1.Dispose();
            myEndPoint2.Dispose();
            myEndPoint3.Dispose();
            Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sTemp = "";

            if (cmdSendTextBox.Text != "")
            {
                sTemp = cmdSendTextBox.Text;

                myEndPoint3.ClientSend(sTemp);
                //System.Diagnostics.Debug.Print(sTemp + '!');

                //clear it
                cmdSendTextBox.Text = "";
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}