/* 
 * Copyright (C) 2013 Ryan Sammon.
 * 
 * This file is part of the Vinesauce ROM Corruptor.
 * 
 * The Vinesauce ROM Corruptor is free software: you can redistribute
 * it and/or modify it under the terms of the GNU General Public 
 * License as published by the Free Software Foundation, either 
 * version 3 of the License, or (at your option) any later version.
 * 
 * The Vinesauce ROM Corruptor is distributed in the hope that it
 * will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the Vinesauce ROM Corruptor.  If not, see 
 * <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Vinesauce_ROM_Corruptor
{
    static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static MainForm form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _hookID = SetHook(_proc);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(form);
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys pressed = (Keys)vkCode;
                if (MainForm.HotkeyEnabled && pressed == MainForm.Hotkey)
                {
                    form.Focus();
                    switch (MainForm.HotkeyAction)
                    {
                        case HotkeyActions.AddStart:
                            form.button_StartByteUp.PerformClick();
                            break;
                        case HotkeyActions.AddEnd:
                            form.button_EndByteUp.PerformClick();
                            break;
                        case HotkeyActions.AddRange:
                            form.button_RangeUp.PerformClick();
                            break;
                        case HotkeyActions.SubStart:
                            form.button_StartByteDown.PerformClick();
                            break;
                        case HotkeyActions.SubEnd:
                            form.button_EndByteDown.PerformClick();
                            break;
                        case HotkeyActions.SubRange:
                            form.button_RangeDown.PerformClick();
                            break;
                    }
                    form.button_Run.PerformClick();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
