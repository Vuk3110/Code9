using static System.Formats.Asn1.AsnWriter;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main()
        {
            var app = new Application();

            app.Run();
        }
        
    }
}