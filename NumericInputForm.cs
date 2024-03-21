using System;
using System.Collections.Generic;
using System.ComponentModel;        
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace ObjectDetection
{
    /* This class is a custom windows forms popup. You need to create a designer for it (so you can add the interface elements)
     You must inherit from the System.Windows.Forms.Form class, and you must include the attribute that connects your custom form 
     to it's respective designer.
    This custom form is used to create a scroll-bar popup that allows the user to choose a value and confirm/cancel.*/
    
    
    [Designer(typeof(NumericInputFormDesigner))]
    partial class NumericInputForm : Form
    {
        public int Number { get; set; }

        public NumericInputForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            trackBar1 = new TrackBar();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            ((ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(147, 9);
            label1.Name = "label1";
            label1.Size = new Size(194, 25);
            label1.TabIndex = 0;
            label1.Text = "Select thickness value";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 103);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(490, 45);
            trackBar1.TabIndex = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // button1
            // 
            button1.Location = new Point(12, 179);
            button1.Name = "button1";
            button1.Size = new Size(128, 49);
            button1.TabIndex = 2;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(374, 179);
            button2.Name = "button2";
            button2.Size = new Size(128, 49);
            button2.TabIndex = 3;
            button2.Text = "Apply";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 85);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 4;
            label2.Text = "val";
            // 
            // NumericInputForm
            // 
            ClientSize = new Size(514, 261);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Name = "NumericInputForm";
            ((ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TrackBar trackBar1;
        private Button button1;
        private Button button2;
        private Label label2;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Number = trackBar1.Value;
            label2.Text = Number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.thickness = Number;           
            this.Close();
        }
    }
}
