using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace WpfApp7
{
    public class Service
    {
        private readonly ViewModel _viewModel;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr intPtr, string text, string title, MessageBoxOptions options);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        const uint WM_SETTEXT = 0x000C;
        const uint WM_CLOSE = 0x0010;

        public Service(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Task1()
        {
            var result = MessageBox(IntPtr.Zero, "My name is Sasha", "Info about me", MessageBoxOptions.OKCancel | MessageBoxOptions.IconInformation);
            if (result == (int)MsgBoxButtons.Ok)
            {
                result = MessageBox(IntPtr.Zero, "I'm 18 years old", "Info about me", MessageBoxOptions.OKCancel | MessageBoxOptions.IconInformation);
                if (result == (int)MsgBoxButtons.Ok)
                {
                    MessageBox(IntPtr.Zero, "I study programming", "Info about me", MessageBoxOptions.OK | MessageBoxOptions.IconInformation);
                }
            }
        }

        public void Task2()
        {
            _viewModel.NewTitle = "";

            var dialog = new Window1(_viewModel).ShowDialog().Value;
            if (dialog)
            {
                if (_viewModel.Handle != IntPtr.Zero)
                {
                    switch (_viewModel.Window1Option)
                    {
                        case 1:
                            SendMessage(_viewModel.Handle, WM_SETTEXT, IntPtr.Zero, _viewModel.NewTitle);
                            break;
                        case 2:
                            SendMessage(_viewModel.Handle, WM_CLOSE, IntPtr.Zero, _viewModel.NewTitle);
                            break;
                    }
                }
            }
        }

        public void Task3()
        {
            new Window2().Show();
        }

    }

    public enum MessageBoxOptions : uint
    {
        OK = 0x00000000,
        OKCancel = 0x00000001,
        AbortRetryIgnore = 0x00000002,
        YesNoCancel = 0x00000003,
        YesNo = 0x00000004,
        RetryCancel = 0x00000005,
        CancelTryContinue = 0x00000006,
        IconError = 0x00000010,
        IconQuestion = 0x00000020,
        IconWarning = 0x00000030,
        IconInformation = 0x00000040,
        UserIcon = 0x00000080
    }

    public enum MsgBoxButtons
    {
        Yes = 6,
        No = 7,
        Ok = 1,
        Cancel = 2
    }
}
