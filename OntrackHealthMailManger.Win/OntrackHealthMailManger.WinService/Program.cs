using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OntrackHealthMailManger.WinService
{
    static class Program
    {
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;

            // More than one user service may run in the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new OntrackHealthMailService()};
 

            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
    }
}
