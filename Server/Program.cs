using OfficeOpenXml;
using Shared.Models;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress? ip;
            int port;
            string filePath;

            Console.Write("Enter ip(default 127.0.0.1): ");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ip = IPAddress.Parse("127.0.0.1");
            }
            else if (!IPAddress.TryParse(address, out ip))
            {
                errorLog("Wrong ip format!");
                return;
            }

            Console.Write("Enter port(default 8888): ");
            string portt = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(portt))
            {
                port = 8888;
            }
            else if (!int.TryParse(portt, out port))
            {
                errorLog("Wrong port format!");
                return;
            }

            Console.Write("Enter a path to your exel file: ");
            filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                errorLog("Wrong file path");
                return;
            }
            else if (Path.GetExtension(filePath) != ".xlsx")
            {
                errorLog("file is not an exel file!");
                return;
            }
            Program program = new Program();
            await program.startServer(ip, port, filePath);
        }

        private async Task startServer(IPAddress ip, int port, string filePath)
        {
            TcpListener listener = new TcpListener(ip, port);
            successLog($"Server is running on {ip.ToString()}:{port}, file source: {Path.GetFileName(filePath)}");
            listener.Start();
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = HandleClient(client, filePath);
            }
        }

        private async Task HandleClient(TcpClient client, string filePath)
        {
            NetworkStream clientStream = client.GetStream();
            successLog("Client connected!");
            try
            {
                while (true)
                {
                    packet msg = await ReceiveMessage(clientStream);
                    switch (msg.Type)
                    {
                        case "connectmepls":
                            await SendPacket("welcomemyfriend","","server",clientStream);
                            break;
                        case "getFileInfo":
                            if (msg.ProdNames.Length == 0)
                            {
                                await SendPacket("refused","no product names were provided","server",clientStream);
                                Console.WriteLine("No products provided");
                                return;
                            }
                            List<product> prods = readColWithName(filePath, msg.ProdNames);
                            await SendPacket("prodinfo", "", "server", prods, clientStream);
                        break;
                    } 
                }
            }
            catch (IOException ex)
            {
                clientDisconnectedLog(ex.Message);
            }
            catch (Exception ex)
            {
                errorLog(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private List<product> readColWithName(string filePath, string[] names)
        {
            var products = new List<product>();
            var nameSet = new HashSet<string>(names);

            ExcelPackage.License.SetNonCommercialPersonal("Test");

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {

                var sheet = package.Workbook.Worksheets[0];

                if (sheet.Dimension == null)
                    return products;

                int rows = sheet.Dimension.Rows;

                for (int row = 2; row <= rows; row++)
                {
                    string pname = sheet.Cells[row, 1].GetValue<string>();

                    if (nameSet.Contains(pname))
                    {
                        double price = sheet.Cells[row, 2].GetValue<double>();
                        int quantity = sheet.Cells[row, 3].GetValue<int>();
                        product prod = new product(pname, price, quantity);
                        products.Add(prod);
                    }
                }
            }

            return products;
        }

        private async Task SendPacket(string type, string text, string sender,List<product> Products, NetworkStream stream)
        {
            packet msg = new packet(type, text, sender, Products);
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }
        private async Task SendPacket(string type, string text, string sender, NetworkStream stream)
        {
            packet msg = new packet(type, text, sender);
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }
        private async Task<packet> ReceiveMessage(NetworkStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string? response = await reader.ReadLineAsync();
            if (response == null) throw new IOException("Client disconnected");
            packet responseMsg = JsonSerializer.Deserialize<packet>(response);
            if (responseMsg == null)
                throw new Exception("Invalid packet");
            return responseMsg;
        }

        private static void errorLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void clientDisconnectedLog(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        private static void successLog(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
