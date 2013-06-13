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

namespace Vinesauce_ROM_Corruptor
{
    partial class HotkeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyForm));
            this.groupBox_SelectAction = new System.Windows.Forms.GroupBox();
            this.radioButton_SubRange = new System.Windows.Forms.RadioButton();
            this.radioButton_AddRange = new System.Windows.Forms.RadioButton();
            this.radioButton_AddEnd = new System.Windows.Forms.RadioButton();
            this.radioButton_SubEnd = new System.Windows.Forms.RadioButton();
            this.radioButton_SubStart = new System.Windows.Forms.RadioButton();
            this.radioButton_AddStart = new System.Windows.Forms.RadioButton();
            this.groupBox_SelectHotkey = new System.Windows.Forms.GroupBox();
            this.label_PressAnyKey = new System.Windows.Forms.Label();
            this.label_HotkeyColon = new System.Windows.Forms.Label();
            this.label_HotkeyKey = new System.Windows.Forms.Label();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_SelectAction.SuspendLayout();
            this.groupBox_SelectHotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_SelectAction
            // 
            this.groupBox_SelectAction.Controls.Add(this.radioButton_SubRange);
            this.groupBox_SelectAction.Controls.Add(this.radioButton_AddRange);
            this.groupBox_SelectAction.Controls.Add(this.radioButton_AddEnd);
            this.groupBox_SelectAction.Controls.Add(this.radioButton_SubEnd);
            this.groupBox_SelectAction.Controls.Add(this.radioButton_SubStart);
            this.groupBox_SelectAction.Controls.Add(this.radioButton_AddStart);
            this.groupBox_SelectAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SelectAction.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SelectAction.Name = "groupBox_SelectAction";
            this.groupBox_SelectAction.Size = new System.Drawing.Size(420, 93);
            this.groupBox_SelectAction.TabIndex = 0;
            this.groupBox_SelectAction.TabStop = false;
            this.groupBox_SelectAction.Text = "Select Action";
            // 
            // radioButton_SubRange
            // 
            this.radioButton_SubRange.AutoSize = true;
            this.radioButton_SubRange.Location = new System.Drawing.Point(194, 65);
            this.radioButton_SubRange.Name = "radioButton_SubRange";
            this.radioButton_SubRange.Size = new System.Drawing.Size(202, 17);
            this.radioButton_SubRange.TabIndex = 5;
            this.radioButton_SubRange.Text = "Subtract Increment from Range";
            this.radioButton_SubRange.UseVisualStyleBackColor = true;
            // 
            // radioButton_AddRange
            // 
            this.radioButton_AddRange.AutoSize = true;
            this.radioButton_AddRange.Location = new System.Drawing.Point(6, 65);
            this.radioButton_AddRange.Name = "radioButton_AddRange";
            this.radioButton_AddRange.Size = new System.Drawing.Size(163, 17);
            this.radioButton_AddRange.TabIndex = 2;
            this.radioButton_AddRange.Text = "Add Increment to Range";
            this.radioButton_AddRange.UseVisualStyleBackColor = true;
            // 
            // radioButton_AddEnd
            // 
            this.radioButton_AddEnd.AutoSize = true;
            this.radioButton_AddEnd.Location = new System.Drawing.Point(6, 42);
            this.radioButton_AddEnd.Name = "radioButton_AddEnd";
            this.radioButton_AddEnd.Size = new System.Drawing.Size(177, 17);
            this.radioButton_AddEnd.TabIndex = 1;
            this.radioButton_AddEnd.Text = "Add Increment to End Byte";
            this.radioButton_AddEnd.UseVisualStyleBackColor = true;
            // 
            // radioButton_SubEnd
            // 
            this.radioButton_SubEnd.AutoSize = true;
            this.radioButton_SubEnd.Location = new System.Drawing.Point(194, 42);
            this.radioButton_SubEnd.Name = "radioButton_SubEnd";
            this.radioButton_SubEnd.Size = new System.Drawing.Size(216, 17);
            this.radioButton_SubEnd.TabIndex = 4;
            this.radioButton_SubEnd.Text = "Subtract Increment from End Byte";
            this.radioButton_SubEnd.UseVisualStyleBackColor = true;
            // 
            // radioButton_SubStart
            // 
            this.radioButton_SubStart.AutoSize = true;
            this.radioButton_SubStart.Location = new System.Drawing.Point(194, 19);
            this.radioButton_SubStart.Name = "radioButton_SubStart";
            this.radioButton_SubStart.Size = new System.Drawing.Size(221, 17);
            this.radioButton_SubStart.TabIndex = 3;
            this.radioButton_SubStart.Text = "Subtract Increment from Start Byte";
            this.radioButton_SubStart.UseVisualStyleBackColor = true;
            // 
            // radioButton_AddStart
            // 
            this.radioButton_AddStart.AutoSize = true;
            this.radioButton_AddStart.Checked = true;
            this.radioButton_AddStart.Location = new System.Drawing.Point(6, 19);
            this.radioButton_AddStart.Name = "radioButton_AddStart";
            this.radioButton_AddStart.Size = new System.Drawing.Size(182, 17);
            this.radioButton_AddStart.TabIndex = 0;
            this.radioButton_AddStart.TabStop = true;
            this.radioButton_AddStart.Text = "Add Increment to Start Byte";
            this.radioButton_AddStart.UseVisualStyleBackColor = true;
            // 
            // groupBox_SelectHotkey
            // 
            this.groupBox_SelectHotkey.Controls.Add(this.label_HotkeyKey);
            this.groupBox_SelectHotkey.Controls.Add(this.label_HotkeyColon);
            this.groupBox_SelectHotkey.Controls.Add(this.label_PressAnyKey);
            this.groupBox_SelectHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SelectHotkey.Location = new System.Drawing.Point(12, 111);
            this.groupBox_SelectHotkey.Name = "groupBox_SelectHotkey";
            this.groupBox_SelectHotkey.Size = new System.Drawing.Size(420, 62);
            this.groupBox_SelectHotkey.TabIndex = 1;
            this.groupBox_SelectHotkey.TabStop = false;
            this.groupBox_SelectHotkey.Text = "Select Hotkey";
            // 
            // label_PressAnyKey
            // 
            this.label_PressAnyKey.AutoSize = true;
            this.label_PressAnyKey.Location = new System.Drawing.Point(6, 16);
            this.label_PressAnyKey.Name = "label_PressAnyKey";
            this.label_PressAnyKey.Size = new System.Drawing.Size(150, 13);
            this.label_PressAnyKey.TabIndex = 0;
            this.label_PressAnyKey.Text = "Press Any Key to Change";
            // 
            // label_HotkeyColon
            // 
            this.label_HotkeyColon.AutoSize = true;
            this.label_HotkeyColon.Location = new System.Drawing.Point(6, 38);
            this.label_HotkeyColon.Name = "label_HotkeyColon";
            this.label_HotkeyColon.Size = new System.Drawing.Size(51, 13);
            this.label_HotkeyColon.TabIndex = 1;
            this.label_HotkeyColon.Text = "Hotkey:";
            // 
            // label_HotkeyKey
            // 
            this.label_HotkeyKey.AutoSize = true;
            this.label_HotkeyKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HotkeyKey.Location = new System.Drawing.Point(63, 38);
            this.label_HotkeyKey.Name = "label_HotkeyKey";
            this.label_HotkeyKey.Size = new System.Drawing.Size(38, 13);
            this.label_HotkeyKey.TabIndex = 2;
            this.label_HotkeyKey.Text = "Space";
            // 
            // button_Ok
            // 
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.Location = new System.Drawing.Point(12, 179);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 2;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(93, 179);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // HotkeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 211);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.groupBox_SelectHotkey);
            this.Controls.Add(this.groupBox_SelectAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "HotkeyForm";
            this.Text = "Setup Hotkey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeyForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyForm_KeyDown);
            this.groupBox_SelectAction.ResumeLayout(false);
            this.groupBox_SelectAction.PerformLayout();
            this.groupBox_SelectHotkey.ResumeLayout(false);
            this.groupBox_SelectHotkey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_SelectAction;
        private System.Windows.Forms.RadioButton radioButton_SubRange;
        private System.Windows.Forms.RadioButton radioButton_SubEnd;
        private System.Windows.Forms.RadioButton radioButton_SubStart;
        private System.Windows.Forms.RadioButton radioButton_AddRange;
        private System.Windows.Forms.RadioButton radioButton_AddEnd;
        private System.Windows.Forms.RadioButton radioButton_AddStart;
        private System.Windows.Forms.GroupBox groupBox_SelectHotkey;
        private System.Windows.Forms.Label label_HotkeyKey;
        private System.Windows.Forms.Label label_HotkeyColon;
        private System.Windows.Forms.Label label_PressAnyKey;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_Cancel;
    }
}