using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using DimThing.Framework;
using DimThing.Framework.Configuration;

namespace DimThing
{
    public sealed class KeyboardHook : IDisposable
    {
        #region WindowsNativeMethods

        public static class NativeMethods
        {
            // Registers a hot key with Windows.
            [DllImport("user32.dll")]
            internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            // Unregisters the hot key with Windows.
            [DllImport("user32.dll")]
            internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        }

        #endregion


        /// Represents the window that is used internally to get the messages.        
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            ///     To avoid overflow on 64 bit platform use this method
            /// </summary>
            /// <param name="lParam"></param>
            /// <returns></returns>
            private long ConvertLParam(IntPtr lParam)
            {
                try
                {
                    return lParam.ToInt32();
                }
                catch (OverflowException)
                {
                    return lParam.ToInt64();
                }
            }

            /// Overridden to get the notifications.            
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    var key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    var modifier = (HotKeys.ModifierKeys) (ConvertLParam(m.LParam) & 0xFFFF);                  

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(new HotKeys(key, modifier)));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        /// <summary>
        ///     To avoid overflow on 64 bit platform use this method
        /// </summary>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private long ConvertLParam(IntPtr lParam)
        {
            try
            {
                return lParam.ToInt32();
            }
            catch (OverflowException)
            {
                return lParam.ToInt64();
            }
        }


        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }
        /// <summary>
        ///     Registers a HotKey in the system.
        /// </summary>
        /// <param name="hotKeys">Represent the hotkey to register</param>
        public void RegisterHotKey(HotKeys hotKeys)
        {
            _currentId++;
            // register the hot key.
            if (!NativeMethods.RegisterHotKey(_window.Handle, _currentId, (uint)hotKeys.Modifier, (uint)hotKeys.Keys))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }
                
        /// A hot key has been pressed.     
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                NativeMethods.UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }
       
    /// Event Args for the event that is fired after the hot key has been pressed.    
    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(HotKeys hotKeys)
        {
            HotKeys = hotKeys;
        }

        public HotKeys HotKeys { get; set; }
    }
        
    /// The enumeration of possible modifiers.    
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8,
        None = 0
    }
}

