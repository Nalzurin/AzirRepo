namespace Lab1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            setCountryButton = new Button();
            suggestionCountryListBox = new ListBox();
            countryFlag = new PictureBox();
            temperatureLabel = new Label();
            humidityLabel = new Label();
            pressureLabel = new Label();
            countryName = new TextBox();
            changeCountry = new Button();
            countryLabel = new Label();
            currentCountryLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)countryFlag).BeginInit();
            SuspendLayout();
            // 
            // setCountryButton
            // 
            setCountryButton.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            setCountryButton.ForeColor = Color.Black;
            setCountryButton.Location = new Point(364, 24);
            setCountryButton.Name = "setCountryButton";
            setCountryButton.Size = new Size(110, 32);
            setCountryButton.TabIndex = 2;
            setCountryButton.Text = "Set";
            setCountryButton.UseVisualStyleBackColor = true;
            setCountryButton.Click += setCountryButton_Click;
            // 
            // suggestionCountryListBox
            // 
            suggestionCountryListBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            suggestionCountryListBox.FormattingEnabled = true;
            suggestionCountryListBox.ItemHeight = 18;
            suggestionCountryListBox.Location = new Point(101, 56);
            suggestionCountryListBox.Name = "suggestionCountryListBox";
            suggestionCountryListBox.Size = new Size(257, 76);
            suggestionCountryListBox.TabIndex = 3;
            suggestionCountryListBox.Visible = false;
            suggestionCountryListBox.SelectedIndexChanged += suggestionCountryListBox_SelectedIndexChanged;
            // 
            // countryFlag
            // 
            countryFlag.BackColor = Color.Transparent;
            countryFlag.BackgroundImageLayout = ImageLayout.None;
            countryFlag.Location = new Point(603, 28);
            countryFlag.Name = "countryFlag";
            countryFlag.Size = new Size(100, 50);
            countryFlag.SizeMode = PictureBoxSizeMode.Zoom;
            countryFlag.TabIndex = 4;
            countryFlag.TabStop = false;
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.BackColor = Color.Transparent;
            temperatureLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            temperatureLabel.ForeColor = Color.Black;
            temperatureLabel.Location = new Point(226, 178);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(132, 24);
            temperatureLabel.TabIndex = 7;
            temperatureLabel.Text = "Temperature:";
            // 
            // humidityLabel
            // 
            humidityLabel.AutoSize = true;
            humidityLabel.BackColor = Color.Transparent;
            humidityLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            humidityLabel.ForeColor = Color.Black;
            humidityLabel.Location = new Point(226, 212);
            humidityLabel.Name = "humidityLabel";
            humidityLabel.Size = new Size(95, 24);
            humidityLabel.TabIndex = 8;
            humidityLabel.Text = "Humidity:";
            // 
            // pressureLabel
            // 
            pressureLabel.AutoSize = true;
            pressureLabel.BackColor = Color.Transparent;
            pressureLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pressureLabel.ForeColor = Color.Black;
            pressureLabel.Location = new Point(226, 246);
            pressureLabel.Name = "pressureLabel";
            pressureLabel.Size = new Size(101, 24);
            pressureLabel.TabIndex = 9;
            pressureLabel.Text = "Pressure:";
            // 
            // countryName
            // 
            countryName.BackColor = Color.White;
            countryName.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countryName.ForeColor = SystemColors.WindowText;
            countryName.Location = new Point(101, 24);
            countryName.Name = "countryName";
            countryName.Size = new Size(257, 32);
            countryName.TabIndex = 10;
            countryName.TextChanged += countryName_TextChanged;
            // 
            // changeCountry
            // 
            changeCountry.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changeCountry.ForeColor = Color.Black;
            changeCountry.Location = new Point(599, 84);
            changeCountry.Name = "changeCountry";
            changeCountry.Size = new Size(110, 32);
            changeCountry.TabIndex = 11;
            changeCountry.Text = "Change";
            changeCountry.UseVisualStyleBackColor = true;
            changeCountry.Visible = false;
            changeCountry.Click += changeCountry_Click;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.BackColor = Color.Transparent;
            countryLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countryLabel.ForeColor = Color.Black;
            countryLabel.Location = new Point(12, 28);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(83, 24);
            countryLabel.TabIndex = 1;
            countryLabel.Text = "Country";
            // 
            // currentCountryLabel
            // 
            currentCountryLabel.AutoSize = true;
            currentCountryLabel.BackColor = Color.Transparent;
            currentCountryLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentCountryLabel.ForeColor = Color.Black;
            currentCountryLabel.Location = new Point(603, 1);
            currentCountryLabel.Name = "currentCountryLabel";
            currentCountryLabel.Size = new Size(83, 24);
            currentCountryLabel.TabIndex = 12;
            currentCountryLabel.Text = "Country";
            currentCountryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(currentCountryLabel);
            Controls.Add(changeCountry);
            Controls.Add(pressureLabel);
            Controls.Add(humidityLabel);
            Controls.Add(temperatureLabel);
            Controls.Add(countryFlag);
            Controls.Add(suggestionCountryListBox);
            Controls.Add(setCountryButton);
            Controls.Add(countryLabel);
            Controls.Add(countryName);
            Name = "Form1";
            Text = "Weather";
            ((System.ComponentModel.ISupportInitialize)countryFlag).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button setCountryButton;
        private ListBox suggestionCountryListBox;
        private PictureBox countryFlag;
        private Label temperatureLabel;
        private Label humidityLabel;
        private Label pressureLabel;
        private TextBox countryName;
        private Button changeCountry;
        private Label countryLabel;
        private Label currentCountryLabel;
    }
}
