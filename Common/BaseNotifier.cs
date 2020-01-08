using System.ComponentModel;
namespace VendoreMachine.Common
{
    public abstract class BaseNotifier : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
