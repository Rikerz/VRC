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
    public partial class QueueForm : Form
    {
        static public List<string[]> CorruptionQueue = new List<string[]>();

        public MainForm MainWindow;

        public QueueForm(MainForm MainWindow)
        {
            InitializeComponent();

            this.MainWindow = MainWindow;

            PopulateQueueList();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            if (listView_Queue.SelectedIndices.Count == 0)
            {
                return;
            }

            int index = listView_Queue.SelectedIndices[0];
            if (index == 0)
            {
                return;
            }

            string[] temp = CorruptionQueue[index - 1];
            CorruptionQueue[index - 1] = CorruptionQueue[index];
            CorruptionQueue[index] = temp;

            PopulateQueueList();

            listView_Queue.Items[index - 1].Selected = true;
        }

        private void button_Down_Click(object sender, EventArgs e)
        {
            if (listView_Queue.SelectedIndices.Count == 0)
            {
                return;
            }

            int index = listView_Queue.SelectedIndices[0];
            if (index == listView_Queue.Items.Count - 1)
            {
                return;
            }

            string[] temp = CorruptionQueue[index + 1];
            CorruptionQueue[index + 1] = CorruptionQueue[index];
            CorruptionQueue[index] = temp;

            PopulateQueueList();

            listView_Queue.Items[index + 1].Selected = true;
        }

        private void PopulateQueueList()
        {
            listView_Queue.Items.Clear();
            listView_Queue.Focus();
            foreach (string[] Entry in CorruptionQueue)
            {
                listView_Queue.Items.Add(new ListViewItem(new string[] { Entry[0] }));
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listView_Queue.SelectedIndices.Count == 0)
            {
                return;
            }

            int index = listView_Queue.SelectedIndices[0];
            CorruptionQueue.RemoveAt(index);

            PopulateQueueList();
        }

        private void button_Overwrite_Click(object sender, EventArgs e)
        {
            if (listView_Queue.SelectedIndices.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("The current corruption settings will be overwritten, are you sure you wish to do this?",
                "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int index = listView_Queue.SelectedIndices[0];
                string[] entry = CorruptionQueue[index];
                MainWindow.StringToCorruptionSettings(entry[1]);
                this.Close();
            }
        }
    }
}
