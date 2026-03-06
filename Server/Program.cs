using Shared.Models;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
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
            else if(Path.GetExtension(filePath) != "xlsx")
            {
                errorLog("file is not an exel file!");
                return;
            }

            successLog($"Server is running on {ip.ToString()}:{port}");
        }



        private async Task SendPacket(string type, string text, string sender, NetworkStream stream)
        {
            packet msg = new packet(type, text, sender);
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }
        private async Task SendPacket(packet msg, NetworkStream stream)
        {
            string json = JsonSerializer.Serialize(msg);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            await writer.WriteLineAsync(json);
        }
        private async Task<packet> ReceiveMessage(NetworkStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string? response = await reader.ReadLineAsync();
            if (response == null) throw new IOException("Connection lost");
            packet responseMsg = JsonSerializer.Deserialize<packet>(response);
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
