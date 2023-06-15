using Gunetberg.Client.Hash;

namespace Gunetberg.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hashClient = new Sha256HashClient();

            Console.WriteLine(hashClient.Hash("pass"));


        }
    }
}