using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoker_
{
    class Invoker
    {
        public static void invokeProgressBar(ProgressBar myobject, int value, int min, int max)
        {
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => myobject.Minimum = min));
                myobject.Invoke((MethodInvoker)(() => myobject.Maximum = max));
                myobject.Invoke((MethodInvoker)(() => myobject.Value = value));
            }
            else
            {
                myobject.Minimum = min;
                myobject.Maximum = max;
                myobject.Value = value;
            }
        }

        public static int invokeProgressBarGetMax(ProgressBar myobject)
        {
            int max = 0;
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => max = myobject.Maximum));
            }
            else
            {
                max = myobject.Maximum;
            }
            return max;
        }

        public static void invokeProgressBarValue(ProgressBar myobject, int value)
        {
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => myobject.Value = value));
            }
            else
            {
                myobject.Value = value;
            }
        }

        public static void invokeVisible(object myobject, bool visible)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Visible = visible));
                else ((Label)myobject).Visible = visible;
            }
            else if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => ((PictureBox)myobject).Visible = visible));
                else ((PictureBox)myobject).Visible = visible;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Visible = visible));
                else ((TextBox)myobject).Visible = visible;
            }
            else if (myobject is ProgressBar)
            {
                if (((ProgressBar)myobject).InvokeRequired) ((ProgressBar)myobject).Invoke((MethodInvoker)(() => ((ProgressBar)myobject).Visible = visible));
                else ((ProgressBar)myobject).Visible = visible;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Visible = visible));
                else ((GroupBox)myobject).Visible = visible;
            }
        }

        public static void invokeChecked(object myobject, bool isChecked)
        {
            if (myobject is CheckBox)
            {
                if (((CheckBox)myobject).InvokeRequired) ((CheckBox)myobject).Invoke((MethodInvoker)(() => ((CheckBox)myobject).Checked = isChecked));
                else ((CheckBox)myobject).Checked = isChecked;
            }
        }

        public static void invokeItemsAdd(object myobject,string text)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.Add(text)));
                else ((ListBox)myobject).Items.Add(text);
            }
        }

        public static void invokeItemsRemoveAt(object myobject, int at)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.RemoveAt(at)));
                else ((ListBox)myobject).Items.RemoveAt(at);
            }
        }

        public static void invokeItemsClear(object myobject)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.Clear()));
                else ((ListBox)myobject).Items.Clear();
            }
        }

        public static void invokeEnable(object myobject, bool enable)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Enabled = enable));
                else ((Label)myobject).Enabled = enable;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Enabled = enable));
                else ((TextBox)myobject).Enabled = enable;
            }
            else if (myobject is TabControl)
            {
                if (((TabControl)myobject).InvokeRequired) ((TabControl)myobject).Invoke((MethodInvoker)(() => ((TabControl)myobject).Enabled = enable));
                else ((TabControl)myobject).Enabled = enable;
            }
            else if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => ((PictureBox)myobject).Enabled = enable));
                else ((PictureBox)myobject).Enabled = enable;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Enabled = enable));
                else ((GroupBox)myobject).Enabled = enable;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Enabled = enable));
                else ((Button)myobject).Enabled = enable;
            }
            else if (myobject is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)myobject).GetCurrentParent().InvokeRequired) ((ToolStripMenuItem)myobject).GetCurrentParent().Invoke((MethodInvoker)(() => ((ToolStripMenuItem)myobject).Enabled = enable));
                else ((ToolStripMenuItem)myobject).Enabled = enable;
            }
        }

        public static void invokeTextSet(object myobject, string text)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Text = text));
                else ((Label)myobject).Text = text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Text = text));
                else ((TextBox)myobject).Text = text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Text = text));
                else ((Button)myobject).Text = text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => ((RichTextBox)myobject).Text = text));
                else ((RichTextBox)myobject).Text = text;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Text = text));
                else ((GroupBox)myobject).Text = text;
            }
        }

        public static void invokeInvalidate(object myobject)
        {
            if (((Panel)myobject).InvokeRequired) ((Panel)myobject).Invoke((MethodInvoker)(() => ((Panel)myobject).Invalidate()));
            else ((Panel)myobject).Invalidate();
        }

        public static string invokeTextGet(object myobject)
        {
            string text = "";
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => text = ((Label)myobject).Text));
                else  text = ((Label)myobject).Text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => text = ((TextBox)myobject).Text));
                else text = ((TextBox)myobject).Text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => text = ((Button)myobject).Text));
                else text = ((Button)myobject).Text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => text = ((RichTextBox)myobject).Text));
                else text = ((RichTextBox)myobject).Text;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => text = ((GroupBox)myobject).Text));
                else text = ((GroupBox)myobject).Text;
            }

            return text;
        }
        public static void invokeClearRows(object myobject)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Rows.Clear()));
                else ((DataGridView)myobject).Rows.Clear();
            }
        }

        public static void invokeAutoResizeColumns(object myobject, DataGridViewAutoSizeColumnsMode mode)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).AutoResizeColumns(mode)));
                else ((DataGridView)myobject).AutoResizeColumns(mode);
            }
        }

        

        public static void invokeAddRow(object myobject, string[] cells)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Rows.Add(cells)));
                else ((DataGridView)myobject).Rows.Add(cells);
            }
        }



        public static void invokeAppendText(object myobject, string text)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Text += text));
                else ((Label)myobject).Text += text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Text += text));
                else ((TextBox)myobject).Text += text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Text += text));
                else ((Button)myobject).Text += text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => ((RichTextBox)myobject).Text += text));
                else ((RichTextBox)myobject).Text += text;
            }
        }

    }
}
