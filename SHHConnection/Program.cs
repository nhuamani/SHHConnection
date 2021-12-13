using Renci.SshNet;


namespace SHHConection
{
    public partial class SSH
    {
        public static void Main(string[] args)
        {
            string host = "192.168.1.34";
            string user = "user";
            string pass = "123456";
            int port = 22;
            //string cmd = "touch indexFromWin.html";
            string cmd = "ls";
            SSH.Connect(host, user, pass, port, cmd);
        }


        public static string Connect(string hostname, string username, string password, int port, string cmdBash)
        {
            string result = string.Empty;
            try
            {
                using (var client = new SshClient(username, port, username, password))
                {
                    client.Connect();

                    SshCommand task = client.RunCommand(cmdBash);
                    client.Disconnect();
                    result = task.Result;
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}

