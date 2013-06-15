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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Net;

namespace Vinesauce_ROM_Corruptor
{
    public enum HotkeyActions
    {
        AddStart,
        AddEnd,
        AddRange,
        SubStart,
        SubEnd,
        SubRange
    }

    public partial class MainForm : Form
    {
        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        static private Process Emulator = null;

        static private List<byte> NESCPUJamProtection_Avoid = new List<byte>() { 0x48, 0x08, 0x68, 0x28, 0x78, 0x00, 0x02, 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72, 0x92, 0xB2, 0xD2, 0xF2 };
        static private List<byte> NESCPUJamProtection_Protect_1 = new List<byte>() { 0x48, 0x08, 0x68, 0x28, 0x78, 0x40, 0x60, 0x00, 0x90, 0xB0, 0xF0, 0x30, 0xD0, 0x10, 0x50, 0x70, 0x4C, 0x6C, 0x20 };
        static private List<byte> NESCPUJamProtection_Protect_2 = new List<byte>() { 0x90, 0xB0, 0xF0, 0x30, 0xD0, 0x10, 0x50, 0x70, 0x4C, 0x6C, 0x20 };
        static private List<byte> NESCPUJamProtection_Protect_3 = new List<byte>() { 0x4C, 0x6C, 0x20 };

        static public Keys Hotkey = Keys.Space;
        static public HotkeyActions HotkeyAction = HotkeyActions.AddStart;
        static public bool HotkeyEnabled = false;

        static private RomId SelectedROM = null;

        static private string SettingSaveDirectory = "";

        public MainForm()
        {
            InitializeComponent();

            // Try to load the save location and emulator to run.
            try
            {
                string text = File.ReadAllText("VinesauceROMCorruptor.txt");
                Match m = Regex.Match(text, "(?<=textBox_RomDirectory\\.Text=).*?(?=\r)");
                if (m.Success)
                {
                    textBox_RomDirectory.Text = m.Groups[0].Value;
                }
                m = Regex.Match(text, "(?<=textBox_SaveLocation\\.Text=).*?(?=\r)");
                if (m.Success)
                {
                    textBox_SaveLocation.Text = m.Groups[0].Value;
                }
                m = Regex.Match(text, "(?<=textBox_EmulatorToRun\\.Text=).*?(?=\r)");
                if (m.Success)
                {
                    textBox_EmulatorToRun.Text = m.Groups[0].Value;
                }
                m = Regex.Match(text, "(?<=SettingSaveDirectory=).*?(?=\r)");
                if (m.Success)
                {
                    SettingSaveDirectory = m.Groups[0].Value;
                }
                m = Regex.Match(text, "(?<=HotkeyEnabled=).*?(?=\r)");
                if (m.Success)
                {
                    checkBox_HotkeyEnable.Checked = bool.Parse(m.Groups[0].Value);
                }
                m = Regex.Match(text, "(?<=Hotkey=).*?(?=\r)");
                if (m.Success)
                {
                    Hotkey = (Keys)Enum.Parse(typeof(Keys), m.Groups[0].Value, false);
                }
                m = Regex.Match(text, "(?<=HotkeyAction=).*?(?=\r)");
                if (m.Success)
                {
                    HotkeyAction = (HotkeyActions)Enum.Parse(typeof(HotkeyActions), m.Groups[0].Value, false);
                }
                PopulateFileList();
            }
            catch
            {
                // Do nothing, stop exception.
            }
        }

        private void button_RomToCorruptBrowse_Click(object sender, EventArgs e)
        {
            listView_Files.Focus();
            FolderBrowserDialog fDialog = new FolderBrowserDialog();
            fDialog.Description = "Select ROM Directory";
            fDialog.SelectedPath = textBox_RomDirectory.Text;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_RomDirectory.Text = fDialog.SelectedPath;
                PopulateFileList();
            }
        }

