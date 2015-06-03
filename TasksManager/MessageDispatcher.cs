using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager.DataModel;

namespace TasksManager
{
    public class MessageDispatcher
    {
        private static MessageDispatcher _instance;

        public delegate void MessageReceivedHandle(TaskMessageDataModel message);
        public MessageReceivedHandle MessageReceived;

        private MessageDispatcher()
        {
        }

        public static MessageDispatcher GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MessageDispatcher();
            }

            return _instance;
        }

        public void Dispatcher(TaskMessageDataModel message)
        {
            if(MessageReceived!=null)
            {
                MessageReceived(message);
            }
        }
    }
}
