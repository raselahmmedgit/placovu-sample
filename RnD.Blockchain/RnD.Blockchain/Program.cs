using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("...===================================...");

                Console.WriteLine("...============Block  Chain===========...");

                //BootStrapper.Run();

                Console.WriteLine("...===================================...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.ReadLine();
        }
    }
}
