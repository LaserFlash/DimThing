using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace DimThing.Framework
{
    public static class KeyboardWindowsAPI
    {
        //Convert key to byte value
        private static byte Code(Keys key)
        {
            return (byte)((int)key & 0xFF);
        }

        /// <summary>
        /// Gets all keys that are currently in the down state.
        /// </summary>
        /// <returns>
        /// A collection of all keys that are currently in the down state.
        /// </returns>
        public static IEnumerable<Keys> GetPressedKeys()
        {
            var keyboardState = new byte[256];
            NativeMethods.GetKeyboardState(keyboardState);

            return Enum.GetValues(typeof(Keys)).Cast<Keys>().Where(key => (keyboardState[Code(key)] & 0x80) != 0).ToList();
        }

        /// <summary>
        /// Get the pressed modifiers
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Keys> GetPressedModifiers()
        {
            return
                GetPressedKeys().Select(key =>
                {
                    if (key == Keys.LWin)
                    {
                        return Keys.LWin;
                    }
                    if (key == Keys.RWin)
                    {
                        return Keys.LWin;
                    }
                    if (key == Keys.Menu)
                    {
                        return Keys.Alt;
                    }
                    if (key == Keys.LMenu)
                    {
                        return Keys.Alt;
                    }
                    if (key == Keys.RMenu)
                    {
                        return Keys.Alt;
                    }
                    if (key == Keys.ControlKey)
                    {
                        return Keys.Control;
                    }
                    if (key == Keys.LControlKey)
                    {
                        return Keys.Control;
                    }
                    if (key == Keys.RControlKey)
                    {
                        return Keys.Control;
                    }
                    if (key == Keys.ShiftKey)
                    {
                        return Keys.Shift;
                    }
                    if (key == Keys.LShiftKey)
                    {
                        return Keys.Shift;
                    }
                    if (key == Keys.RShiftKey)
                    {
                        return Keys.Shift;
                    }
                    return Keys.None;
                }).Distinct();
        }
        private static bool IsModifier(Keys key)
        {
            return (key == Keys.LWin) || (key == Keys.RWin) ||
                   (key == Keys.Menu) || (key == Keys.ControlKey) ||
                   (key == Keys.ShiftKey) ||
                   (key == Keys.LMenu) || (key == Keys.LControlKey) ||
                   (key == Keys.LShiftKey) ||
                   (key == Keys.RMenu) || (key == Keys.RControlKey) ||
                   (key == Keys.RShiftKey);
        }

        /// <summary>
        /// Get pressed keys that aren't modifiers
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Keys> GetNormalPressedKeys()
        {
            return GetPressedKeys().Where(key => !IsModifier(key)).ToList();
        }

        #region WindowsNativeMethods

        public static class NativeMethods
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetKeyboardState(byte[] lpKeyState);
        }

        #endregion
    }
}
