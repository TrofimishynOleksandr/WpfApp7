using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _newTitle = "";
        public string NewTitle
        {
            get { return _newTitle; }
            set
            {
                _newTitle = value;
                OnPropertyChanged(nameof(NewTitle));
            }
        }

        private string _window1TextBlock = "Change title on ";
        public string Window1TextBlock
        {
            get { return _window1TextBlock; }
            set
            {
                _window1TextBlock = value;
                OnPropertyChanged(nameof(Window1TextBlock));
            }
        }

        private IntPtr _handle;
        public IntPtr Handle
        {
            get { return _handle; }
            set
            {
                _handle = value;
                OnPropertyChanged(nameof(Handle));
            }
        }

        private int _window1Option;
        public int Window1Option
        {
            get { return _window1Option; }
            set
            {
                _window1Option = value;
                OnPropertyChanged(nameof(Window1Option));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
