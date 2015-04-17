using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using TasksManager.DataModel;
using System.Threading;

namespace TasksManager
{
    public class TaskMessageQueue : ConcurrentQueue<TaskMessageDataModel>
    {
        private MessageDispatcher dispatcher;

        private static TaskMessageQueue _instance;
        private TaskMessageQueue()
        {
            dispatcher = new MessageDispatcher();
        }

        public static TaskMessageQueue GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TaskMessageQueue();
            }

            return _instance;
        }

        public void AddToQueue(TaskMessageDataModel message)
        {
            //this.Enqueue(message);
            lock (this)
            {
                DispatcherMessage(message);
            }
        }

        private void DispatcherMessage(TaskMessageDataModel message)
        {
            dispatcher = new MessageDispatcher();
            dispatcher.Dispatcher(message);
        }
    }
}
