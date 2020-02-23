using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace DomainToIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = GetIP(textBox1.Text.Trim());
        }

        private string GetIP(string hostname)
        {
            try
            {
                hostname = hostname.Replace("http://", "").Replace("https://", "").Replace("/", "");
                string result = string.Empty;
                IPAddress[] addresses = Dns.GetHostAddresses(hostname);
                return result = addresses[0].ToString();
                foreach (IPAddress address in addresses)
                {
                    result += address + "\n";
                }
                return result;

                /*IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                IPEndPoint ipEndPoint = new IPEndPoint(hostEntry.AddressList[0], 0);
                return ipEndPoint.Address.ToString();*/

                /*IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                foreach (IPAddress item in hostEntry.AddressList)
                {
                    result += item + "\n";
                }
                return result;*/
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}