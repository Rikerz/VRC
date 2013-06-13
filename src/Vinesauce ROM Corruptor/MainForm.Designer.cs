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
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_RomDirectoryBrowse = new System.Windows.Forms.Button();
            this.textBox_RomDirectory = new System.Windows.Forms.TextBox();
            this.labelRomToCorrupt = new System.Windows.Forms.Label();
            this.labelSaveLocation = new System.Windows.Forms.Label();
            this.textBox_SaveLocation = new System.Windows.Forms.TextBox();
            this.button_SaveLocationBrowse = new System.Windows.Forms.Button();
            this.checkBox_Overwrite = new System.Windows.Forms.CheckBox();
            this.groupBox_FileSelection = new System.Windows.Forms.GroupBox();
            this.listView_Files = new System.Windows.Forms.ListView();
            this.listViewC_fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_EmulatorSelection = new System.Windows.Forms.GroupBox();
            this.button_EmulatorToRunBrowse = new System.Windows.Forms.Button();
            this.textBox_EmulatorToRun = new System.Windows.Forms.TextBox();
            this.label_EmulatorToRun = new System.Windows.Forms.Label();
            this.checkBox_RunEmulator = new System.Windows.Forms.CheckBox();
            this.groupBox_TextReplace = new System.Windows.Forms.GroupBox();
            this.button_TextUseByteCorruptionRangeHelp = new System.Windows.Forms.Button();
            this.checkBox_TextUseByteCorruptionRange = new System.Windows.Forms.CheckBox();
            this.button_ReplaceWithHelp = new System.Windows.Forms.Button();
            this.button_TextToReplaceHelp = new System.Windows.Forms.Button();
            this.textBox_ReplaceWith = new System.Windows.Forms.TextBox();
            this.label_ReplaceWith = new System.Windows.Forms.Label();
            this.textBox_TextToReplace = new System.Windows.Forms.TextBox();
            this.label_TextToReplace = new System.Windows.Forms.Label();
            this.button_AnchorWordsHelp = new System.Windows.Forms.Button();
            this.textBox_AnchorWords = new System.Windows.Forms.TextBox();
            this.label_AnchorWords = new System.Windows.Forms.Label();
            this.checkBox_TextReplacementEnable = new System.Windows.Forms.CheckBox();
            this.button_Run = new System.Windows.Forms.Button();
            this.groupBox_ByteCorruption = new System.Windows.Forms.GroupBox();
            this.button_EnableNESCPUJamProtectionHelp = new System.Windows.Forms.Button();
            this.button_ReplaceByteXwithYHelp = new System.Windows.Forms.Button();
            this.textBox_ReplaceByteXwithYByteY = new System.Windows.Forms.TextBox();
            this.label_ReplaceByteXwithY = new System.Windows.Forms.Label();
            this.checkBox_EnableNESCPUJamProtection = new System.Windows.Forms.CheckBox();
            this.textBox_ReplaceByteXwithYByteX = new System.Windows.Forms.TextBox();
            this.radioButton_ReplaceByteXwithY = new System.Windows.Forms.RadioButton();
            this.button_ShiftRightXBytesHelp = new System.Windows.Forms.Button();
            this.label_ShiftRightXBytes = new System.Windows.Forms.Label();
            this.textBox_ShiftRightXBytes = new System.Windows.Forms.TextBox();
            this.radioButton_ShiftRightXBytes = new System.Windows.Forms.RadioButton();
            this.radioButton_AddXToByte = new System.Windows.Forms.RadioButton();
            this.button_AddXToByteHelp = new System.Windows.Forms.Button();
            this.label_AddXToByte = new System.Windows.Forms.Label();
            this.textBox_AddXToByte = new System.Windows.Forms.TextBox();
            this.button_EveryNBytesHelp = new System.Windows.Forms.Button();
            this.label_EveryNBytes2 = new System.Windows.Forms.Label();
            this.textBox_EveryNBytes = new System.Windows.Forms.TextBox();
            this.label_EveryNBytes1 = new System.Windows.Forms.Label();
            this.button_AutoEndHelp = new System.Windows.Forms.Button();
            this.checkBox_AutoEnd = new System.Windows.Forms.CheckBox();
            this.button_RangeHelp = new System.Windows.Forms.Button();
            this.button_IncrementHelp = new System.Windows.Forms.Button();
            this.textBox_Increment = new System.Windows.Forms.TextBox();
            this.label_Increment = new System.Windows.Forms.Label();
            this.button_RangeDown = new System.Windows.Forms.Button();
            this.button_RangeUp = new System.Windows.Forms.Button();
            this.button_StartByteDown = new System.Windows.Forms.Button();
            this.button_EndByteDown = new System.Windows.Forms.Button();
            this.button_StartByteUp = new System.Windows.Forms.Button();
            this.button_EndByteUp = new System.Windows.Forms.Button();
            this.textBox_EndByte = new System.Windows.Forms.TextBox();
            this.label_EndByte = new System.Windows.Forms.Label();
            this.textBox_StartByte = new System.Windows.Forms.TextBox();
            this.label_StartByte = new System.Windows.Forms.Label();
            this.checkBox_ByteCorruptionEnable = new System.Windows.Forms.CheckBox();
            this.groupBox_ColorReplacement = new System.Windows.Forms.GroupBox();
            this.button_ColorUseByteCorruptionRangeHelp = new System.Windows.Forms.Button();
            this.button_ReplaceWithColorsHelp = new System.Windows.Forms.Button();
            this.checkBox_ColorUseByteCorruptionRange = new System.Windows.Forms.CheckBox();
            this.textBox_ReplaceWithColors = new System.Windows.Forms.TextBox();
            this.label_ReplaceWithColors = new System.Windows.Forms.Label();
            this.button_ColorsToReplaceHelp = new System.Windows.Forms.Button();
            this.textBox_ColorsToReplace = new System.Windows.Forms.TextBox();
            this.label_ColorsToReplace = new System.Windows.Forms.Label();
            this.checkBox_ColorReplacementEnable = new System.Windows.Forms.CheckBox();
            this.groupBox_NESPalette = new System.Windows.Forms.GroupBox();
            this.pictureBox_NESPalette = new System.Windows.Forms.PictureBox();
            this.button_NESPaletteHelp = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox_UseTinyURL = new System.Windows.Forms.CheckBox();
            this.button_UseTinyURLHelp = new System.Windows.Forms.Button();
            this.checkBox_HotkeyEnable = new System.Windows.Forms.CheckBox();
            this.button_HotkeySet = new System.Windows.Forms.Button();
            this.button_HotkeyHelp = new System.Windows.Forms.Button();
            this.groupBox_Queue = new System.Windows.Forms.GroupBox();
            this.button_QueueHelp = new System.Windows.Forms.Button();
            this.checkBox_QueueEnable = new System.Windows.Forms.CheckBox();
            this.button_QueueManage = new System.Windows.Forms.Button();
            this.button_QueueAdd = new System.Windows.Forms.Button();
            this.groupBox_FileSelection.SuspendLayout();
            this.groupBox_EmulatorSelection.SuspendLayout();
            this.groupBox_TextReplace.SuspendLayout();
            this.groupBox_ByteCorruption.SuspendLayout();
            this.groupBox_ColorReplacement.SuspendLayout();
            this.groupBox_NESPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NESPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_Queue.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_RomDirectoryBrowse
            // 
            this.button_RomDirectoryBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RomDirectoryBrowse.Location = new System.Drawing.Point(327, 30);
            this.button_RomDirectoryBrowse.Name = "button_RomDirectoryBrowse";
            this.button_RomDirectoryBrowse.Size = new System.Drawing.Size(26, 23);
            this.button_RomDirectoryBrowse.TabIndex = 0;
            this.button_RomDirectoryBrowse.Text = "...";
            this.button_RomDirectoryBrowse.UseVisualStyleBackColor = true;
            this.button_RomDirectoryBrowse.Click += new System.EventHandler(this.button_RomToCorruptBrowse_Click);
            // 
            // textBox_RomDirectory
            // 
            this.textBox_RomDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RomDirectory.Location = new System.Drawing.Point(10, 32);
            this.textBox_RomDirectory.Name = "textBox_RomDirectory";
            this.textBox_RomDirectory.Size = new System.Drawing.Size(312, 20);
            this.textBox_RomDirectory.TabIndex = 1;
            // 
            // labelRomToCorrupt
            // 
            this.labelRomToCorrupt.AutoSize = true;
            this.labelRomToCorrupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRomToCorrupt.Location = new System.Drawing.Point(7, 16);
            this.labelRomToCorrupt.Name = "labelRomToCorrupt";
            this.labelRomToCorrupt.Size = new System.Drawing.Size(90, 13);
            this.labelRomToCorrupt.TabIndex = 2;
            this.labelRomToCorrupt.Text = "ROM Directory";
            // 
            // labelSaveLocation
            // 
            this.labelSaveLocation.AutoSize = true;
            this.labelSaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaveLocation.Location = new System.Drawing.Point(6, 245);
            this.labelSaveLocation.Name = "labelSaveLocation";
            this.labelSaveLocation.Size = new System.Drawing.Size(146, 13);
            this.labelSaveLocation.TabIndex = 3;
            this.labelSaveLocation.Text = "Save Corrupted ROM To";
            // 
            // textBox_SaveLocation
            // 
            this.textBox_SaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SaveLocation.Location = new System.Drawing.Point(9, 261);
            this.textBox_SaveLocation.Name = "textBox_SaveLocation";
            this.textBox_SaveLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_SaveLocation.Size = new System.Drawing.Size(312, 20);
            this.textBox_SaveLocation.TabIndex = 4;
            this.textBox_SaveLocation.Text = "C:\\CorruptedROM.rom";
            // 
            // button_SaveLocationBrowse
            // 
            this.button_SaveLocationBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SaveLocationBrowse.Location = new System.Drawing.Point(326, 261);
            this.button_SaveLocationBrowse.Name = "button_SaveLocationBrowse";
            this.button_SaveLocationBrowse.Size = new System.Drawing.Size(26, 23);
            this.button_SaveLocationBrowse.TabIndex = 5;
            this.button_SaveLocationBrowse.Text = "...";
            this.button_SaveLocationBrowse.UseVisualStyleBackColor = true;
            this.button_SaveLocationBrowse.Click += new System.EventHandler(this.button_SaveLocationBrowse_Click);
            // 
            // checkBox_Overwrite
            // 
            this.checkBox_Overwrite.AutoSize = true;
            this.checkBox_Overwrite.Checked = true;
            this.checkBox_Overwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Overwrite.Location = new System.Drawing.Point(9, 287);
            this.checkBox_Overwrite.Name = "checkBox_Overwrite";
            this.checkBox_Overwrite.Size = new System.Drawing.Size(104, 17);
            this.checkBox_Overwrite.TabIndex = 6;
            this.checkBox_Overwrite.Text = "Overwrite File";
            this.checkBox_Overwrite.UseVisualStyleBackColor = true;
            // 
            // groupBox_FileSelection
            // 
            this.groupBox_FileSelection.Controls.Add(this.listView_Files);
            this.groupBox_FileSelection.Controls.Add(this.checkBox_Overwrite);
            this.groupBox_FileSelection.Controls.Add(this.labelRomToCorrupt);
            this.groupBox_FileSelection.Controls.Add(this.button_SaveLocationBrowse);
            this.groupBox_FileSelection.Controls.Add(this.button_RomDirectoryBrowse);
            this.groupBox_FileSelection.Controls.Add(this.textBox_SaveLocation);
            this.groupBox_FileSelection.Controls.Add(this.textBox_RomDirectory);
            this.groupBox_FileSelection.Controls.Add(this.labelSaveLocation);
            this.groupBox_FileSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_FileSelection.Location = new System.Drawing.Point(10, 5);
            this.groupBox_FileSelection.Name = "groupBox_FileSelection";
            this.groupBox_FileSelection.Size = new System.Drawing.Size(359, 313);
            this.groupBox_FileSelection.TabIndex = 7;
            this.groupBox_FileSelection.TabStop = false;
            this.groupBox_FileSelection.Text = "File Selection";
            // 
            // listView_Files
            // 
            this.listView_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewC_fileName});
            this.listView_Files.FullRowSelect = true;
            this.listView_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Files.HideSelection = false;
            this.listView_Files.Location = new System.Drawing.Point(10, 56);
            this.listView_Files.Margin = new System.Windows.Forms.Padding(2);
            this.listView_Files.MultiSelect = false;
            this.listView_Files.Name = "listView_Files";
            this.listView_Files.Size = new System.Drawing.Size(344, 183);
            this.listView_Files.TabIndex = 47;
            this.listView_Files.UseCompatibleStateImageBehavior = false;
            this.listView_Files.View = System.Windows.Forms.View.Details;
            this.listView_Files.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_Files_ItemSelectionChanged);
            // 
            // listViewC_fileName
            // 
            this.listViewC_fileName.Text = "File Name";
            this.listViewC_fileName.Width = 340;
            // 
            // groupBox_EmulatorSelection
            // 
            this.groupBox_EmulatorSelection.Controls.Add(this.button_EmulatorToRunBrowse);
            this.groupBox_EmulatorSelection.Controls.Add(this.textBox_EmulatorToRun);
            this.groupBox_EmulatorSelection.Controls.Add(this.label_EmulatorToRun);
            this.groupBox_EmulatorSelection.Controls.Add(this.checkBox_RunEmulator);
            this.groupBox_EmulatorSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_EmulatorSelection.Location = new System.Drawing.Point(10, 323);
            this.groupBox_EmulatorSelection.Name = "groupBox_EmulatorSelection";
            this.groupBox_EmulatorSelection.Size = new System.Drawing.Size(358, 83);
            this.groupBox_EmulatorSelection.TabIndex = 8;
            this.groupBox_EmulatorSelection.TabStop = false;
            this.groupBox_EmulatorSelection.Text = "Emulator Selection";
            // 
            // button_EmulatorToRunBrowse
            // 
            this.button_EmulatorToRunBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EmulatorToRunBrowse.Location = new System.Drawing.Point(326, 54);
            this.button_EmulatorToRunBrowse.Name = "button_EmulatorToRunBrowse";
            this.button_EmulatorToRunBrowse.Size = new System.Drawing.Size(26, 23);
            this.button_EmulatorToRunBrowse.TabIndex = 8;
            this.button_EmulatorToRunBrowse.Text = "...";
            this.button_EmulatorToRunBrowse.UseVisualStyleBackColor = true;
            this.button_EmulatorToRunBrowse.Click += new System.EventHandler(this.button_EmulatorToRunBrowse_Click);
            // 
            // textBox_EmulatorToRun
            // 
            this.textBox_EmulatorToRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_EmulatorToRun.Location = new System.Drawing.Point(8, 56);
            this.textBox_EmulatorToRun.Name = "textBox_EmulatorToRun";
            this.textBox_EmulatorToRun.Size = new System.Drawing.Size(312, 20);
            this.textBox_EmulatorToRun.TabIndex = 7;
            // 
            // label_EmulatorToRun
            // 
            this.label_EmulatorToRun.AutoSize = true;
            this.label_EmulatorToRun.Location = new System.Drawing.Point(5, 40);
            this.label_EmulatorToRun.Name = "label_EmulatorToRun";
            this.label_EmulatorToRun.Size = new System.Drawing.Size(98, 13);
            this.label_EmulatorToRun.TabIndex = 1;
            this.label_EmulatorToRun.Text = "Emulator to Run";
            // 
            // checkBox_RunEmulator
            // 
            this.checkBox_RunEmulator.AutoSize = true;
            this.checkBox_RunEmulator.Checked = true;
            this.checkBox_RunEmulator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RunEmulator.Location = new System.Drawing.Point(8, 20);
            this.checkBox_RunEmulator.Name = "checkBox_RunEmulator";
            this.checkBox_RunEmulator.Size = new System.Drawing.Size(195, 17);
            this.checkBox_RunEmulator.TabIndex = 0;
            this.checkBox_RunEmulator.Text = "Run Emulator After Corrupting";
            this.checkBox_RunEmulator.UseVisualStyleBackColor = true;
            this.checkBox_RunEmulator.CheckedChanged += new System.EventHandler(this.checkBox_RunEmulator_CheckedChanged);
            // 
            // groupBox_TextReplace
            // 
            this.groupBox_TextReplace.Controls.Add(this.button_TextUseByteCorruptionRangeHelp);
            this.groupBox_TextReplace.Controls.Add(this.checkBox_TextUseByteCorruptionRange);
            this.groupBox_TextReplace.Controls.Add(this.button_ReplaceWithHelp);
            this.groupBox_TextReplace.Controls.Add(this.button_TextToReplaceHelp);
            this.groupBox_TextReplace.Controls.Add(this.textBox_ReplaceWith);
            this.groupBox_TextReplace.Controls.Add(this.label_ReplaceWith);
            this.groupBox_TextReplace.Controls.Add(this.textBox_TextToReplace);
            this.groupBox_TextReplace.Controls.Add(this.label_TextToReplace);
            this.groupBox_TextReplace.Controls.Add(this.button_AnchorWordsHelp);
            this.groupBox_TextReplace.Controls.Add(this.textBox_AnchorWords);
            this.groupBox_TextReplace.Controls.Add(this.label_AnchorWords);
            this.groupBox_TextReplace.Controls.Add(this.checkBox_TextReplacementEnable);
            this.groupBox_TextReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_TextReplace.Location = new System.Drawing.Point(10, 413);
            this.groupBox_TextReplace.Name = "groupBox_TextReplace";
            this.groupBox_TextReplace.Size = new System.Drawing.Size(359, 162);
            this.groupBox_TextReplace.TabIndex = 9;
            this.groupBox_TextReplace.TabStop = false;
            this.groupBox_TextReplace.Text = "Text Replacement";
            // 
            // button_TextUseByteCorruptionRangeHelp
            // 
            this.button_TextUseByteCorruptionRangeHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TextUseByteCorruptionRangeHelp.Location = new System.Drawing.Point(327, 15);
            this.button_TextUseByteCorruptionRangeHelp.Name = "button_TextUseByteCorruptionRangeHelp";
            this.button_TextUseByteCorruptionRangeHelp.Size = new System.Drawing.Size(26, 23);
            this.button_TextUseByteCorruptionRangeHelp.TabIndex = 17;
            this.button_TextUseByteCorruptionRangeHelp.Text = "?";
            this.button_TextUseByteCorruptionRangeHelp.UseVisualStyleBackColor = true;
            this.button_TextUseByteCorruptionRangeHelp.Click += new System.EventHandler(this.button_TextUseByteCorruptionRangeHelp_Click);
            // 
            // checkBox_TextUseByteCorruptionRange
            // 
            this.checkBox_TextUseByteCorruptionRange.AutoSize = true;
            this.checkBox_TextUseByteCorruptionRange.Enabled = false;
            this.checkBox_TextUseByteCorruptionRange.Location = new System.Drawing.Point(141, 19);
            this.checkBox_TextUseByteCorruptionRange.Name = "checkBox_TextUseByteCorruptionRange";
            this.checkBox_TextUseByteCorruptionRange.Size = new System.Drawing.Size(180, 17);
            this.checkBox_TextUseByteCorruptionRange.TabIndex = 16;
            this.checkBox_TextUseByteCorruptionRange.Text = "Use Byte Corruption Range";
            this.checkBox_TextUseByteCorruptionRange.UseVisualStyleBackColor = true;
            // 
            // button_ReplaceWithHelp
            // 
            this.button_ReplaceWithHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReplaceWithHelp.Location = new System.Drawing.Point(327, 132);
            this.button_ReplaceWithHelp.Name = "button_ReplaceWithHelp";
            this.button_ReplaceWithHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ReplaceWithHelp.TabIndex = 15;
            this.button_ReplaceWithHelp.Text = "?";
            this.button_ReplaceWithHelp.UseVisualStyleBackColor = true;
            this.button_ReplaceWithHelp.Click += new System.EventHandler(this.button_ReplaceWithHelp_Click);
            // 
            // button_TextToReplaceHelp
            // 
            this.button_TextToReplaceHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TextToReplaceHelp.Location = new System.Drawing.Point(327, 93);
            this.button_TextToReplaceHelp.Name = "button_TextToReplaceHelp";
            this.button_TextToReplaceHelp.Size = new System.Drawing.Size(26, 23);
            this.button_TextToReplaceHelp.TabIndex = 14;
            this.button_TextToReplaceHelp.Text = "?";
            this.button_TextToReplaceHelp.UseVisualStyleBackColor = true;
            this.button_TextToReplaceHelp.Click += new System.EventHandler(this.button_TextToReplaceHelp_Click);
            // 
            // textBox_ReplaceWith
            // 
            this.textBox_ReplaceWith.Enabled = false;
            this.textBox_ReplaceWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReplaceWith.Location = new System.Drawing.Point(9, 134);
            this.textBox_ReplaceWith.Name = "textBox_ReplaceWith";
            this.textBox_ReplaceWith.Size = new System.Drawing.Size(312, 20);
            this.textBox_ReplaceWith.TabIndex = 13;
            // 
            // label_ReplaceWith
            // 
            this.label_ReplaceWith.AutoSize = true;
            this.label_ReplaceWith.Enabled = false;
            this.label_ReplaceWith.Location = new System.Drawing.Point(6, 118);
            this.label_ReplaceWith.Name = "label_ReplaceWith";
            this.label_ReplaceWith.Size = new System.Drawing.Size(84, 13);
            this.label_ReplaceWith.TabIndex = 12;
            this.label_ReplaceWith.Text = "Replace With";
            // 
            // textBox_TextToReplace
            // 
            this.textBox_TextToReplace.Enabled = false;
            this.textBox_TextToReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TextToReplace.Location = new System.Drawing.Point(9, 95);
            this.textBox_TextToReplace.Name = "textBox_TextToReplace";
            this.textBox_TextToReplace.Size = new System.Drawing.Size(312, 20);
            this.textBox_TextToReplace.TabIndex = 11;
            // 
            // label_TextToReplace
            // 
            this.label_TextToReplace.AutoSize = true;
            this.label_TextToReplace.Enabled = false;
            this.label_TextToReplace.Location = new System.Drawing.Point(6, 79);
            this.label_TextToReplace.Name = "label_TextToReplace";
            this.label_TextToReplace.Size = new System.Drawing.Size(98, 13);
            this.label_TextToReplace.TabIndex = 10;
            this.label_TextToReplace.Text = "Text to Replace";
            // 
            // button_AnchorWordsHelp
            // 
            this.button_AnchorWordsHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AnchorWordsHelp.Location = new System.Drawing.Point(327, 53);
            this.button_AnchorWordsHelp.Name = "button_AnchorWordsHelp";
            this.button_AnchorWordsHelp.Size = new System.Drawing.Size(26, 23);
            this.button_AnchorWordsHelp.TabIndex = 9;
            this.button_AnchorWordsHelp.Text = "?";
            this.button_AnchorWordsHelp.UseVisualStyleBackColor = true;
            this.button_AnchorWordsHelp.Click += new System.EventHandler(this.button_AnchorWordsHelp_Click);
            // 
            // textBox_AnchorWords
            // 
            this.textBox_AnchorWords.Enabled = false;
            this.textBox_AnchorWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AnchorWords.Location = new System.Drawing.Point(9, 55);
            this.textBox_AnchorWords.Name = "textBox_AnchorWords";
            this.textBox_AnchorWords.Size = new System.Drawing.Size(312, 20);
            this.textBox_AnchorWords.TabIndex = 3;
            this.textBox_AnchorWords.Text = "NINTENDO";
            // 
            // label_AnchorWords
            // 
            this.label_AnchorWords.AutoSize = true;
            this.label_AnchorWords.Enabled = false;
            this.label_AnchorWords.Location = new System.Drawing.Point(6, 39);
            this.label_AnchorWords.Name = "label_AnchorWords";
            this.label_AnchorWords.Size = new System.Drawing.Size(87, 13);
            this.label_AnchorWords.TabIndex = 1;
            this.label_AnchorWords.Text = "Anchor Words";
            // 
            // checkBox_TextReplacementEnable
            // 
            this.checkBox_TextReplacementEnable.AutoSize = true;
            this.checkBox_TextReplacementEnable.Location = new System.Drawing.Point(9, 19);
            this.checkBox_TextReplacementEnable.Name = "checkBox_TextReplacementEnable";
            this.checkBox_TextReplacementEnable.Size = new System.Drawing.Size(65, 17);
            this.checkBox_TextReplacementEnable.TabIndex = 0;
            this.checkBox_TextReplacementEnable.Text = "Enable";
            this.checkBox_TextReplacementEnable.UseVisualStyleBackColor = true;
            this.checkBox_TextReplacementEnable.CheckedChanged += new System.EventHandler(this.checkBox_TextReplacementEnable_CheckedChanged);
            // 
            // button_Run
            // 
            this.button_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Run.Location = new System.Drawing.Point(10, 757);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(55, 28);
            this.button_Run.TabIndex = 10;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // groupBox_ByteCorruption
            // 
            this.groupBox_ByteCorruption.Controls.Add(this.button_EnableNESCPUJamProtectionHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.button_ReplaceByteXwithYHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_ReplaceByteXwithYByteY);
            this.groupBox_ByteCorruption.Controls.Add(this.label_ReplaceByteXwithY);
            this.groupBox_ByteCorruption.Controls.Add(this.checkBox_EnableNESCPUJamProtection);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_ReplaceByteXwithYByteX);
            this.groupBox_ByteCorruption.Controls.Add(this.radioButton_ReplaceByteXwithY);
            this.groupBox_ByteCorruption.Controls.Add(this.button_ShiftRightXBytesHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.label_ShiftRightXBytes);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_ShiftRightXBytes);
            this.groupBox_ByteCorruption.Controls.Add(this.radioButton_ShiftRightXBytes);
            this.groupBox_ByteCorruption.Controls.Add(this.radioButton_AddXToByte);
            this.groupBox_ByteCorruption.Controls.Add(this.button_AddXToByteHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.label_AddXToByte);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_AddXToByte);
            this.groupBox_ByteCorruption.Controls.Add(this.button_EveryNBytesHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.label_EveryNBytes2);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_EveryNBytes);
            this.groupBox_ByteCorruption.Controls.Add(this.label_EveryNBytes1);
            this.groupBox_ByteCorruption.Controls.Add(this.button_AutoEndHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.checkBox_AutoEnd);
            this.groupBox_ByteCorruption.Controls.Add(this.button_RangeHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.button_IncrementHelp);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_Increment);
            this.groupBox_ByteCorruption.Controls.Add(this.label_Increment);
            this.groupBox_ByteCorruption.Controls.Add(this.button_RangeDown);
            this.groupBox_ByteCorruption.Controls.Add(this.button_RangeUp);
            this.groupBox_ByteCorruption.Controls.Add(this.button_StartByteDown);
            this.groupBox_ByteCorruption.Controls.Add(this.button_EndByteDown);
            this.groupBox_ByteCorruption.Controls.Add(this.button_StartByteUp);
            this.groupBox_ByteCorruption.Controls.Add(this.button_EndByteUp);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_EndByte);
            this.groupBox_ByteCorruption.Controls.Add(this.label_EndByte);
            this.groupBox_ByteCorruption.Controls.Add(this.textBox_StartByte);
            this.groupBox_ByteCorruption.Controls.Add(this.label_StartByte);
            this.groupBox_ByteCorruption.Controls.Add(this.checkBox_ByteCorruptionEnable);
            this.groupBox_ByteCorruption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ByteCorruption.Location = new System.Drawing.Point(376, 323);
            this.groupBox_ByteCorruption.Name = "groupBox_ByteCorruption";
            this.groupBox_ByteCorruption.Size = new System.Drawing.Size(358, 251);
            this.groupBox_ByteCorruption.TabIndex = 11;
            this.groupBox_ByteCorruption.TabStop = false;
            this.groupBox_ByteCorruption.Text = "Byte Corruption";
            // 
            // button_EnableNESCPUJamProtectionHelp
            // 
            this.button_EnableNESCPUJamProtectionHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EnableNESCPUJamProtectionHelp.Location = new System.Drawing.Point(220, 221);
            this.button_EnableNESCPUJamProtectionHelp.Name = "button_EnableNESCPUJamProtectionHelp";
            this.button_EnableNESCPUJamProtectionHelp.Size = new System.Drawing.Size(26, 23);
            this.button_EnableNESCPUJamProtectionHelp.TabIndex = 43;
            this.button_EnableNESCPUJamProtectionHelp.Text = "?";
            this.button_EnableNESCPUJamProtectionHelp.UseVisualStyleBackColor = true;
            this.button_EnableNESCPUJamProtectionHelp.Click += new System.EventHandler(this.button_EnableNESCPUJamProtectionHelp_Click);
            // 
            // button_ReplaceByteXwithYHelp
            // 
            this.button_ReplaceByteXwithYHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReplaceByteXwithYHelp.Location = new System.Drawing.Point(220, 194);
            this.button_ReplaceByteXwithYHelp.Name = "button_ReplaceByteXwithYHelp";
            this.button_ReplaceByteXwithYHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ReplaceByteXwithYHelp.TabIndex = 44;
            this.button_ReplaceByteXwithYHelp.Text = "?";
            this.button_ReplaceByteXwithYHelp.UseVisualStyleBackColor = true;
            this.button_ReplaceByteXwithYHelp.Click += new System.EventHandler(this.button_ReplaceByteXwithYHelp_Click);
            // 
            // textBox_ReplaceByteXwithYByteY
            // 
            this.textBox_ReplaceByteXwithYByteY.Enabled = false;
            this.textBox_ReplaceByteXwithYByteY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReplaceByteXwithYByteY.Location = new System.Drawing.Point(171, 196);
            this.textBox_ReplaceByteXwithYByteY.Name = "textBox_ReplaceByteXwithYByteY";
            this.textBox_ReplaceByteXwithYByteY.Size = new System.Drawing.Size(43, 20);
            this.textBox_ReplaceByteXwithYByteY.TabIndex = 43;
            this.textBox_ReplaceByteXwithYByteY.Text = "0";
            this.textBox_ReplaceByteXwithYByteY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_ReplaceByteXwithY
            // 
            this.label_ReplaceByteXwithY.AutoSize = true;
            this.label_ReplaceByteXwithY.Enabled = false;
            this.label_ReplaceByteXwithY.Location = new System.Drawing.Point(135, 199);
            this.label_ReplaceByteXwithY.Name = "label_ReplaceByteXwithY";
            this.label_ReplaceByteXwithY.Size = new System.Drawing.Size(30, 13);
            this.label_ReplaceByteXwithY.TabIndex = 42;
            this.label_ReplaceByteXwithY.Text = "with";
            // 
            // checkBox_EnableNESCPUJamProtection
            // 
            this.checkBox_EnableNESCPUJamProtection.AutoSize = true;
            this.checkBox_EnableNESCPUJamProtection.Enabled = false;
            this.checkBox_EnableNESCPUJamProtection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_EnableNESCPUJamProtection.Location = new System.Drawing.Point(6, 225);
            this.checkBox_EnableNESCPUJamProtection.Name = "checkBox_EnableNESCPUJamProtection";
            this.checkBox_EnableNESCPUJamProtection.Size = new System.Drawing.Size(211, 17);
            this.checkBox_EnableNESCPUJamProtection.TabIndex = 40;
            this.checkBox_EnableNESCPUJamProtection.Text = "Enable NES CPU Jam Protection";
            this.checkBox_EnableNESCPUJamProtection.UseVisualStyleBackColor = true;
            // 
            // textBox_ReplaceByteXwithYByteX
            // 
            this.textBox_ReplaceByteXwithYByteX.Enabled = false;
            this.textBox_ReplaceByteXwithYByteX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReplaceByteXwithYByteX.Location = new System.Drawing.Point(86, 196);
            this.textBox_ReplaceByteXwithYByteX.Name = "textBox_ReplaceByteXwithYByteX";
            this.textBox_ReplaceByteXwithYByteX.Size = new System.Drawing.Size(43, 20);
            this.textBox_ReplaceByteXwithYByteX.TabIndex = 41;
            this.textBox_ReplaceByteXwithYByteX.Text = "0";
            this.textBox_ReplaceByteXwithYByteX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButton_ReplaceByteXwithY
            // 
            this.radioButton_ReplaceByteXwithY.AutoSize = true;
            this.radioButton_ReplaceByteXwithY.Enabled = false;
            this.radioButton_ReplaceByteXwithY.Location = new System.Drawing.Point(8, 197);
            this.radioButton_ReplaceByteXwithY.Name = "radioButton_ReplaceByteXwithY";
            this.radioButton_ReplaceByteXwithY.Size = new System.Drawing.Size(72, 17);
            this.radioButton_ReplaceByteXwithY.TabIndex = 40;
            this.radioButton_ReplaceByteXwithY.TabStop = true;
            this.radioButton_ReplaceByteXwithY.Text = "Replace";
            this.radioButton_ReplaceByteXwithY.UseVisualStyleBackColor = true;
            // 
            // button_ShiftRightXBytesHelp
            // 
            this.button_ShiftRightXBytesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ShiftRightXBytesHelp.Location = new System.Drawing.Point(188, 168);
            this.button_ShiftRightXBytesHelp.Name = "button_ShiftRightXBytesHelp";
            this.button_ShiftRightXBytesHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ShiftRightXBytesHelp.TabIndex = 39;
            this.button_ShiftRightXBytesHelp.Text = "?";
            this.button_ShiftRightXBytesHelp.UseVisualStyleBackColor = true;
            this.button_ShiftRightXBytesHelp.Click += new System.EventHandler(this.button_ShiftRightXBytesHelp_Click);
            // 
            // label_ShiftRightXBytes
            // 
            this.label_ShiftRightXBytes.AutoSize = true;
            this.label_ShiftRightXBytes.Enabled = false;
            this.label_ShiftRightXBytes.Location = new System.Drawing.Point(135, 173);
            this.label_ShiftRightXBytes.Name = "label_ShiftRightXBytes";
            this.label_ShiftRightXBytes.Size = new System.Drawing.Size(38, 13);
            this.label_ShiftRightXBytes.TabIndex = 38;
            this.label_ShiftRightXBytes.Text = "Bytes";
            // 
            // textBox_ShiftRightXBytes
            // 
            this.textBox_ShiftRightXBytes.Enabled = false;
            this.textBox_ShiftRightXBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ShiftRightXBytes.Location = new System.Drawing.Point(99, 170);
            this.textBox_ShiftRightXBytes.Name = "textBox_ShiftRightXBytes";
            this.textBox_ShiftRightXBytes.Size = new System.Drawing.Size(30, 20);
            this.textBox_ShiftRightXBytes.TabIndex = 37;
            this.textBox_ShiftRightXBytes.Text = "0";
            this.textBox_ShiftRightXBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButton_ShiftRightXBytes
            // 
            this.radioButton_ShiftRightXBytes.AutoSize = true;
            this.radioButton_ShiftRightXBytes.Enabled = false;
            this.radioButton_ShiftRightXBytes.Location = new System.Drawing.Point(8, 171);
            this.radioButton_ShiftRightXBytes.Name = "radioButton_ShiftRightXBytes";
            this.radioButton_ShiftRightXBytes.Size = new System.Drawing.Size(85, 17);
            this.radioButton_ShiftRightXBytes.TabIndex = 36;
            this.radioButton_ShiftRightXBytes.TabStop = true;
            this.radioButton_ShiftRightXBytes.Text = "Shift Right";
            this.radioButton_ShiftRightXBytes.UseVisualStyleBackColor = true;
            // 
            // radioButton_AddXToByte
            // 
            this.radioButton_AddXToByte.AutoSize = true;
            this.radioButton_AddXToByte.Checked = true;
            this.radioButton_AddXToByte.Enabled = false;
            this.radioButton_AddXToByte.Location = new System.Drawing.Point(8, 145);
            this.radioButton_AddXToByte.Name = "radioButton_AddXToByte";
            this.radioButton_AddXToByte.Size = new System.Drawing.Size(47, 17);
            this.radioButton_AddXToByte.TabIndex = 35;
            this.radioButton_AddXToByte.TabStop = true;
            this.radioButton_AddXToByte.Text = "Add";
            this.radioButton_AddXToByte.UseVisualStyleBackColor = true;
            // 
            // button_AddXToByteHelp
            // 
            this.button_AddXToByteHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddXToByteHelp.Location = new System.Drawing.Point(188, 142);
            this.button_AddXToByteHelp.Name = "button_AddXToByteHelp";
            this.button_AddXToByteHelp.Size = new System.Drawing.Size(26, 23);
            this.button_AddXToByteHelp.TabIndex = 34;
            this.button_AddXToByteHelp.Text = "?";
            this.button_AddXToByteHelp.UseVisualStyleBackColor = true;
            this.button_AddXToByteHelp.Click += new System.EventHandler(this.button_AddXToByteHelp_Click);
            // 
            // label_AddXToByte
            // 
            this.label_AddXToByte.AutoSize = true;
            this.label_AddXToByte.Enabled = false;
            this.label_AddXToByte.Location = new System.Drawing.Point(135, 147);
            this.label_AddXToByte.Name = "label_AddXToByte";
            this.label_AddXToByte.Size = new System.Drawing.Size(47, 13);
            this.label_AddXToByte.TabIndex = 33;
            this.label_AddXToByte.Text = "to Byte";
            // 
            // textBox_AddXToByte
            // 
            this.textBox_AddXToByte.Enabled = false;
            this.textBox_AddXToByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AddXToByte.Location = new System.Drawing.Point(61, 144);
            this.textBox_AddXToByte.Name = "textBox_AddXToByte";
            this.textBox_AddXToByte.Size = new System.Drawing.Size(68, 20);
            this.textBox_AddXToByte.TabIndex = 32;
            this.textBox_AddXToByte.Text = "0";
            this.textBox_AddXToByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_EveryNBytesHelp
            // 
            this.button_EveryNBytesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EveryNBytesHelp.Location = new System.Drawing.Point(188, 116);
            this.button_EveryNBytesHelp.Name = "button_EveryNBytesHelp";
            this.button_EveryNBytesHelp.Size = new System.Drawing.Size(26, 23);
            this.button_EveryNBytesHelp.TabIndex = 30;
            this.button_EveryNBytesHelp.Text = "?";
            this.button_EveryNBytesHelp.UseVisualStyleBackColor = true;
            this.button_EveryNBytesHelp.Click += new System.EventHandler(this.button_EveryNBytesHelp_Click);
            // 
            // label_EveryNBytes2
            // 
            this.label_EveryNBytes2.AutoSize = true;
            this.label_EveryNBytes2.Enabled = false;
            this.label_EveryNBytes2.Location = new System.Drawing.Point(135, 121);
            this.label_EveryNBytes2.Name = "label_EveryNBytes2";
            this.label_EveryNBytes2.Size = new System.Drawing.Size(47, 13);
            this.label_EveryNBytes2.TabIndex = 29;
            this.label_EveryNBytes2.Text = "th Byte";
            // 
            // textBox_EveryNBytes
            // 
            this.textBox_EveryNBytes.Enabled = false;
            this.textBox_EveryNBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_EveryNBytes.Location = new System.Drawing.Point(95, 118);
            this.textBox_EveryNBytes.Name = "textBox_EveryNBytes";
            this.textBox_EveryNBytes.Size = new System.Drawing.Size(34, 20);
            this.textBox_EveryNBytes.TabIndex = 28;
            this.textBox_EveryNBytes.Text = "1";
            this.textBox_EveryNBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_EveryNBytes1
            // 
            this.label_EveryNBytes1.AutoSize = true;
            this.label_EveryNBytes1.Enabled = false;
            this.label_EveryNBytes1.Location = new System.Drawing.Point(5, 121);
            this.label_EveryNBytes1.Name = "label_EveryNBytes1";
            this.label_EveryNBytes1.Size = new System.Drawing.Size(84, 13);
            this.label_EveryNBytes1.TabIndex = 27;
            this.label_EveryNBytes1.Text = "Corrupt Every";
            // 
            // button_AutoEndHelp
            // 
            this.button_AutoEndHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AutoEndHelp.Location = new System.Drawing.Point(262, 90);
            this.button_AutoEndHelp.Name = "button_AutoEndHelp";
            this.button_AutoEndHelp.Size = new System.Drawing.Size(26, 23);
            this.button_AutoEndHelp.TabIndex = 26;
            this.button_AutoEndHelp.Text = "?";
            this.button_AutoEndHelp.UseVisualStyleBackColor = true;
            this.button_AutoEndHelp.Click += new System.EventHandler(this.button_AutoEndHelp_Click);
            // 
            // checkBox_AutoEnd
            // 
            this.checkBox_AutoEnd.AutoSize = true;
            this.checkBox_AutoEnd.Enabled = false;
            this.checkBox_AutoEnd.Location = new System.Drawing.Point(178, 94);
            this.checkBox_AutoEnd.Name = "checkBox_AutoEnd";
            this.checkBox_AutoEnd.Size = new System.Drawing.Size(78, 17);
            this.checkBox_AutoEnd.TabIndex = 25;
            this.checkBox_AutoEnd.Text = "Auto End";
            this.checkBox_AutoEnd.UseVisualStyleBackColor = true;
            this.checkBox_AutoEnd.CheckedChanged += new System.EventHandler(this.checkBox_AutoEnd_CheckedChanged);
            // 
            // button_RangeHelp
            // 
            this.button_RangeHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RangeHelp.Location = new System.Drawing.Point(262, 51);
            this.button_RangeHelp.Name = "button_RangeHelp";
            this.button_RangeHelp.Size = new System.Drawing.Size(26, 23);
            this.button_RangeHelp.TabIndex = 24;
            this.button_RangeHelp.Text = "?";
            this.button_RangeHelp.UseVisualStyleBackColor = true;
            this.button_RangeHelp.Click += new System.EventHandler(this.button_RangeHelp_Click);
            // 
            // button_IncrementHelp
            // 
            this.button_IncrementHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_IncrementHelp.Location = new System.Drawing.Point(134, 90);
            this.button_IncrementHelp.Name = "button_IncrementHelp";
            this.button_IncrementHelp.Size = new System.Drawing.Size(26, 23);
            this.button_IncrementHelp.TabIndex = 16;
            this.button_IncrementHelp.Text = "?";
            this.button_IncrementHelp.UseVisualStyleBackColor = true;
            this.button_IncrementHelp.Click += new System.EventHandler(this.button_IncrementHelp_Click);
            // 
            // textBox_Increment
            // 
            this.textBox_Increment.Enabled = false;
            this.textBox_Increment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Increment.Location = new System.Drawing.Point(74, 92);
            this.textBox_Increment.Name = "textBox_Increment";
            this.textBox_Increment.Size = new System.Drawing.Size(55, 20);
            this.textBox_Increment.TabIndex = 23;
            this.textBox_Increment.Text = "1000";
            this.textBox_Increment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Increment
            // 
            this.label_Increment.AutoSize = true;
            this.label_Increment.Enabled = false;
            this.label_Increment.Location = new System.Drawing.Point(5, 95);
            this.label_Increment.Name = "label_Increment";
            this.label_Increment.Size = new System.Drawing.Size(63, 13);
            this.label_Increment.TabIndex = 22;
            this.label_Increment.Text = "Increment";
            // 
            // button_RangeDown
            // 
            this.button_RangeDown.Enabled = false;
            this.button_RangeDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RangeDown.Location = new System.Drawing.Point(230, 38);
            this.button_RangeDown.Name = "button_RangeDown";
            this.button_RangeDown.Size = new System.Drawing.Size(26, 49);
            this.button_RangeDown.TabIndex = 21;
            this.button_RangeDown.Text = "-";
            this.button_RangeDown.UseVisualStyleBackColor = true;
            this.button_RangeDown.Click += new System.EventHandler(this.button_RangeDown_Click);
            // 
            // button_RangeUp
            // 
            this.button_RangeUp.Enabled = false;
            this.button_RangeUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RangeUp.Location = new System.Drawing.Point(198, 38);
            this.button_RangeUp.Name = "button_RangeUp";
            this.button_RangeUp.Size = new System.Drawing.Size(26, 49);
            this.button_RangeUp.TabIndex = 20;
            this.button_RangeUp.Text = "+";
            this.button_RangeUp.UseVisualStyleBackColor = true;
            this.button_RangeUp.Click += new System.EventHandler(this.button_RangeUp_Click);
            // 
            // button_StartByteDown
            // 
            this.button_StartByteDown.Enabled = false;
            this.button_StartByteDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartByteDown.Location = new System.Drawing.Point(166, 38);
            this.button_StartByteDown.Name = "button_StartByteDown";
            this.button_StartByteDown.Size = new System.Drawing.Size(26, 23);
            this.button_StartByteDown.TabIndex = 19;
            this.button_StartByteDown.Text = "-";
            this.button_StartByteDown.UseVisualStyleBackColor = true;
            this.button_StartByteDown.Click += new System.EventHandler(this.button_StartByteDown_Click);
            // 
            // button_EndByteDown
            // 
            this.button_EndByteDown.Enabled = false;
            this.button_EndByteDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EndByteDown.Location = new System.Drawing.Point(166, 64);
            this.button_EndByteDown.Name = "button_EndByteDown";
            this.button_EndByteDown.Size = new System.Drawing.Size(26, 23);
            this.button_EndByteDown.TabIndex = 18;
            this.button_EndByteDown.Text = "-";
            this.button_EndByteDown.UseVisualStyleBackColor = true;
            this.button_EndByteDown.Click += new System.EventHandler(this.button_EndByteDown_Click);
            // 
            // button_StartByteUp
            // 
            this.button_StartByteUp.Enabled = false;
            this.button_StartByteUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartByteUp.Location = new System.Drawing.Point(134, 38);
            this.button_StartByteUp.Name = "button_StartByteUp";
            this.button_StartByteUp.Size = new System.Drawing.Size(26, 23);
            this.button_StartByteUp.TabIndex = 17;
            this.button_StartByteUp.Text = "+";
            this.button_StartByteUp.UseVisualStyleBackColor = true;
            this.button_StartByteUp.Click += new System.EventHandler(this.button_StartByteUp_Click);
            // 
            // button_EndByteUp
            // 
            this.button_EndByteUp.Enabled = false;
            this.button_EndByteUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EndByteUp.Location = new System.Drawing.Point(134, 64);
            this.button_EndByteUp.Name = "button_EndByteUp";
            this.button_EndByteUp.Size = new System.Drawing.Size(26, 23);
            this.button_EndByteUp.TabIndex = 16;
            this.button_EndByteUp.Text = "+";
            this.button_EndByteUp.UseVisualStyleBackColor = true;
            this.button_EndByteUp.Click += new System.EventHandler(this.button_EndByteUp_Click);
            // 
            // textBox_EndByte
            // 
            this.textBox_EndByte.Enabled = false;
            this.textBox_EndByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_EndByte.Location = new System.Drawing.Point(74, 66);
            this.textBox_EndByte.Name = "textBox_EndByte";
            this.textBox_EndByte.Size = new System.Drawing.Size(55, 20);
            this.textBox_EndByte.TabIndex = 5;
            this.textBox_EndByte.Text = "1000";
            this.textBox_EndByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_EndByte
            // 
            this.label_EndByte.AutoSize = true;
            this.label_EndByte.Enabled = false;
            this.label_EndByte.Location = new System.Drawing.Point(5, 69);
            this.label_EndByte.Name = "label_EndByte";
            this.label_EndByte.Size = new System.Drawing.Size(58, 13);
            this.label_EndByte.TabIndex = 4;
            this.label_EndByte.Text = "End Byte";
            // 
            // textBox_StartByte
            // 
            this.textBox_StartByte.Enabled = false;
            this.textBox_StartByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_StartByte.Location = new System.Drawing.Point(74, 40);
            this.textBox_StartByte.Name = "textBox_StartByte";
            this.textBox_StartByte.Size = new System.Drawing.Size(55, 20);
            this.textBox_StartByte.TabIndex = 3;
            this.textBox_StartByte.Text = "0";
            this.textBox_StartByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_StartByte
            // 
            this.label_StartByte.AutoSize = true;
            this.label_StartByte.Enabled = false;
            this.label_StartByte.Location = new System.Drawing.Point(5, 43);
            this.label_StartByte.Name = "label_StartByte";
            this.label_StartByte.Size = new System.Drawing.Size(63, 13);
            this.label_StartByte.TabIndex = 2;
            this.label_StartByte.Text = "Start Byte";
            // 
            // checkBox_ByteCorruptionEnable
            // 
            this.checkBox_ByteCorruptionEnable.AutoSize = true;
            this.checkBox_ByteCorruptionEnable.Location = new System.Drawing.Point(8, 19);
            this.checkBox_ByteCorruptionEnable.Name = "checkBox_ByteCorruptionEnable";
            this.checkBox_ByteCorruptionEnable.Size = new System.Drawing.Size(65, 17);
            this.checkBox_ByteCorruptionEnable.TabIndex = 1;
            this.checkBox_ByteCorruptionEnable.Text = "Enable";
            this.checkBox_ByteCorruptionEnable.UseVisualStyleBackColor = true;
            this.checkBox_ByteCorruptionEnable.CheckedChanged += new System.EventHandler(this.checkBox_ByteCorruptionEnable_CheckedChanged);
            // 
            // groupBox_ColorReplacement
            // 
            this.groupBox_ColorReplacement.Controls.Add(this.button_ColorUseByteCorruptionRangeHelp);
            this.groupBox_ColorReplacement.Controls.Add(this.button_ReplaceWithColorsHelp);
            this.groupBox_ColorReplacement.Controls.Add(this.checkBox_ColorUseByteCorruptionRange);
            this.groupBox_ColorReplacement.Controls.Add(this.textBox_ReplaceWithColors);
            this.groupBox_ColorReplacement.Controls.Add(this.label_ReplaceWithColors);
            this.groupBox_ColorReplacement.Controls.Add(this.button_ColorsToReplaceHelp);
            this.groupBox_ColorReplacement.Controls.Add(this.textBox_ColorsToReplace);
            this.groupBox_ColorReplacement.Controls.Add(this.label_ColorsToReplace);
            this.groupBox_ColorReplacement.Controls.Add(this.checkBox_ColorReplacementEnable);
            this.groupBox_ColorReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ColorReplacement.Location = new System.Drawing.Point(10, 580);
            this.groupBox_ColorReplacement.Name = "groupBox_ColorReplacement";
            this.groupBox_ColorReplacement.Size = new System.Drawing.Size(359, 172);
            this.groupBox_ColorReplacement.TabIndex = 16;
            this.groupBox_ColorReplacement.TabStop = false;
            this.groupBox_ColorReplacement.Text = "Color Replacement";
            // 
            // button_ColorUseByteCorruptionRangeHelp
            // 
            this.button_ColorUseByteCorruptionRangeHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ColorUseByteCorruptionRangeHelp.Location = new System.Drawing.Point(327, 15);
            this.button_ColorUseByteCorruptionRangeHelp.Name = "button_ColorUseByteCorruptionRangeHelp";
            this.button_ColorUseByteCorruptionRangeHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ColorUseByteCorruptionRangeHelp.TabIndex = 19;
            this.button_ColorUseByteCorruptionRangeHelp.Text = "?";
            this.button_ColorUseByteCorruptionRangeHelp.UseVisualStyleBackColor = true;
            this.button_ColorUseByteCorruptionRangeHelp.Click += new System.EventHandler(this.button_ColorUseByteCorruptionRangeHelp_Click);
            // 
            // button_ReplaceWithColorsHelp
            // 
            this.button_ReplaceWithColorsHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReplaceWithColorsHelp.Location = new System.Drawing.Point(327, 93);
            this.button_ReplaceWithColorsHelp.Name = "button_ReplaceWithColorsHelp";
            this.button_ReplaceWithColorsHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ReplaceWithColorsHelp.TabIndex = 14;
            this.button_ReplaceWithColorsHelp.Text = "?";
            this.button_ReplaceWithColorsHelp.UseVisualStyleBackColor = true;
            this.button_ReplaceWithColorsHelp.Click += new System.EventHandler(this.button_ReplaceWithColorsHelp_Click);
            // 
            // checkBox_ColorUseByteCorruptionRange
            // 
            this.checkBox_ColorUseByteCorruptionRange.AutoSize = true;
            this.checkBox_ColorUseByteCorruptionRange.Enabled = false;
            this.checkBox_ColorUseByteCorruptionRange.Location = new System.Drawing.Point(141, 19);
            this.checkBox_ColorUseByteCorruptionRange.Name = "checkBox_ColorUseByteCorruptionRange";
            this.checkBox_ColorUseByteCorruptionRange.Size = new System.Drawing.Size(180, 17);
            this.checkBox_ColorUseByteCorruptionRange.TabIndex = 18;
            this.checkBox_ColorUseByteCorruptionRange.Text = "Use Byte Corruption Range";
            this.checkBox_ColorUseByteCorruptionRange.UseVisualStyleBackColor = true;
            // 
            // textBox_ReplaceWithColors
            // 
            this.textBox_ReplaceWithColors.Enabled = false;
            this.textBox_ReplaceWithColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ReplaceWithColors.Location = new System.Drawing.Point(9, 95);
            this.textBox_ReplaceWithColors.Name = "textBox_ReplaceWithColors";
            this.textBox_ReplaceWithColors.Size = new System.Drawing.Size(312, 20);
            this.textBox_ReplaceWithColors.TabIndex = 11;
            // 
            // label_ReplaceWithColors
            // 
            this.label_ReplaceWithColors.AutoSize = true;
            this.label_ReplaceWithColors.Enabled = false;
            this.label_ReplaceWithColors.Location = new System.Drawing.Point(6, 79);
            this.label_ReplaceWithColors.Name = "label_ReplaceWithColors";
            this.label_ReplaceWithColors.Size = new System.Drawing.Size(84, 13);
            this.label_ReplaceWithColors.TabIndex = 10;
            this.label_ReplaceWithColors.Text = "Replace With";
            // 
            // button_ColorsToReplaceHelp
            // 
            this.button_ColorsToReplaceHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ColorsToReplaceHelp.Location = new System.Drawing.Point(327, 53);
            this.button_ColorsToReplaceHelp.Name = "button_ColorsToReplaceHelp";
            this.button_ColorsToReplaceHelp.Size = new System.Drawing.Size(26, 23);
            this.button_ColorsToReplaceHelp.TabIndex = 9;
            this.button_ColorsToReplaceHelp.Text = "?";
            this.button_ColorsToReplaceHelp.UseVisualStyleBackColor = true;
            this.button_ColorsToReplaceHelp.Click += new System.EventHandler(this.button_ColorsToReplaceHelp_Click);
            // 
            // textBox_ColorsToReplace
            // 
            this.textBox_ColorsToReplace.Enabled = false;
            this.textBox_ColorsToReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ColorsToReplace.Location = new System.Drawing.Point(9, 55);
            this.textBox_ColorsToReplace.Name = "textBox_ColorsToReplace";
            this.textBox_ColorsToReplace.Size = new System.Drawing.Size(312, 20);
            this.textBox_ColorsToReplace.TabIndex = 3;
            // 
            // label_ColorsToReplace
            // 
            this.label_ColorsToReplace.AutoSize = true;
            this.label_ColorsToReplace.Enabled = false;
            this.label_ColorsToReplace.Location = new System.Drawing.Point(6, 39);
            this.label_ColorsToReplace.Name = "label_ColorsToReplace";
            this.label_ColorsToReplace.Size = new System.Drawing.Size(108, 13);
            this.label_ColorsToReplace.TabIndex = 1;
            this.label_ColorsToReplace.Text = "Colors to Replace";
            // 
            // checkBox_ColorReplacementEnable
            // 
            this.checkBox_ColorReplacementEnable.AutoSize = true;
            this.checkBox_ColorReplacementEnable.Location = new System.Drawing.Point(9, 19);
            this.checkBox_ColorReplacementEnable.Name = "checkBox_ColorReplacementEnable";
            this.checkBox_ColorReplacementEnable.Size = new System.Drawing.Size(65, 17);
            this.checkBox_ColorReplacementEnable.TabIndex = 0;
            this.checkBox_ColorReplacementEnable.Text = "Enable";
            this.checkBox_ColorReplacementEnable.UseVisualStyleBackColor = true;
            this.checkBox_ColorReplacementEnable.CheckedChanged += new System.EventHandler(this.checkBox_ColorReplacementEnable_CheckedChanged);
            // 
            // groupBox_NESPalette
            // 
            this.groupBox_NESPalette.Controls.Add(this.pictureBox_NESPalette);
            this.groupBox_NESPalette.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_NESPalette.Location = new System.Drawing.Point(376, 580);
            this.groupBox_NESPalette.Name = "groupBox_NESPalette";
            this.groupBox_NESPalette.Size = new System.Drawing.Size(358, 171);
            this.groupBox_NESPalette.TabIndex = 35;
            this.groupBox_NESPalette.TabStop = false;
            this.groupBox_NESPalette.Text = "NES Palette";
            // 
            // pictureBox_NESPalette
            // 
            this.pictureBox_NESPalette.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_NESPalette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_NESPalette.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_NESPalette.Image")));
            this.pictureBox_NESPalette.Location = new System.Drawing.Point(8, 19);
            this.pictureBox_NESPalette.Name = "pictureBox_NESPalette";
            this.pictureBox_NESPalette.Size = new System.Drawing.Size(344, 145);
            this.pictureBox_NESPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_NESPalette.TabIndex = 0;
            this.pictureBox_NESPalette.TabStop = false;
            // 
            // button_NESPaletteHelp
            // 
            this.button_NESPaletteHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_NESPaletteHelp.Location = new System.Drawing.Point(702, 761);
            this.button_NESPaletteHelp.Name = "button_NESPaletteHelp";
            this.button_NESPaletteHelp.Size = new System.Drawing.Size(26, 23);
            this.button_NESPaletteHelp.TabIndex = 16;
            this.button_NESPaletteHelp.Text = "?";
            this.button_NESPaletteHelp.UseVisualStyleBackColor = true;
            this.button_NESPaletteHelp.Click += new System.EventHandler(this.button_NESPaletteHelp_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Location = new System.Drawing.Point(70, 757);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(69, 28);
            this.button_Save.TabIndex = 37;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Load
            // 
            this.button_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Load.Location = new System.Drawing.Point(146, 757);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(69, 28);
            this.button_Load.TabIndex = 38;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Vinesauce_ROM_Corruptor.Properties.Resources.Vinesauce_Mushroom;
            this.pictureBox1.Location = new System.Drawing.Point(376, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox_UseTinyURL
            // 
            this.checkBox_UseTinyURL.AutoSize = true;
            this.checkBox_UseTinyURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_UseTinyURL.Location = new System.Drawing.Point(220, 765);
            this.checkBox_UseTinyURL.Name = "checkBox_UseTinyURL";
            this.checkBox_UseTinyURL.Size = new System.Drawing.Size(101, 17);
            this.checkBox_UseTinyURL.TabIndex = 41;
            this.checkBox_UseTinyURL.Text = "Use TinyURL";
            this.checkBox_UseTinyURL.UseVisualStyleBackColor = true;
            // 
            // button_UseTinyURLHelp
            // 
            this.button_UseTinyURLHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_UseTinyURLHelp.Location = new System.Drawing.Point(328, 761);
            this.button_UseTinyURLHelp.Name = "button_UseTinyURLHelp";
            this.button_UseTinyURLHelp.Size = new System.Drawing.Size(26, 23);
            this.button_UseTinyURLHelp.TabIndex = 42;
            this.button_UseTinyURLHelp.Text = "?";
            this.button_UseTinyURLHelp.UseVisualStyleBackColor = true;
            this.button_UseTinyURLHelp.Click += new System.EventHandler(this.button_UseTinyURLHelp_Click);
            // 
            // checkBox_HotkeyEnable
            // 
            this.checkBox_HotkeyEnable.AutoSize = true;
            this.checkBox_HotkeyEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HotkeyEnable.Location = new System.Drawing.Point(361, 765);
            this.checkBox_HotkeyEnable.Name = "checkBox_HotkeyEnable";
            this.checkBox_HotkeyEnable.Size = new System.Drawing.Size(109, 17);
            this.checkBox_HotkeyEnable.TabIndex = 43;
            this.checkBox_HotkeyEnable.Text = "Enable Hotkey";
            this.checkBox_HotkeyEnable.UseVisualStyleBackColor = true;
            this.checkBox_HotkeyEnable.CheckedChanged += new System.EventHandler(this.checkBox_HotkeyEnable_CheckedChanged);
            // 
            // button_HotkeySet
            // 
            this.button_HotkeySet.Enabled = false;
            this.button_HotkeySet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_HotkeySet.Location = new System.Drawing.Point(471, 762);
            this.button_HotkeySet.Name = "button_HotkeySet";
            this.button_HotkeySet.Size = new System.Drawing.Size(26, 23);
            this.button_HotkeySet.TabIndex = 44;
            this.button_HotkeySet.Text = "...";
            this.button_HotkeySet.UseVisualStyleBackColor = true;
            this.button_HotkeySet.Click += new System.EventHandler(this.button_HotkeySet_Click);
            // 
            // button_HotkeyHelp
            // 
            this.button_HotkeyHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_HotkeyHelp.Location = new System.Drawing.Point(502, 762);
            this.button_HotkeyHelp.Name = "button_HotkeyHelp";
            this.button_HotkeyHelp.Size = new System.Drawing.Size(26, 23);
            this.button_HotkeyHelp.TabIndex = 45;
            this.button_HotkeyHelp.Text = "?";
            this.button_HotkeyHelp.UseVisualStyleBackColor = true;
            this.button_HotkeyHelp.Click += new System.EventHandler(this.button_HotkeyHelp_Click);
            // 
            // groupBox_Queue
            // 
            this.groupBox_Queue.Controls.Add(this.button_QueueHelp);
            this.groupBox_Queue.Controls.Add(this.checkBox_QueueEnable);
            this.groupBox_Queue.Controls.Add(this.button_QueueManage);
            this.groupBox_Queue.Controls.Add(this.button_QueueAdd);
            this.groupBox_Queue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Queue.Location = new System.Drawing.Point(376, 250);
            this.groupBox_Queue.Name = "groupBox_Queue";
            this.groupBox_Queue.Size = new System.Drawing.Size(358, 68);
            this.groupBox_Queue.TabIndex = 46;
            this.groupBox_Queue.TabStop = false;
            this.groupBox_Queue.Text = "Queue";
            // 
            // button_QueueHelp
            // 
            this.button_QueueHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_QueueHelp.Location = new System.Drawing.Point(236, 16);
            this.button_QueueHelp.Name = "button_QueueHelp";
            this.button_QueueHelp.Size = new System.Drawing.Size(26, 23);
            this.button_QueueHelp.TabIndex = 45;
            this.button_QueueHelp.Text = "?";
            this.button_QueueHelp.UseVisualStyleBackColor = true;
            this.button_QueueHelp.Click += new System.EventHandler(this.button_QueueHelp_Click);
            // 
            // checkBox_QueueEnable
            // 
            this.checkBox_QueueEnable.AutoSize = true;
            this.checkBox_QueueEnable.Location = new System.Drawing.Point(6, 20);
            this.checkBox_QueueEnable.Name = "checkBox_QueueEnable";
            this.checkBox_QueueEnable.Size = new System.Drawing.Size(65, 17);
            this.checkBox_QueueEnable.TabIndex = 2;
            this.checkBox_QueueEnable.Text = "Enable";
            this.checkBox_QueueEnable.UseVisualStyleBackColor = true;
            this.checkBox_QueueEnable.CheckedChanged += new System.EventHandler(this.checkBox_QueueEnable_CheckedChanged);
            // 
            // button_QueueManage
            // 
            this.button_QueueManage.Enabled = false;
            this.button_QueueManage.Location = new System.Drawing.Point(155, 16);
            this.button_QueueManage.Name = "button_QueueManage";
            this.button_QueueManage.Size = new System.Drawing.Size(75, 23);
            this.button_QueueManage.TabIndex = 1;
            this.button_QueueManage.Text = "Manage";
            this.button_QueueManage.UseVisualStyleBackColor = true;
            this.button_QueueManage.Click += new System.EventHandler(this.button_QueueManage_Click);
            // 
            // button_QueueAdd
            // 
            this.button_QueueAdd.Enabled = false;
            this.button_QueueAdd.Location = new System.Drawing.Point(74, 16);
            this.button_QueueAdd.Name = "button_QueueAdd";
            this.button_QueueAdd.Size = new System.Drawing.Size(75, 23);
            this.button_QueueAdd.TabIndex = 0;
            this.button_QueueAdd.Text = "Add";
            this.button_QueueAdd.UseVisualStyleBackColor = true;
            this.button_QueueAdd.Click += new System.EventHandler(this.button_QueueAdd_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.button_Run;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 791);
            this.Controls.Add(this.groupBox_Queue);
            this.Controls.Add(this.button_HotkeyHelp);
            this.Controls.Add(this.button_HotkeySet);
            this.Controls.Add(this.checkBox_HotkeyEnable);
            this.Controls.Add(this.button_UseTinyURLHelp);
            this.Controls.Add(this.checkBox_UseTinyURL);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_NESPaletteHelp);
            this.Controls.Add(this.groupBox_NESPalette);
            this.Controls.Add(this.groupBox_ColorReplacement);
            this.Controls.Add(this.groupBox_ByteCorruption);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.groupBox_TextReplace);
            this.Controls.Add(this.groupBox_EmulatorSelection);
            this.Controls.Add(this.groupBox_FileSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Vinesauce ROM Corruptor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox_FileSelection.ResumeLayout(false);
            this.groupBox_FileSelection.PerformLayout();
            this.groupBox_EmulatorSelection.ResumeLayout(false);
            this.groupBox_EmulatorSelection.PerformLayout();
            this.groupBox_TextReplace.ResumeLayout(false);
            this.groupBox_TextReplace.PerformLayout();
            this.groupBox_ByteCorruption.ResumeLayout(false);
            this.groupBox_ByteCorruption.PerformLayout();
            this.groupBox_ColorReplacement.ResumeLayout(false);
            this.groupBox_ColorReplacement.PerformLayout();
            this.groupBox_NESPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NESPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_Queue.ResumeLayout(false);
            this.groupBox_Queue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RomDirectoryBrowse;
        private System.Windows.Forms.TextBox textBox_RomDirectory;
        private System.Windows.Forms.Label labelRomToCorrupt;
        private System.Windows.Forms.Label labelSaveLocation;
        private System.Windows.Forms.TextBox textBox_SaveLocation;
        private System.Windows.Forms.Button button_SaveLocationBrowse;
        private System.Windows.Forms.CheckBox checkBox_Overwrite;
        private System.Windows.Forms.GroupBox groupBox_FileSelection;
        private System.Windows.Forms.GroupBox groupBox_EmulatorSelection;
        private System.Windows.Forms.CheckBox checkBox_RunEmulator;
        private System.Windows.Forms.Button button_EmulatorToRunBrowse;
        private System.Windows.Forms.TextBox textBox_EmulatorToRun;
        private System.Windows.Forms.Label label_EmulatorToRun;
        private System.Windows.Forms.GroupBox groupBox_TextReplace;
        private System.Windows.Forms.Button button_ReplaceWithHelp;
        private System.Windows.Forms.Button button_TextToReplaceHelp;
        private System.Windows.Forms.TextBox textBox_ReplaceWith;
        private System.Windows.Forms.Label label_ReplaceWith;
        private System.Windows.Forms.TextBox textBox_TextToReplace;
        private System.Windows.Forms.Label label_TextToReplace;
        private System.Windows.Forms.Button button_AnchorWordsHelp;
        private System.Windows.Forms.TextBox textBox_AnchorWords;
        private System.Windows.Forms.Label label_AnchorWords;
        private System.Windows.Forms.CheckBox checkBox_TextReplacementEnable;
        public System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.GroupBox groupBox_ByteCorruption;
        private System.Windows.Forms.TextBox textBox_StartByte;
        private System.Windows.Forms.Label label_StartByte;
        private System.Windows.Forms.CheckBox checkBox_ByteCorruptionEnable;
        private System.Windows.Forms.TextBox textBox_EndByte;
        private System.Windows.Forms.Label label_EndByte;
        public System.Windows.Forms.Button button_RangeDown;
        public System.Windows.Forms.Button button_RangeUp;
        public System.Windows.Forms.Button button_StartByteDown;
        public System.Windows.Forms.Button button_EndByteDown;
        public System.Windows.Forms.Button button_StartByteUp;
        public System.Windows.Forms.Button button_EndByteUp;
        private System.Windows.Forms.Button button_RangeHelp;
        private System.Windows.Forms.Button button_IncrementHelp;
        private System.Windows.Forms.TextBox textBox_Increment;
        private System.Windows.Forms.Label label_Increment;
        private System.Windows.Forms.Button button_AutoEndHelp;
        private System.Windows.Forms.CheckBox checkBox_AutoEnd;
        private System.Windows.Forms.Button button_EveryNBytesHelp;
        private System.Windows.Forms.Label label_EveryNBytes2;
        private System.Windows.Forms.TextBox textBox_EveryNBytes;
        private System.Windows.Forms.Label label_EveryNBytes1;
        private System.Windows.Forms.Button button_AddXToByteHelp;
        private System.Windows.Forms.Label label_AddXToByte;
        private System.Windows.Forms.TextBox textBox_AddXToByte;
        private System.Windows.Forms.GroupBox groupBox_ColorReplacement;
        private System.Windows.Forms.Button button_ReplaceWithColorsHelp;
        private System.Windows.Forms.TextBox textBox_ReplaceWithColors;
        private System.Windows.Forms.Label label_ReplaceWithColors;
        private System.Windows.Forms.CheckBox checkBox_ColorReplacementEnable;
        private System.Windows.Forms.GroupBox groupBox_NESPalette;
        private System.Windows.Forms.PictureBox pictureBox_NESPalette;
        private System.Windows.Forms.Button button_NESPaletteHelp;
        private System.Windows.Forms.Button button_ColorsToReplaceHelp;
        private System.Windows.Forms.TextBox textBox_ColorsToReplace;
        private System.Windows.Forms.Label label_ColorsToReplace;
        private System.Windows.Forms.Button button_TextUseByteCorruptionRangeHelp;
        private System.Windows.Forms.CheckBox checkBox_TextUseByteCorruptionRange;
        private System.Windows.Forms.Button button_ColorUseByteCorruptionRangeHelp;
        private System.Windows.Forms.CheckBox checkBox_ColorUseByteCorruptionRange;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_ShiftRightXBytesHelp;
        private System.Windows.Forms.Label label_ShiftRightXBytes;
        private System.Windows.Forms.TextBox textBox_ShiftRightXBytes;
        private System.Windows.Forms.RadioButton radioButton_ShiftRightXBytes;
        private System.Windows.Forms.RadioButton radioButton_AddXToByte;
        private System.Windows.Forms.Button button_ReplaceByteXwithYHelp;
        private System.Windows.Forms.TextBox textBox_ReplaceByteXwithYByteY;
        private System.Windows.Forms.Label label_ReplaceByteXwithY;
        private System.Windows.Forms.TextBox textBox_ReplaceByteXwithYByteX;
        private System.Windows.Forms.RadioButton radioButton_ReplaceByteXwithY;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox_EnableNESCPUJamProtection;
        private System.Windows.Forms.CheckBox checkBox_UseTinyURL;
        private System.Windows.Forms.Button button_UseTinyURLHelp;
        private System.Windows.Forms.Button button_EnableNESCPUJamProtectionHelp;
        private System.Windows.Forms.CheckBox checkBox_HotkeyEnable;
        private System.Windows.Forms.Button button_HotkeySet;
        private System.Windows.Forms.Button button_HotkeyHelp;
        private System.Windows.Forms.ListView listView_Files;
        private System.Windows.Forms.ColumnHeader listViewC_fileName;
        private System.Windows.Forms.GroupBox groupBox_Queue;
        private System.Windows.Forms.Button button_QueueHelp;
        private System.Windows.Forms.CheckBox checkBox_QueueEnable;
        private System.Windows.Forms.Button button_QueueManage;
        private System.Windows.Forms.Button button_QueueAdd;
    }
}

