using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.SOLIDApps
{
    public class Email
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class Notification
    {
        private Email _email;
        public Notification()
        {
            _email = new Email();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }

    /*Now Notification class totally depends on Email class, because it only sends one type of notification. If we want to introduce any other like SMS then? We need to change the notification system also. And this is called tightly coupled. What can we do to make it loosely coupled? Ok, check the following implementation.*/

    public interface IMessenger
    {
        void SendMessage();
    }
    public class Email1 : IMessenger
    {
        public void SendMessage()
        {
            // code to send email
        }
    }

    public class SMS1 : IMessenger
    {
        public void SendMessage()
        {
            // code to send SMS
        }
    }
    public class Notification1
    {
        private IMessenger _iMessenger;
        public Notification1()
        {
            _iMessenger = new Email1();
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }

    /*Still Notification class depends on Email class. Now, we can use dependency injection so that we can make it loosely coupled. There are 3 types to DI, Constructor injection, Property injection and method injection.*/

    public class NotificationC
    {
        private IMessenger _iMessenger;
        public NotificationC(IMessenger pMessenger)
        {
            _iMessenger = pMessenger;
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }

    /*Property Injection*/

    public class NotificationP
    {
        private IMessenger _iMessenger;

        public NotificationP()
        {
        }
        public IMessenger MessageService
        {
            set
            {
                _iMessenger = value;
            }
        }

        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }

    /*Method Injection*/

    public class Notification
    {
        public void DoNotify(IMessenger pMessenger)
        {
            pMessenger.SendMessage();
        }
    }
}
