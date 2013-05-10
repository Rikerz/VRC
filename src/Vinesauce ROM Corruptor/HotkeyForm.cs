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

namespace Vinesauce_ROM_Corruptor
{
    public partial class HotkeyForm : Form
    {
        private Keys Hotkey;

        public HotkeyForm()
        {
            InitializeComponent();
            MainForm.HotkeyEnabled = false;
            switch (MainForm.HotkeyAction)
            {
                case HotkeyActions.AddStart:
                    radioButton_AddStart.Checked = true;
                    break;
                case HotkeyActions.AddEnd:
                    radioButton_AddEnd.Checked = true;
                    break;
                case HotkeyActions.AddRange:
                    radioButton_AddRange.Checked = true;
                    break;
                case HotkeyActions.SubStart:
                    radioButton_SubStart.Checked = true;
                    break;
                case HotkeyActions.SubEnd:
                    radioButton_SubEnd.Checked = true;
                    break;
                case HotkeyActions.SubRange:
                    radioButton_SubRange.Checked = true;
                    break;
            }
            Hotkey = MainForm.Hotkey;
            label_HotkeyKey.Text = Hotkey.ToString();
        }

        private void HotkeyForm_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey = e.KeyCode;
            label_HotkeyKey.Text = Hotkey.ToString();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (radioButton_AddStart.Checked) MainForm.HotkeyAction = HotkeyActions.AddStart;
            if (radioButton_AddEnd.Checked) MainForm.HotkeyAction = HotkeyActions.AddEnd;
            if (radioButton_AddRange.Checked) MainForm.HotkeyAction = HotkeyActions.AddRange;
            if (radioButton_SubStart.Checked) MainForm.HotkeyAction = HotkeyActions.SubStart;
            if (radioButton_SubEnd.Checked) MainForm.HotkeyAction = HotkeyActions.SubEnd;
            if (radioButton_SubRange.Checked) MainForm.HotkeyAction = HotkeyActions.SubRange;
            MainForm.Hotkey = Hotkey;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HotkeyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.HotkeyEnabled = true;
        }
    }
}
