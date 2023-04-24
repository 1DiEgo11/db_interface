using Business_Logic;
using System.Text;

using System.Net.Sockets;
using System.Net;
using System.Text;

IPHostEntry ipHost = Dns.GetHostEntry("localhost");
IPAddress ipAddr = ipHost.AddressList[1];
IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8081);

Socket socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

socket.Connect(ipEndPoint);





string command = "";
string username = "";
string password = "";
Console.CursorVisible = false;
command = Logic.Logics(0, 0, command, username, password);
Console.Clear();
byte[] data = Encoding.UTF8.GetBytes(command);
socket.Send(data);




//Console.WriteLine(username);
//Console.WriteLine(password);
//Console.ReadLine();







//ConsoleInterface.Restaurants(53, 10);
//ConsoleInterface.Date(53, 10);
//Console.Clear();
//ConsoleInterface.Time(53, 4);
//Console.Clear();
//ConsoleInterface.Table(53, 10);
//ConsoleInterface.LogIn(0,0);
//ConsoleInterface.LogOn(0,0);
