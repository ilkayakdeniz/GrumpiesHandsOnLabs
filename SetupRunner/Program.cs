using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            Process p = new Process();

            try
            {              
                p.StartInfo.UseShellExecute = false;                
                p.StartInfo.FileName = "setup.bat";

                p.StartInfo.Arguments = string.Format("C-Sharp Console application");
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();

                Console.Write("Press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }

            p.Dispose();
        }
    }
}
