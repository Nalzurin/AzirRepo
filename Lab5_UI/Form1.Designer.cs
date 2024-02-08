namespace Lab5_Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            packetsList = new ListBox();
            packetImage = new PictureBox();
            label3 = new Label();
            packetIdLabel = new Label();
            label4 = new Label();
            dateLabel = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)packetImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 23);
            label1.TabIndex = 1;
            label1.Text = "Packets";
            // 
            // packetsList
            // 
            packetsList.FormattingEnabled = true;
            packetsList.ItemHeight = 23;
            packetsList.Location = new Point(12, 35);
            packetsList.Name = "packetsList";
            packetsList.Size = new Size(586, 625);
            packetsList.TabIndex = 3;
            packetsList.Click += packetsList_Click;
            packetsList.DoubleClick += packetsList_DoubleClick;
            // 
            // packetImage
            // 
            packetImage.BackColor = Color.White;
            packetImage.Location = new Point(619, 148);
            packetImage.Name = "packetImage";
            packetImage.Size = new Size(512, 512);
            packetImage.TabIndex = 5;
            packetImage.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(619, 75);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 6;
            label3.Text = "Current Packet";
            // 
            // packetIdLabel
            // 
            packetIdLabel.AutoSize = true;
            packetIdLabel.Location = new Point(750, 75);
            packetIdLabel.Name = "packetIdLabel";
            packetIdLabel.Size = new Size(123, 23);
            packetIdLabel.TabIndex = 7;
            packetIdLabel.Text = "Current Packet";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(658, 109);
            label4.Name = "label4";
            label4.Size = new Size(84, 23);
            label4.TabIndex = 8;
            label4.Text = "Date Sent";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(750, 109);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(84, 23);
            dateLabel.TabIndex = 9;
            dateLabel.Text = "Date Sent";
            // 
            // button1
            // 
            button1.Location = new Point(86, 0);
            button1.Name = "button1";
            button1.Size = new Size(96, 35);
            button1.TabIndex = 10;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 690);
            Controls.Add(button1);
            Controls.Add(dateLabel);
            Controls.Add(label4);
            Controls.Add(packetIdLabel);
            Controls.Add(label3);
            Controls.Add(packetImage);
            Controls.Add(packetsList);
            Controls.Add(label1);
            Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "PacketsApp";
            ((System.ComponentModel.ISupportInitialize)packetImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox packetsList;
        private PictureBox packetImage;
        private Label label3;
        private Label packetIdLabel;
        private Label label4;
        private Label dateLabel;
        private Button button1;
    }
}
