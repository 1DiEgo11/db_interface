using Interface;

//using System.Net.Sockets;
//using System.Net;
//using System.Text;

//IPHostEntry ipHost = Dns.GetHostEntry("localhost");
//IPAddress ipAddr = ipHost.AddressList[1];
//IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8081);

//Socket socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//socket.Connect(ipEndPoint);


//String msg;
//while (true)
//{
//    msg = Console.ReadLine();
//    byte[] data = Encoding.UTF8.GetBytes(msg);
//    socket.Send(data);
//}

//socket.Close();




Console.CursorVisible = false;
string username = "";
string password = "";
ConsoleInterface.LogIn_Or_LogOn(40, 5, username, password);





//ConsoleInterface.Restaurants(0, 0);
//ConsoleInterface.Date(0, 0);
//Console.Clear();
//ConsoleInterface.Time(0, 0);
//Console.Clear();
//ConsoleInterface.Table(0, 0);