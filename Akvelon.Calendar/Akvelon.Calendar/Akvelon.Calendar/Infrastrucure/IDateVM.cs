namespace Akvelon.Calendar.Infrastrucure
{
    public interface IDateVM : IUserTaskChanged
    {
        event DateVMHandler NewVMNeeded;
    }

    public delegate void DateVMHandler(IDateVM sender, DateInfo newDate);
}
