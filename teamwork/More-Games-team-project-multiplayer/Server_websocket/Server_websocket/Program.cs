
using Server_websocket;

Console.WriteLine("Привет это сервер");
foreach (string args_p in args)
{
    Console.WriteLine(args_p);
}

if (args.Length == 0)
{
    _Server _Server = new _Server();
}
else
{
    _Server _Server = new _Server(args);
}
