using System.ComponentModel;
using Akvelon.Calendar.Infrastrucure.UserTasks;

namespace Akvelon.Calendar.Infrastrucure
{
    public interface IUserTaskChanged : INotifyPropertyChanged
    {
        event TaskHandler TaskRemoved;
        event TaskHandler TaskAdded;
        void UpdateTasks();
    }

    public delegate void TaskHandler(IUserTaskChanged sender, UserTask task);
}
