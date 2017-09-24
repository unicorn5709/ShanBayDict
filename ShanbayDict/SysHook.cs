using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;

namespace ShanbayDict
{

    //Declare wrapper managed POINT class.
    [StructLayout(LayoutKind.Sequential)]
    public class POINT
    {
        public int x;
        public int y;
    }
    //Declare wrapper managed MouseHookStruct class.
    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct
    {
        public POINT pt;
        public int hwnd;
        public int wHitTestCode;
        public int dwExtraInfo;
    }
    //Declare wrapper managed KeyboardHookStruct class.

    [StructLayout(LayoutKind.Sequential)]
    public class KeyboardHookStruct
    {
        public int vkCode; //Specifies a virtual-key code. The code must be a value in the range 1 to 254. 
        public int scanCode; // Specifies a hardware scan code for the key. 
        public int flags; // Specifies the extended-key flag, event-injected flag, context code, and transition-state flag.
        public int time; // Specifies the time stamp for this message.
        public int dwExtraInfo; // Specifies extra information associated with the message. 
    }


    public class GlobalHook
    {
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        public delegate int GlobalHookProc(int nCode, Int32 wParam, IntPtr lParam);
        int current_time;
        bool has_start;
        public GlobalHook()
        {
            has_start = false;
            Start();
        }
        ~GlobalHook()
        {
            Stop();
        }

        public event MouseEventHandler OnMouseActivity;
        public event KeyEventHandler KeyDown;
        public event KeyPressEventHandler KeyPress;
        public event KeyEventHandler KeyUp;

        /// <summary>
        /// 定义鼠标钩子句柄.
        /// </summary>
        static int _hMouseHook = 0;
        /// <summary>
        /// 定义键盘钩子句柄
        /// </summary>
        static int _hKeyboardHook = 0;

        public int HMouseHook
        {
            get { return _hMouseHook; }
        }
        public int HKeyboardHook
        {
            get { return _hKeyboardHook; }
        }

        /// <summary>
        /// 鼠标钩子常量(from Microsoft SDK  Winuser.h )
        /// </summary>
        public const int WH_MOUSE_LL = 14;
        /// <summary>
        /// 键盘钩子常量(from Microsoft SDK  Winuser.h )
        /// </summary>
        public const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// 定义鼠标处理过程的委托对象
        /// </summary>
        GlobalHookProc MouseHookProcedure;
        /// <summary>
        /// 键盘处理过程的委托对象
        /// </summary>
        GlobalHookProc KeyboardHookProcedure;

        //导入window 钩子扩展方法导入

        /// <summary>
        /// 安装钩子方法
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, GlobalHookProc lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// 卸载钩子方法
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //Import for CallNextHookEx.
        /// <summary>
        /// 使用这个函数钩信息传递给链中的下一个钩子过程。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public bool Start()
        {
            // install Mouse hook 
            if (_hMouseHook == 0)
            {
                // Create an instance of HookProc.
                MouseHookProcedure = new GlobalHookProc(MouseHookProc);
                try
                {
                    _hMouseHook = SetWindowsHookEx(WH_MOUSE_LL,
                                                   MouseHookProcedure,
                                                   Marshal.GetHINSTANCE(
                                                   Assembly.GetExecutingAssembly().GetModules()[0]),
                                                   0);
                }
                catch (Exception err)
                { }
                //如果安装鼠标钩子失败
                if (_hMouseHook == 0)
                {
                    Stop();
                    Console.WriteLine("setup hook failed.");
                    return false;
                    //throw new Exception("SetWindowsHookEx failed.");
                }
            }
            //安装键盘钩子
            if (_hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new GlobalHookProc(KeyboardHookProc);
                try
                {
                    _hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL,
                                                    KeyboardHookProcedure,
                                                    Marshal.GetHINSTANCE(
                                                    Assembly.GetExecutingAssembly().GetModules()[0]),
                                                    0);
                }
                catch (Exception err2)
                { }
                //如果安装键盘钩子失败
                if (_hKeyboardHook == 0)
                {
                    Stop();
                    return false;
                    //throw new Exception("SetWindowsHookEx ist failed.");
                }
            }
            return true;
        }

        public void Stop()
        {
            bool retMouse = true;
            bool retKeyboard = true;
            if (_hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(_hMouseHook);
                _hMouseHook = 0;
            }
            if (_hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(_hKeyboardHook);
                _hKeyboardHook = 0;
            }
            //If UnhookWindowsHookEx fails.
            if (!(retMouse && retKeyboard))
            {
                //throw new Exception("UnhookWindowsHookEx ist failed.");
            }

        }
        /// <summary>
        /// 卸载hook,如果进程强制结束,记录上次钩子id,并把根据钩子id来卸载它
        /// </summary>
        public void Stop(int hMouseHook, int hKeyboardHook)
        {
            if (hMouseHook != 0)
            {
                UnhookWindowsHookEx(hMouseHook);
            }
            if (hKeyboardHook != 0)
            {
                UnhookWindowsHookEx(hKeyboardHook);
            }
        }

        private const int WM_MOUSEMOVE = 0x200;

        private const int WM_LBUTTONDOWN = 0x201;

        private const int WM_RBUTTONDOWN = 0x204;

        private const int WM_MBUTTONDOWN = 0x207;

        private const int WM_LBUTTONUP = 0x202;

        private const int WM_RBUTTONUP = 0x205;

