using System.Net.Sockets;
using System.Text;

namespace Client_Server
{
    public class ReceivingAndSending
    {
        public static string Receiving(NetworkStream stream)
        {
            byte[] reads = new byte[1024];
            int lenght = stream.Read(reads, 0, reads.Length);
            string s = Encoding.UTF8.GetString(reads, 0, lenght);
            return s;
        }

        public static void Sending(NetworkStream stream, string s) 
        {
            byte[] send = Encoding.UTF8.GetBytes(s);
            stream.Write(send, 0, send.Length);
            stream.Flush();
        }
    }
}