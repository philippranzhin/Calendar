using System.ComponentModel;
using Akvelon.Calendar.Models;

namespace Akvelon.Calendar.Infrastrucure
{
    public interface IUserTaskChanged : INotifyPropertyChanged
    {
        event TaskHandler TaskRemoved;
        event TaskHandler TaskAdded;
        void UpdateTasks();
    }

    public delegate void TaskHandler(IUserTaskChanged sender, UserTaskModel task);
}