        private void button_SaveLocationBrowse_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.CheckPathExists = true;
            fDialog.DefaultExt = "rom";
            fDialog.FileName = "CorruptedROM";
            fDialog.AddExtension = true;
            fDialog.OverwritePrompt = false;
            fDialog.Title = "Select Save Location for Corrupted ROM";
            fDialog.Filter = "All files (*.*)|*.*";
            try
            {
                fDialog.InitialDirectory = Path.GetDirectoryName(textBox_SaveLocation.Text);
            }
            catch
            {
                fDialog.InitialDirectory = "";
            }

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_SaveLocation.Text = fDialog.FileName;
                PopulateFileList();
            }
            textBox_SaveLocation.SelectionStart = textBox_SaveLocation.Text.Length;
            textBox_SaveLocation.ScrollToCaret();
        }

        private void checkBox_RunEmulator_CheckedChanged(object sender, EventArgs e)
        {
            label_EmulatorToRun.Enabled = checkBox_RunEmulator.Checked;
            textBox_EmulatorToRun.Enabled = checkBox_RunEmulator.Checked;
            button_EmulatorToRunBrowse.Enabled = checkBox_RunEmulator.Checked;
        }

        private void button_EmulatorToRunBrowse_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select Emulator to Run";
            fDialog.Filter = "Executable Files|*.exe";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            try
            {
                fDialog.InitialDirectory = Path.GetDirectoryName(textBox_EmulatorToRun.Text);
            }
            catch
            {
                fDialog.InitialDirectory = "";
            }

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_EmulatorToRun.Text = fDialog.FileName.ToString();
            }
            textBox_EmulatorToRun.SelectionStart = textBox_EmulatorToRun.Text.Length;
            textBox_EmulatorToRun.ScrollToCaret();
        }

        private void button_AnchorWordsHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Enter a few sections of text that you know exist within the ROM, separated by pipes ( | ). These text sections are used to automatically build a translation table.",
                "Anchor Words Help");
        }

        private void checkBox_TextReplacementEnable_CheckedChanged(object sender, EventArgs e)
        {
            label_AnchorWords.Enabled = checkBox_TextReplacementEnable.Checked;
            textBox_AnchorWords.Enabled = checkBox_TextReplacementEnable.Checked;
            label_TextToReplace.Enabled = checkBox_TextReplacementEnable.Checked;
            textBox_TextToReplace.Enabled = checkBox_TextReplacementEnable.Checked;
            label_ReplaceWith.Enabled = checkBox_TextReplacementEnable.Checked;
            textBox_ReplaceWith.Enabled = checkBox_TextReplacementEnable.Checked;
            checkBox_TextUseByteCorruptionRange.Enabled = checkBox_TextReplacementEnable.Checked && checkBox_ByteCorruptionEnable.Checked;
            checkBox_TextUseByteCorruptionRange.Checked = false;
        }

        private void button_TextToReplaceHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Enter sections of text to replace, separated by pipes ( | ). Be aware that small sections of text will cause more collateral corruption than large sections of text. Non-letter characters will match any value.",
                "Text To Replace Help");
        }

        private void button_ReplaceWithHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Enter what to replace the matching sections of text with, separated by pipes ( | ). The number of sections of text entered here must match the number to replace. The size of the text to replace and the replacement may differ.",
                "Replace With Help");
        }

        public void button_Run_Click(object sender, EventArgs e)
        {
            // Check that we can write to the file.
            if (File.Exists(textBox_SaveLocation.Text) && !checkBox_Overwrite.Checked)
            {
                if (!checkBox_Overwrite.Checked)
                {
                    MessageBox.Show("File to save to exists and overwrite is not enabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Check that a ROM is selected.
            if (SelectedROM == null)
            {
                MessageBox.Show("No ROM is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the ROM in.
            byte[] ROM = SelectedROM.Load();
            if (ROM == null)
            {
                MessageBox.Show("Error reading ROM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBox_QueueEnable.Checked)
            {
                QueueForm.CorruptionQueue.Add(new string[] { "Current", CorruptionSettingsToString() });
                foreach (string[] Entry in QueueForm.CorruptionQueue)
                {
                    StringToCorruptionSettings(Entry[1]);
                    ROM = Corrupt(ROM);
                    if (ROM == null)
                    {
                        MessageBox.Show("Previous error encountered corrupting using \"" + Entry[0] + "\" corruption settings in queue.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StringToCorruptionSettings(QueueForm.CorruptionQueue[QueueForm.CorruptionQueue.Count - 1][1]);
                        QueueForm.CorruptionQueue.RemoveAt(QueueForm.CorruptionQueue.Count - 1);
                        return;
                    }
                }
                StringToCorruptionSettings(QueueForm.CorruptionQueue[QueueForm.CorruptionQueue.Count - 1][1]);
                QueueForm.CorruptionQueue.RemoveAt(QueueForm.CorruptionQueue.Count - 1);
            }
            else
            {
                ROM = Corrupt(ROM);
                if (ROM == null)
                {
                    return;
                }
            }

            // Write the file.
            try
            {
                File.WriteAllBytes(textBox_SaveLocation.Text, ROM);
            }
            catch
            {
                MessageBox.Show("Error saving corrupted ROM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start the emulator if desired.
            if (checkBox_RunEmulator.Checked)
            {
                if (textBox_EmulatorToRun.Text == "")
                {
                    MessageBox.Show("No emulator path given.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // See if the emulator is already running.
                    Emulator = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(textBox_EmulatorToRun.Text))[0];

                    // It is, get its current position and kill.
                    RECT EmulatorPosition;
                    GetWindowRect(Emulator.MainWindowHandle, out EmulatorPosition);
                    Emulator.Kill();
                    Emulator.WaitForExit();

                    // Attempt to restart.
                    try
                    {
                        Emulator = Process.Start("\"" + textBox_EmulatorToRun.Text + "\"", "\"" + textBox_SaveLocation.Text + "\"");
                    }
                    catch
                    {
                        MessageBox.Show("Error starting emulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Delay to let the process start.
                    Emulator.WaitForInputIdle();
                    Thread.Sleep(500);

                    // Move the window to its previous location.
                    MoveWindow(Emulator.MainWindowHandle, EmulatorPosition.Left, EmulatorPosition.Top, EmulatorPosition.Right - EmulatorPosition.Left, EmulatorPosition.Bottom - EmulatorPosition.Top, true);
                }
                catch
                {
                    // Its not, just try to start the emulator.
                    try
                    {
                        Emulator = Process.Start("\"" + textBox_EmulatorToRun.Text + "\"", "\"" + textBox_SaveLocation.Text + "\"");
                    }
                    catch
                    {
                        MessageBox.Show("Error starting emulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void checkBox_ByteCorruptionEnable_CheckedChanged(object sender, EventArgs e)
        {
            label_EndByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_StartByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_Increment.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_EveryNBytes1.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_EveryNBytes2.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_AddXToByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_ReplaceByteXwithY.Enabled = checkBox_ByteCorruptionEnable.Checked;
            label_ShiftRightXBytes.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_EndByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_StartByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_Increment.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_EveryNBytes.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_AddXToByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_ShiftRightXBytes.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_ReplaceByteXwithYByteX.Enabled = checkBox_ByteCorruptionEnable.Checked;
            textBox_ReplaceByteXwithYByteY.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_EndByteUp.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_EndByteDown.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_StartByteUp.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_StartByteDown.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_RangeUp.Enabled = checkBox_ByteCorruptionEnable.Checked;
            button_RangeDown.Enabled = checkBox_ByteCorruptionEnable.Checked;
            radioButton_AddXToByte.Enabled = checkBox_ByteCorruptionEnable.Checked;
            radioButton_ShiftRightXBytes.Enabled = checkBox_ByteCorruptionEnable.Checked;
            radioButton_ReplaceByteXwithY.Enabled = checkBox_ByteCorruptionEnable.Checked;
            checkBox_AutoEnd.Enabled = checkBox_ByteCorruptionEnable.Checked;
            checkBox_AutoEnd.Checked = false;
            checkBox_TextUseByteCorruptionRange.Enabled = checkBox_TextReplacementEnable.Checked && checkBox_ByteCorruptionEnable.Checked;
            checkBox_ColorUseByteCorruptionRange.Enabled = checkBox_ColorReplacementEnable.Checked && checkBox_ByteCorruptionEnable.Checked;
            checkBox_TextUseByteCorruptionRange.Checked = false;
            checkBox_ColorUseByteCorruptionRange.Checked = false;
            checkBox_EnableNESCPUJamProtection.Enabled = checkBox_ByteCorruptionEnable.Checked;
            checkBox_EnableNESCPUJamProtection.Checked = false;
        }

        private void button_IncrementHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("The value that '+' and '-' buttons will change the start and end bytes by in hexadecimal.",
                "Increment Help");
        }

        private void button_RangeHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("The first and last byte to consider for corruption, in hexadecimal. Starting corruption too close to the beginning of the ROM can make it fail to run.",
                "Range Help");
        }

        private void button_AutoEndHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When checked, corruption will go until the end of the ROM.",
                "Auto End Help");
        }

        private void EnforceAutoEnd()
        {
            if (SelectedROM != null && checkBox_AutoEnd.Checked)
            {
                long StartByte;
                try
                {
                    StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
                }
                catch
                {
                    MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBox_AutoEnd.Checked = false;
                    return;
                }

                long MaxByte = SelectedROM.FileLength - 1;
                if (StartByte > MaxByte)
                {
                    StartByte = MaxByte;
                    textBox_StartByte.Text = MaxByte.ToString("X");
                }
                textBox_EndByte.Text = MaxByte.ToString("X");
            }
        }

        private void checkBox_AutoEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ByteCorruptionEnable.Checked)
            {
                label_EndByte.Enabled = !checkBox_AutoEnd.Checked;
                textBox_EndByte.Enabled = !checkBox_AutoEnd.Checked;
                button_EndByteUp.Enabled = !checkBox_AutoEnd.Checked;
                button_EndByteDown.Enabled = !checkBox_AutoEnd.Checked;
                button_RangeUp.Enabled = !checkBox_AutoEnd.Checked;
                button_RangeDown.Enabled = !checkBox_AutoEnd.Checked;
            }

            EnforceAutoEnd();
        }

        private void button_StartByteUp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartByte = StartByte + Increment;
            if (StartByte > EndByte)
            {
                StartByte = EndByte;
            }
            textBox_StartByte.Text = StartByte.ToString("X");
        }

        private void button_StartByteDown_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartByte = StartByte - Increment;
            if (StartByte < 0)
            {
                StartByte = 0;
            }
            textBox_StartByte.Text = StartByte.ToString("X");
        }

        private void button_EndByteUp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EndByte = EndByte + Increment;
            textBox_EndByte.Text = EndByte.ToString("X");
        }

        private void button_EndByteDown_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EndByte = EndByte - Increment;
            if (EndByte < StartByte)
            {
                EndByte = StartByte;
            }
            textBox_EndByte.Text = EndByte.ToString("X");
        }

        private void button_RangeUp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartByte = StartByte + Increment;
            EndByte = EndByte + Increment;
            textBox_StartByte.Text = StartByte.ToString("X");
            textBox_EndByte.Text = EndByte.ToString("X");
        }

        private void button_RangeDown_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Increment;
            try
            {
                Increment = Convert.ToInt64(textBox_Increment.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid increment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long Difference = EndByte - StartByte;
            StartByte = StartByte - Increment;
            if (StartByte < 0)
            {
                StartByte = 0;
                EndByte = Difference;
            }
            else
            {
                EndByte = EndByte - Increment;
            }
            textBox_StartByte.Text = StartByte.ToString("X");
            textBox_EndByte.Text = EndByte.ToString("X");
        }

        private void button_EveryNBytesHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("This decimal value specifies how often to corrupt bytes in the ROM. A value of one will corrupt every byte, a value of two will corrupt every second byte, and so on.",
                "Every Nth Byte Help");
        }

        private void button_AddXToByteHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this option is selected, this decimal value is added to each byte selected for corruption.",
                "Add X to Byte Help");
        }

        private void button_NESPaletteHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("This table shows the hexadecimal values of all of the colors available on the NES. The row indicates the most significant nibble of the byte, while the column indicates the least significant nibble of the byte. Therefore, valid hexadecimal color values range from 00 to 3F.",
                "NES Palette Help");
        }

        private void button_ColorsToReplaceHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Enter the hexadecimal values of the colors to replace separated by pipes ( | ).",
                "Colors to Replace Help");
        }

        private void button_ReplaceWithColorsHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Enter the hexadecimal values of the colors to replace the matching colors with, separated by pipes ( | ). The number of colors to match must equal the number of replacements.",
                "Color Replace With Help");
        }

        private void checkBox_ColorReplacementEnable_CheckedChanged(object sender, EventArgs e)
        {
            label_ColorsToReplace.Enabled = checkBox_ColorReplacementEnable.Checked;
            label_ReplaceWithColors.Enabled = checkBox_ColorReplacementEnable.Checked;
            textBox_ColorsToReplace.Enabled = checkBox_ColorReplacementEnable.Checked;
            textBox_ReplaceWithColors.Enabled = checkBox_ColorReplacementEnable.Checked;
            checkBox_ColorUseByteCorruptionRange.Enabled = checkBox_ColorReplacementEnable.Checked && checkBox_ByteCorruptionEnable.Checked;
            checkBox_ColorUseByteCorruptionRange.Checked = false;
        }

        private void button_TextUseByteCorruptionRangeHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("If byte corruption is enabled, this option will be available. Checking this box causes the text replacement to only consider bytes in the range specified for byte corruption. This is useful if text replacement is causing too much colatteral corruption.",
                "Text Replacement Use Byte Corruption Range Help");
        }

        private void button_ColorUseByteCorruptionRangeHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("If byte corruption is enabled, this option will be available. Checking this box causes the color replacement to only consider bytes in the range specified for byte corruption. This is useful if color replacement is causing too much colatteral corruption.",
                "Color Replacement Use Byte Corruption Range Help");
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            if (checkBox_UseTinyURL.Checked)
            {
                // Get the name of the paste from user.
                string name = Interaction.InputBox("Please enter a brief description of these corruption settings below.", "Save to TinyURL", "");
                if (name == "")
                {
                    MessageBox.Show("No description entered, save to TinyURL aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string response = "";
                try
                {
                    // Create a TinyURL.
                    System.Net.WebClient wc = new System.Net.WebClient();
                    UriBuilder ub = new UriBuilder();
                    ub.Host = "tinyurl.com";
                    ub.Path = "/api-create.php";
                    ub.Query = "url=" + FileSettingsToString() + CorruptionSettingsToString() + QueueSettingsToString();
                    response = wc.DownloadString(ub.Uri);
                }
                catch
                {
                    MessageBox.Show("Error saving to TinyURL. Please retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Handle the response.
                if (response.Contains("http://tinyurl.com/"))
                {
                    System.Windows.Forms.Clipboard.SetDataObject(response, true);
                    MessageBox.Show("TinyURL:\n\n" + response + "\n\nCopied to clipboard.", "Saved to TinyURL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save to TinyURL failed. Reason: " + response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add to list of TinyURL saves.
                try
                {
                    // Open the file to write to.
                    StreamWriter sw = new StreamWriter("TinyURLs.txt", true);

                    // Write the save location and emulator to run.
                    sw.WriteLine(response + " (" + name + ")");

                    // Close the file.
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Error adding to list of TinyURLs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                SaveFileDialog fDialog = new SaveFileDialog();
                fDialog.CheckPathExists = true;
                fDialog.DefaultExt = "txt";
                fDialog.FileName = "CorruptionSettings";
                fDialog.AddExtension = true;
                fDialog.OverwritePrompt = true;
                fDialog.Title = "Select Save Location for Corruption Settings";
                fDialog.Filter = "Text Documents (*.txt)|*.txt";
                fDialog.InitialDirectory = SettingSaveDirectory;

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Open the file to write to.
                        StreamWriter sw = new StreamWriter(fDialog.FileName);

                        // Write the settings to the file.
                        sw.Write(FileSettingsToString() + CorruptionSettingsToString() + QueueSettingsToString());

                        // Close the file.
                        sw.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error saving corruption settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        SettingSaveDirectory = Path.GetDirectoryName(fDialog.FileName);
                    }
                    catch
                    {
                        SettingSaveDirectory = "";
                    }
                }
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            if (checkBox_UseTinyURL.Checked)
            {
                // Get the TinyURL from the user.
                string url = Interaction.InputBox("Please enter the TinyURL to load below.", "Load from TinyURL", "");
                if (url == "")
                {
                    MessageBox.Show("No TinyURL entered, load from TinyURL aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Make the request.
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "HEAD";
                    request.AllowAutoRedirect = false;

                    // Get the response.
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string text = response.GetResponseHeader("Location");
                    response.Close();

                    // Unescape the text.
                    text = Uri.UnescapeDataString(text);

                    // Load the settings.
                    StringToFileSettings(text);
                    StringToCorruptionSettings(text);
                    QueueForm.CorruptionQueue.Clear();
                    StringToQueueSettings(text, "");
                    EnforceAutoEnd();
                }
                catch
                {
                    MessageBox.Show("Error loading from TinyURL. Please ensure the TinyURL is correct and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Select Corruption Settings to Load";
                fDialog.Filter = "Text Documents (*.txt)|*.txt";
                fDialog.CheckFileExists = true;
                fDialog.CheckPathExists = true;
                fDialog.InitialDirectory = SettingSaveDirectory;

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the settings from the file.
                        string text = File.ReadAllText(fDialog.FileName);
                        StringToFileSettings(text);
                        StringToCorruptionSettings(text);
                        QueueForm.CorruptionQueue.Clear();
                        StringToQueueSettings(text, "");
                        EnforceAutoEnd();
                    }
                    catch
                    {
                        MessageBox.Show("Error loading corruption settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        SettingSaveDirectory = Path.GetDirectoryName(fDialog.FileName);
                    }
                    catch
                    {
                        SettingSaveDirectory = "";
                    }
                }
            }
        }

        private void button_ShiftRightXBytesHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this option is selected, each byte selected for corruption is shifted right by the number of bytes specified by this decimal value. This value can be negative, resulting in a shift to the left.",
                "Shift Right X Bytes Help");
        }

        private void button_ReplaceByteXwithYHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this option is selected, each byte selected for corruption is compared to the first hexadecimal value. If it matches, it is replaced by the second hexadecimal value.",
                "Replace Byte X with Y Help");
        }

        private string FileSettingsToString()
        {
            StringBuilder sb = new StringBuilder();

            // ROM to corrupt.
            SelectedROM.ComputeHash();
            sb.AppendLine("ROM.FileName=" + SelectedROM.FileName);
            sb.AppendLine("ROM.FileLength=" + String.Format("{0:X}", SelectedROM.FileLength));
            sb.AppendLine("ROM.Hash=" + SelectedROM.HashStringBase64);

            return sb.ToString();
        }

        private string CorruptionSettingsToString()
        {
            StringBuilder sb = new StringBuilder();

            // General settings.
            sb.AppendLine("checkBox_EnableNESCPUJamProtection.Checked=" + checkBox_EnableNESCPUJamProtection.Checked.ToString());

            // Text replacement settings.
            sb.AppendLine("checkBox_TextReplacementEnable.Checked=" + checkBox_TextReplacementEnable.Checked.ToString());
            sb.AppendLine("checkBox_TextUseByteCorruptionRange.Checked=" + checkBox_TextUseByteCorruptionRange.Checked.ToString());
            sb.AppendLine("textBox_AnchorWords.Text=" + textBox_AnchorWords.Text);
            sb.AppendLine("textBox_TextToReplace.Text=" + textBox_TextToReplace.Text);
            sb.AppendLine("textBox_ReplaceWith.Text=" + textBox_ReplaceWith.Text);

            // Color replacement settings.
            sb.AppendLine("checkBox_ColorReplacementEnable.Checked=" + checkBox_ColorReplacementEnable.Checked.ToString());
            sb.AppendLine("checkBox_ColorUseByteCorruptionRange.Checked=" + checkBox_ColorUseByteCorruptionRange.Checked.ToString());
            sb.AppendLine("textBox_ColorsToReplace.Text=" + textBox_ColorsToReplace.Text);
            sb.AppendLine("textBox_ReplaceWithColors.Text=" + textBox_ReplaceWithColors.Text);

            // Byte corruption settings.
            sb.AppendLine("checkBox_ByteCorruptionEnable.Checked=" + checkBox_ByteCorruptionEnable.Checked.ToString());
            sb.AppendLine("checkBox_AutoEnd.Checked=" + checkBox_AutoEnd.Checked.ToString());
            sb.AppendLine("radioButton_AddXToByte.Checked=" + radioButton_AddXToByte.Checked.ToString());
            sb.AppendLine("radioButton_ShiftRightXBytes.Checked=" + radioButton_ShiftRightXBytes.Checked.ToString());
            sb.AppendLine("radioButton_ReplaceByteXwithY.Checked=" + radioButton_ReplaceByteXwithY.Checked.ToString());
            sb.AppendLine("textBox_StartByte.Text=" + textBox_StartByte.Text);
            sb.AppendLine("textBox_EndByte.Text=" + textBox_EndByte.Text);
            sb.AppendLine("textBox_Increment.Text=" + textBox_Increment.Text);
            sb.AppendLine("textBox_EveryNBytes.Text=" + textBox_EveryNBytes.Text);
            sb.AppendLine("textBox_AddXToByte.Text=" + textBox_AddXToByte.Text);
            sb.AppendLine("textBox_ShiftRightXBytes.Text=" + textBox_ShiftRightXBytes.Text);
            sb.AppendLine("textBox_ReplaceByteXwithYByteX.Text=" + textBox_ReplaceByteXwithYByteX.Text);
            sb.AppendLine("textBox_ReplaceByteXwithYByteY.Text=" + textBox_ReplaceByteXwithYByteY.Text);

            return sb.ToString();
        }

        private string QueueSettingsToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("checkBox_QueueEnable.Checked=" + checkBox_QueueEnable.Checked.ToString());

            foreach (string[] Entry in QueueForm.CorruptionQueue)
            {

                sb.AppendLine("Queue_Entry_Start");
                sb.AppendLine("Identifier=" + Entry[0]);
                sb.Append(Entry[1]);
                sb.AppendLine("Queue_Entry_End");
            }

            return sb.ToString();
        }

        private void StringToFileSettings(string text)
        {
            // ROM to corrupt.
            string TargetROMFileName = "";
            long TargetROMFileLength = 0;
            byte[] TargetROMHash = null;
            Match m = Regex.Match(text, "(?<=ROM\\.FileName=).*?(?=\r)");
            if (m.Success)
            {
                TargetROMFileName = Path.GetFileName(m.Groups[0].Value);
            }
            m = Regex.Match(text, "(?<=ROM\\.FileLength=).*?(?=\r)");
            if (m.Success)
            {
                TargetROMFileLength = Convert.ToInt64(m.Groups[0].Value, 16);
            }
            m = Regex.Match(text, "(?<=ROM\\.Hash=).*?(?=\r)");
            if (m.Success)
            {
                TargetROMHash = Convert.FromBase64String(m.Groups[0].Value);
            }

            // Backwards compatibility.
            if (TargetROMFileName == "")
            {
                m = Regex.Match(text, "(?<=textBox_RomToCorrupt\\.Text=).*?(?=\r)");
                if (m.Success)
                {
                    TargetROMFileName = Path.GetFileName(m.Groups[0].Value);
                }
            }

            // Select the ROM.
            bool success = false;
            if (TargetROMHash != null)
            {
                success = SelectROMWithFileLengthAndHash(TargetROMFileLength, TargetROMHash);
            }
            if (!success && TargetROMFileName != "")
            {
                success = SelectROMWithFileName(TargetROMFileName);
                if (success)
                {
                    MessageBox.Show("The ROM selected was matched on the name of the file, not its hash. This file may be different than the intended corruption target file.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No ROM matching the target hash or name could be found in the selected directory. Please select the correct directory and load the corruption settings again.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void StringToCorruptionSettings(string text)
        {
            // Enable checkboxes.
            // Text replacement.
            Match m = Regex.Match(text, "(?<=checkBox_TextReplacementEnable\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_TextReplacementEnable.Checked = true;
                }
                else
                {
                    checkBox_TextReplacementEnable.Checked = false;
                }
            }
            // Color replacement.
            m = Regex.Match(text, "(?<=checkBox_ColorReplacementEnable\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_ColorReplacementEnable.Checked = true;
                }
                else
                {
                    checkBox_ColorReplacementEnable.Checked = false;
                }
            }
            // Byte corruption.
            m = Regex.Match(text, "(?<=checkBox_ByteCorruptionEnable\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_ByteCorruptionEnable.Checked = true;
                }
                else
                {
                    checkBox_ByteCorruptionEnable.Checked = false;
                }
            }

            // Use byte corruption range checkboxes.
            // Text replacement.
            m = Regex.Match(text, "(?<=checkBox_TextUseByteCorruptionRange\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_TextUseByteCorruptionRange.Checked = true;
                }
                else
                {
                    checkBox_TextUseByteCorruptionRange.Checked = false;
                }
            }
            // Color replacement.
            m = Regex.Match(text, "(?<=checkBox_ColorUseByteCorruptionRange\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_ColorUseByteCorruptionRange.Checked = true;
                }
                else
                {
                    checkBox_ColorUseByteCorruptionRange.Checked = false;
                }
            }

            // Text boxes.
            // Text replacement.
            m = Regex.Match(text, "(?<=textBox_AnchorWords\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_AnchorWords.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_TextToReplace\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_TextToReplace.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_ReplaceWith\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ReplaceWith.Text = m.Groups[0].Value;
            }
            // Color replacement.
            m = Regex.Match(text, "(?<=textBox_ColorsToReplace\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ColorsToReplace.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_ReplaceWithColors\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ReplaceWithColors.Text = m.Groups[0].Value;
            }
            // Byte corruption.
            m = Regex.Match(text, "(?<=textBox_StartByte\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_StartByte.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_EndByte\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_EndByte.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_Increment\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_Increment.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_EveryNBytes\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_EveryNBytes.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_AddXToByte\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_AddXToByte.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_ShiftRightXBytes\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ShiftRightXBytes.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_ReplaceByteXwithYByteX\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ReplaceByteXwithYByteX.Text = m.Groups[0].Value;
            }
            m = Regex.Match(text, "(?<=textBox_ReplaceByteXwithYByteY\\.Text=).*?(?=\r)");
            if (m.Success)
            {
                textBox_ReplaceByteXwithYByteY.Text = m.Groups[0].Value;
            }

            // Checkboxes.
            // Byte corruption.
            m = Regex.Match(text, "(?<=checkBox_AutoEnd\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_AutoEnd.Checked = true;
                }
                else
                {
                    checkBox_AutoEnd.Checked = false;
                }
            }
            m = Regex.Match(text, "(?<=checkBox_EnableNESCPUJamProtection\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_EnableNESCPUJamProtection.Checked = true;
                }
                else
                {
                    checkBox_EnableNESCPUJamProtection.Checked = false;
                }
            }

            // Radio buttons.
            // Byte corruption.
            // If a byte corruption radio button is checked in the save file.
            bool ByteCorruptionRadioButtonChecked = false;
            m = Regex.Match(text, "(?<=radioButton_AddXToByte\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    ByteCorruptionRadioButtonChecked = true;
                    radioButton_AddXToByte.Checked = true;
                }
                else
                {
                    radioButton_AddXToByte.Checked = false;
                }
            }
            if (!ByteCorruptionRadioButtonChecked)
            {
                m = Regex.Match(text, "(?<=radioButton_ShiftRightXBytes\\.Checked=).*?(?=\r)");
                if (m.Success)
                {
                    if (m.Groups[0].Value == "True")
                    {
                        ByteCorruptionRadioButtonChecked = true;
                        radioButton_ShiftRightXBytes.Checked = true;
                    }
                    else
                    {
                        radioButton_ShiftRightXBytes.Checked = false;
                    }
                }
            }
            if (!ByteCorruptionRadioButtonChecked)
            {
                m = Regex.Match(text, "(?<=radioButton_ReplaceByteXwithY\\.Checked=).*?(?=\r)");
                if (m.Success)
                {
                    if (m.Groups[0].Value == "True")
                    {
                        ByteCorruptionRadioButtonChecked = true;
                        radioButton_ReplaceByteXwithY.Checked = true;
                    }
                    else
                    {
                        radioButton_ReplaceByteXwithY.Checked = false;
                    }
                }
            }
            // If a checked radio button was not found, set to default.
            if (!ByteCorruptionRadioButtonChecked)
            {
                radioButton_AddXToByte.Checked = true;
            }
        }

        public void StringToQueueSettings(string text, string filename)
        {
            Match m = Regex.Match(text, "(?<=checkBox_QueueEnable\\.Checked=).*?(?=\r)");
            if (m.Success)
            {
                if (m.Groups[0].Value == "True")
                {
                    checkBox_QueueEnable.Checked = true;
                }
                else
                {
                    checkBox_QueueEnable.Checked = false;
                }
            }

            MatchCollection entries = Regex.Matches(text, "(?<=Queue_Entry_Start\r\n).*?(?=Queue_Entry_End\r\n)", RegexOptions.Singleline);
            foreach (Match entry in entries)
            {
                if (entry.Success)
                {
                    string id = "";
                    m = Regex.Match(entry.Groups[0].Value, "(?<=Identifier=).*?(?=\r)");
                    if (m.Success)
                    {
                        id = m.Groups[0].Value;
                    }

                    if (filename == "")
                    {
                        QueueForm.CorruptionQueue.Add(new string[] { id, entry.Groups[0].Value });
                    }
                    else
                    {
                        QueueForm.CorruptionQueue.Add(new string[] { filename + ":" + id, entry.Groups[0].Value });
                    }
                }
            }
        }

        private void button_UseTinyURLHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this box is checked, saving and loading is done to and from TinyURLs. All of the corruption settings are stored in the TinyURL conversion. Please be aware that these TinyURLs will not display anything useful in a web browser. To help keep track of TinyURLs you save, a list is kept in \"TinyURLs.txt\" in the same directory as this program.",
                "Use TinyURL Help");
        }

        private void button_EnableNESCPUJamProtectionHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this box is checked, certain byte values that are known important operations in the NES assembly language are protected. Furthermore, the program avoids changing bytes to certain byte values that are known to cause NES CPU jams. In general, this should result in more stable results at the cost of some corruption.",
                "NES CPU Jam Protection Help");
        }

        private void button_HotkeyHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("When this box is checked, a hotkey is enabled that will change the byte corruption range, corrupt the ROM, close the emulator, and re-run the ROM. This is useful for quickly attempting many corruptions. The default hotkey is the spacebar, but can be set to any key via the \"...\" button."
                + " The default change to the byte corruption range is to add the increment to the start byte, but can be set to one of six actions via the \"...\" button",
                "Hotkey Help");
        }

        private void button_HotkeySet_Click(object sender, EventArgs e)
        {
            HotkeyForm form = new HotkeyForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            while (form.Visible == true)
                this.Enabled = false;
        }

        private void checkBox_HotkeyEnable_CheckedChanged(object sender, EventArgs e)
        {
            button_HotkeySet.Enabled = checkBox_HotkeyEnable.Checked;
            HotkeyEnabled = checkBox_HotkeyEnable.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Record the save location and emulator to run.
            try
            {
                // Open the file to write to.
                StreamWriter sw = new StreamWriter("VinesauceROMCorruptor.txt", false);

                // Write the save location and emulator to run.
                sw.WriteLine("textBox_RomDirectory.Text=" + textBox_RomDirectory.Text);
                sw.WriteLine("textBox_SaveLocation.Text=" + textBox_SaveLocation.Text);
                sw.WriteLine("textBox_EmulatorToRun.Text=" + textBox_EmulatorToRun.Text);
                sw.WriteLine("SettingSaveDirectory=" + SettingSaveDirectory);
                sw.WriteLine("HotkeyEnabled=" + checkBox_HotkeyEnable.Checked);
                sw.WriteLine("Hotkey=" + Hotkey);
                sw.WriteLine("HotkeyAction=" + HotkeyAction);

                // Close the file.
                sw.Close();
            }
            catch
            {
                // Do nothing, stop exception.
            }
        }

        private void PopulateFileList()
        {
            string[] FilePaths;
            try
            {
                FilePaths = Directory.GetFiles(textBox_RomDirectory.Text);
            }
            catch
            {
                return;
            }

            listView_Files.Items.Clear();
            listView_Files.Focus();
            if (FilePaths.Length > 0)
            {
                foreach (string FilePath in FilePaths)
                {
                    if (FilePath != textBox_SaveLocation.Text)
                    {
                        RomId id = new RomId(FilePath);
                        if (id.FileLength > 0)
                        {
                            listView_Files.Items.Add(id.GetListViewItem());
                        }
                    }
                }
                listView_Files.Items[0].Selected = true;
            }
            else
            {
                SelectedROM = null;
            }
        }

        private bool SelectROMWithFileLengthAndHash(long FileLength, byte[] Hash)
        {
            bool success = false;
            foreach (ListViewItem item in listView_Files.Items)
            {
                RomId id = (RomId)item.Tag;
                if (id.MatchesFileLength(FileLength))
                {
                    id.ComputeHash();
                    if (id.MatchesHash(Hash))
                    {
                        success = true;
                        listView_Files.Focus();
                        if (item.Index >= 4)
                        {
                            listView_Files.TopItem = listView_Files.Items[item.Index - 4];
                        }
                        item.Selected = true;
                        break;
                    }
                }
            }
            return success;
        }

        private bool SelectROMWithFileName(string FileName)
        {
            bool success = false;
            foreach (ListViewItem item in listView_Files.Items)
            {
                RomId id = (RomId)item.Tag;
                if (id.MatchesFileName(FileName))
                {
                    success = true;
                    listView_Files.Focus();
                    if (item.Index >= 4)
                    {
                        listView_Files.TopItem = listView_Files.Items[item.Index - 4];
                    }
                    item.Selected = true;
                    break;
                }
            }
            return success;
        }

        private void listView_Files_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                SelectedROM = (RomId)e.Item.Tag;
                EnforceAutoEnd();
            }
        }

        private void button_QueueHelp_Click(object sender, EventArgs e)
        {
            button_Run.Focus();
            MessageBox.Show("Checking this box enables queue mode, which allows for multiple corruptions to be executed on the file sequentially. This allows corruption of multiple byte ranges among other things. "
            + "When the \"Add\" button is clicked, the current corruption settings will be saved to the queue and you will be asked for an identifier for these settings. "
            + "When the \"Add from File\" button is clicked, you will be asked to select a file containing corruption settings. All sets of corruption settings in this file will be added to the queue. "
            + "When the \"Manage\" button is clicked a new window will appear which will allow you to move corruption settings up and down in the queue, remove corruption settings from the queue, "
            + "or overwrite the current settings with a set of queued settings. The corruption settings at the top of the queue list will be executed first, and the current corruption settings will be executed last. "
            + "For example, one item in the queue means the ROM is corrupted twice, first using the queued settings and then using the current settings."
            , "Queue Help");
        }

        private void button_QueueAdd_Click(object sender, EventArgs e)
        {
            // Get an identifier of the corruption settings from the user.
            string name = Interaction.InputBox("Please enter a brief description of these corruption settings below.", "Add to Queue", "");
            if (name == "")
            {
                MessageBox.Show("No description entered, addition to queue aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QueueForm.CorruptionQueue.Add(new string[] { name, CorruptionSettingsToString() });
        }

        private void checkBox_QueueEnable_CheckedChanged(object sender, EventArgs e)
        {
            button_QueueAdd.Enabled = checkBox_QueueEnable.Checked;
            button_QueueAddFromFile.Enabled = checkBox_QueueEnable.Checked;
            button_QueueManage.Enabled = checkBox_QueueEnable.Checked;
        }

        private void button_QueueManage_Click(object sender, EventArgs e)
        {
            QueueForm form = new QueueForm(this);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            while (form.Visible == true)
                this.Enabled = false;
        }

        private byte[] Corrupt(byte[] ROM)
        {
            // Read in all of the text boxes.
            long StartByte;
            try
            {
                StartByte = Convert.ToInt64(textBox_StartByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid start byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            long EndByte;
            try
            {
                EndByte = Convert.ToInt64(textBox_EndByte.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid end byte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            uint EveryNthByte;
            try
            {
                EveryNthByte = Convert.ToUInt32(textBox_EveryNBytes.Text);
            }
            catch
            {
                MessageBox.Show("Invalid byte corruption interval.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (EveryNthByte == 0)
            {
                MessageBox.Show("Invalid byte corruption interval.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int AddXtoByte;
            try
            {
                AddXtoByte = Convert.ToInt32(textBox_AddXToByte.Text);
            }
            catch
            {
                MessageBox.Show("Invalid byte addition value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int ShiftRightXBytes;
            try
            {
                ShiftRightXBytes = Convert.ToInt32(textBox_ShiftRightXBytes.Text);
            }
            catch
            {
                MessageBox.Show("Invalid right shift value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte ReplaceByteXwithYByteX;
            try
            {
                ReplaceByteXwithYByteX = Convert.ToByte(textBox_ReplaceByteXwithYByteX.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid byte to match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte ReplaceByteXwithYByteY;
            try
            {
                ReplaceByteXwithYByteY = Convert.ToByte(textBox_ReplaceByteXwithYByteY.Text, 16);
            }
            catch
            {
                MessageBox.Show("Invalid byte replacement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Limit the end byte.
            if (EndByte > (ROM.LongLength - 1))
            {
                EndByte = ROM.LongLength - 1;
            }

            // Set byte corruption option.
            Corruption.ByteCorruptionOptions ByteCorruptionOption = Corruption.ByteCorruptionOptions.AddXToByte;
            if (radioButton_ShiftRightXBytes.Checked) ByteCorruptionOption = Corruption.ByteCorruptionOptions.ShiftRightXBytes;
            else if (radioButton_ReplaceByteXwithY.Checked) ByteCorruptionOption = Corruption.ByteCorruptionOptions.ReplaceByteXwithY;

            // Corrupt.
            ROM = Corruption.Run(ROM, checkBox_ByteCorruptionEnable.Checked, StartByte, EndByte, ByteCorruptionOption,
                EveryNthByte, AddXtoByte, ShiftRightXBytes, ReplaceByteXwithYByteX, ReplaceByteXwithYByteY, checkBox_EnableNESCPUJamProtection.Checked,
                checkBox_TextReplacementEnable.Checked, checkBox_TextUseByteCorruptionRange.Checked, textBox_TextToReplace.Text, textBox_ReplaceWith.Text, textBox_AnchorWords.Text,
                checkBox_ColorReplacementEnable.Checked, checkBox_ColorUseByteCorruptionRange.Checked, textBox_ColorsToReplace.Text, textBox_ReplaceWithColors.Text);

            return ROM;
        }

        private void button_QueueAddFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select Corruption Settings to Add to Queue";
            fDialog.Filter = "Text Documents (*.txt)|*.txt";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            fDialog.InitialDirectory = SettingSaveDirectory;

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the text from the file.
                    string text = File.ReadAllText(fDialog.FileName);

                    // Get the file name.
                    string filename = Path.GetFileNameWithoutExtension(fDialog.FileName);

                    // Read in the queue entries.
                    StringToQueueSettings(text, filename);

                    // Save the current settings to the queue.
                    QueueForm.CorruptionQueue.Add(new string[] { "Current", CorruptionSettingsToString() });

                    // Read in the main settings.
                    StringToCorruptionSettings(text);

                    // Save the main settings to the queue.
                    QueueForm.CorruptionQueue.Add(new string[] { filename, CorruptionSettingsToString() });
                    
                    // Restore the current settings.
                    StringToCorruptionSettings(QueueForm.CorruptionQueue[QueueForm.CorruptionQueue.Count - 2][1]);

                    // Remove the current settings from the queue.
                    QueueForm.CorruptionQueue.RemoveAt(QueueForm.CorruptionQueue.Count - 2);
                }
                catch
                {
                    MessageBox.Show("Error loading corruption settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    SettingSaveDirectory = Path.GetDirectoryName(fDialog.FileName);
                }
                catch
                {
                    SettingSaveDirectory = "";
                }
            }
        }
    }
}
