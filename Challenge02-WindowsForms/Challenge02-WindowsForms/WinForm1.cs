using System;
using System.Windows.Forms;
using System.Drawing;


class MyForm : Form
{
    private Label label1;
    private ComboBox comboBox1;
    private Button button1;

    public MyForm() 
    {
        // Change the caption of the application
        Text = "Hello World!";
        /*
        BackColor = Color.Azure;
        
        MaximizeBox = false;
        MinimizeBox = false;
        //Hide();
        //Opacity = 10;
        //Visible = false;
        //WindowState = FormWindowState.Maximized;
        StartPosition = FormStartPosition.Manual;
        Location = new Point(-10, 0);
        Height = 200;
        Width = 200;
        */
    }

    static void Main()
    {
        MyForm myForm = new MyForm();

        // Display the form
        Application.Run(myForm);
    }

    private void InitializeComponent()
    {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 96);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // MyForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

}