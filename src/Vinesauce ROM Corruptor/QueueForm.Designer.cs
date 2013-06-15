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
    partial class QueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueForm));
            this.listView_Queue = new System.Windows.Forms.ListView();
            this.listViewC_Identifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Up = new System.Windows.Forms.Button();
            this.button_Down = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Overwrite = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Queue
            // 
            this.listView_Queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewC_Identifier});
            this.listView_Queue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Queue.FullRowSelect = true;
            this.listView_Queue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Queue.HideSelection = false;
            this.listView_Queue.Location = new System.Drawing.Point(12, 74);
            this.listView_Queue.Margin = new System.Windows.Forms.Padding(2);
            this.listView_Queue.MultiSelect = false;
            this.listView_Queue.Name = "listView_Queue";
            this.listView_Queue.Size = new System.Drawing.Size(258, 183);
            this.listView_Queue.TabIndex = 48;
            this.listView_Queue.UseCompatibleStateImageBehavior = false;
            this.listView_Queue.View = System.Windows.Forms.View.Details;
            // 
            // listViewC_Identifier
            // 
            this.listViewC_Identifier.Text = "Identifier";
            this.listViewC_Identifier.Width = 254;
            // 
            // button_Up
            // 
            this.button_Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Up.Location = new System.Drawing.Point(12, 42);
            this.button_Up.Name = "button_Up";
            this.button_Up.Size = new System.Drawing.Size(75, 23);
            this.button_Up.TabIndex = 49;
            this.button_Up.Text = "Move Up";
            this.button_Up.UseVisualStyleBackColor = true;
            this.button_Up.Click += new System.EventHandler(this.button_Up_Click);
            // 
            // button_Down
            // 
            this.button_Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Down.Location = new System.Drawing.Point(93, 42);
            this.button_Down.Name = "button_Down";
            this.button_Down.Size = new System.Drawing.Size(96, 23);
            this.button_Down.TabIndex = 50;
            this.button_Down.Text = "Move Down";
            this.button_Down.UseVisualStyleBackColor = true;
            this.button_Down.Click += new System.EventHandler(this.button_Down_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove.Location = new System.Drawing.Point(195, 42);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 51;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Overwrite
            // 
            this.button_Overwrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Overwrite.Location = new System.Drawing.Point(12, 12);
            this.button_Overwrite.Name = "button_Overwrite";
            this.button_Overwrite.Size = new System.Drawing.Size(224, 23);
            this.button_Overwrite.TabIndex = 52;
            this.button_Overwrite.Text = "Load and Overwrite Current Settings";
            this.button_Overwrite.UseVisualStyleBackColor = true;
            this.button_Overwrite.Click += new System.EventHandler(this.button_Overwrite_Click);
            // 
            // button_Close
            // 
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Location = new System.Drawing.Point(12, 262);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 53;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // QueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 290);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Overwrite);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Down);
            this.Controls.Add(this.button_Up);
            this.Controls.Add(this.listView_Queue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueueForm";
            this.Text = "Manage Queue";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Queue;
        private System.Windows.Forms.ColumnHeader listViewC_Identifier;
        private System.Windows.Forms.Button button_Up;
        private System.Windows.Forms.Button button_Down;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Overwrite;
        private System.Windows.Forms.Button button_Close;

    }
}