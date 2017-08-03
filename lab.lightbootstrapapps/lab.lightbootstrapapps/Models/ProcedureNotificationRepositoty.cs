using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.lightbootstrapapps.Models
{
    public class ProcedureNotificationRepositoty
    {
        private PlacovuOntrackHealth_DevEntities _context;

        public ProcedureNotificationRepositoty()
        {
            _context = new PlacovuOntrackHealth_DevEntities();
        }


    }
}