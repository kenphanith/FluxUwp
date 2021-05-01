using System.ComponentModel;

namespace FluxUwp.Types
{
    public abstract class StateType : INotifyPropertyChanged
    {
        public void InvokeNotify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