        private const int WM_MBUTTONUP = 0x208;

        private const int WM_LBUTTONDBLCLK = 0x203;

        private const int WM_RBUTTONDBLCLK = 0x206;

        private const int WM_MBUTTONDBLCLK = 0x209;

        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            IDataObject data;
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;

                switch (wParam)
                {
                    case WM_LBUTTONDOWN:    //左键按下
                        
                        has_start = true;
                        current_time = System.Environment.TickCount;
                        break;
                    case WM_LBUTTONUP:
                        if(has_start)
                        {
                            if(System.Environment.TickCount-current_time > 500)
                            {
                                SendKeys.Send("^c");
                            }
                            else
                            {
                                Clipboard.SetDataObject("", true);
                            }

                            //Marshall the data from callback.
                            MouseHookStruct MyMouseHookStruct =
                                (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                            MouseEventArgs e = new MouseEventArgs(
                                MouseButtons.Left,
                                1,
                                MyMouseHookStruct.pt.x,
                                MyMouseHookStruct.pt.y,
                                0);
                            OnMouseActivity(this, e);
                        }
                        has_start = false;
                        current_time = 0;
                        button = MouseButtons.Left;

                        break;
                    case WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        break;
                }
                if (button != MouseButtons.None)
                    if (wParam == WM_LBUTTONDBLCLK || wParam == WM_RBUTTONDBLCLK)
                        clickCount = 2;
                    else clickCount = 1;

                //Marshall the data from callback.
                //MouseHookStruct MyMouseHookStruct =
                //    (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                //MouseEventArgs e = new MouseEventArgs(
                //    button,
                //    clickCount,
                //    MyMouseHookStruct.pt.x,
                //    MyMouseHookStruct.pt.y,
                //    0);
                //OnMouseActivity(this, e);
            }
            //Clipboard.SetDataObject(data, true);
            return CallNextHookEx(_hMouseHook, nCode, wParam, lParam);
        }

        //The ToAscii function translates the specified virtual-key code and keyboard state to the corresponding character or characters. The function translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.

        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] Specifies the virtual-key code to be translated. 
            int uScanCode, // [in] Specifies the hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed). 
            byte[] lpbKeyState, // [in] Pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down (pressed). The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
            byte[] lpwTransKey, // [out] Pointer to the buffer that receives the translated character or characters. 
            int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise. 
        //The GetKeyboardState function copies the status of the 256 virtual keys to the specified buffer. 
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // it was ok and someone listens to events
            if ((nCode >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct =
                    (KeyboardHookStruct)Marshal.PtrToStructure(lParam,
                    typeof(KeyboardHookStruct));
                // raise KeyDown
                if (KeyDown != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDown(this, e);
                }
                // raise KeyPress
                if (KeyPress != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,
                        MyKeyboardHookStruct.scanCode,
                        keyState,
                        inBuffer,
                        MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPress(this, e);
                    }
                }
                // raise KeyUp
                if (KeyUp != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUp(this, e);
                }
            }
            return CallNextHookEx(_hKeyboardHook, nCode, wParam, lParam);
        }
    }
}


//GlobalHook hook;

//private void Form1_Load(object sender, EventArgs e)
//{
//    btnInstallHook.Enabled = true;
//    btnUnInstall.Enabled = false;
//    //初始化钩子对象
//    if (hook == null)
//    {
//        hook = new GlobalHook();
//        hook.KeyDown += new KeyEventHandler(hook_KeyDown);
//        hook.KeyPress += new KeyPressEventHandler(hook_KeyPress);
//        hook.KeyUp += new KeyEventHandler(hook_KeyUp);
//        hook.OnMouseActivity += new MouseEventHandler(hook_OnMouseActivity);
//    }
//}
//private void Form1_FormClosing(object sender, FormClosingEventArgs e)
//{
//    if (btnUnInstall.Enabled == true)
//    {
//        hook.Stop();
//    }
//}

//private void btnInstallHook_Click(object sender, EventArgs e)
//{
//    if (btnInstallHook.Enabled == true)
//    {
//        bool r = hook.Start();
//        if (r)
//        {
//            btnInstallHook.Enabled = false;
//            btnUnInstall.Enabled = true;
//            MessageBox.Show("安装钩子成功!");
//        }
//        else
//        {
//            MessageBox.Show("安装钩子失败!");
//        }
//    }
//}
//private void btnUnInstall_Click(object sender, EventArgs e)
//{
//    if (btnUnInstall.Enabled == true)
//    {
//        hook.Stop();
//        btnUnInstall.Enabled = false;
//        btnInstallHook.Enabled = true;
//        MessageBox.Show("卸载钩子成功!");
//    }
//}

///// <summary>
///// 鼠标移动事件
///// </summary>
//void hook_OnMouseActivity(object sender, MouseEventArgs e)
//{
//    lbMouseState.Text = "X:" + e.X + " Y:" + e.Y;
//}
///// <summary>
///// 键盘抬起
///// </summary>
//void hook_KeyUp(object sender, KeyEventArgs e)
//{
//    lbKeyState.Text = "键盘抬起, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
//}
///// <summary>
///// 键盘输入
///// </summary>
//void hook_KeyPress(object sender, KeyPressEventArgs e)
//{ }
///// <summary>
///// 键盘按下
///// </summary>
//void hook_KeyDown(object sender, KeyEventArgs e)
//{
//    lbKeyState.Text = "键盘按下, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
//}