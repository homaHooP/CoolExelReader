using Shared.Models;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IPAddress ip;
        private int port;

        TcpClient client;
        NetworkStream stream;

        private async Task SendPacket(string type, string text, string sender, NetworkStream stream)
        {
            packet msg = new packet(type, text, sender);
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }
        private async Task SendPacket(string type, string text, string sender, string[] Products, NetworkStream stream)
        {
            packet msg = new packet(type, text, sender, Products);
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }

        private async Task<packet> ReceiveMessage(NetworkStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string? response = await reader.ReadLineAsync();
            if (response == null) return new packet("disconnect", "connection lost", "server");
            packet responseMsg = JsonSerializer.Deserialize<packet>(response);
            if (responseMsg == null)
                throw new Exception("Invalid packet");
            return responseMsg;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ip.Text) || string.IsNullOrWhiteSpace(txt_port.Text))
            {
                MessageBox.Show("Make sure all the fileds are filled");
                return;
            }
            else if (!IPAddress.TryParse(txt_ip.Text, out ip))
            {
                MessageBox.Show("Wrong ip format");
                return;
            }
            else if (!int.TryParse(txt_port.Text, out port))
            {
                MessageBox.Show("Wrong port format");
            }

            client = new TcpClient();
            try
            {
                await client.ConnectAsync(ip, port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            stream = client.GetStream();
            try
            {
                await SendPacket("connectmepls", "", "client", stream);
                var resp = await ReceiveMessage(stream);

                if (resp.Type == "welcomemyfriend")
                {
                    MessageBox.Show("Connected!");
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not connected :(");
                client.Close();
                return;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Make sure all the fileds are filled");
                return;
            }
            string[] names = richTextBox1.Text.Split(' ');
            if (names.Length == 0)
            {
                MessageBox.Show("Wrong format");
                return;
            }
            await SendPacket("getFileInfo", "", "client", names, stream);
            var resp = await ReceiveMessage(stream);
            if (resp.Type == "refused")
            {
                MessageBox.Show($"Error: {resp.Text}");
            }
            dataGridView1.Rows.Clear();
            if (resp.Type == "prodinfo")
            {
                List<product> products = resp.Products;
                for (int i = 0; i < products.Count; i++)
                {
                    dataGridView1.Rows.Add(products[i].name, products[i].price, products[i].number);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Close();
            }
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
