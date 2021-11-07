
namespace WinformCipher
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
            this.cipherComboBox = new System.Windows.Forms.ComboBox();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.ivTextBox = new System.Windows.Forms.TextBox();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.inputFileButton = new System.Windows.Forms.Button();
            this.outputFileButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.paddingModeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cipherComboBox
            // 
            this.cipherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cipherComboBox.FormattingEnabled = true;
            this.cipherComboBox.Location = new System.Drawing.Point(39, 30);
            this.cipherComboBox.Name = "cipherComboBox";
            this.cipherComboBox.Size = new System.Drawing.Size(260, 23);
            this.cipherComboBox.TabIndex = 0;
            this.cipherComboBox.SelectedIndexChanged += new System.EventHandler(this.cipherComboBox_SelectedIndexChanged);
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(39, 117);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(124, 23);
            this.modeComboBox.TabIndex = 1;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(39, 59);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PlaceholderText = "Key";
            this.keyTextBox.Size = new System.Drawing.Size(260, 23);
            this.keyTextBox.TabIndex = 2;
            this.keyTextBox.TextChanged += new System.EventHandler(this.keyTextBox_TextChanged);
            // 
            // ivTextBox
            // 
            this.ivTextBox.Location = new System.Drawing.Point(39, 88);
            this.ivTextBox.Name = "ivTextBox";
            this.ivTextBox.PlaceholderText = "IV";
            this.ivTextBox.Size = new System.Drawing.Size(260, 23);
            this.ivTextBox.TabIndex = 3;
            this.ivTextBox.TextChanged += new System.EventHandler(this.ivTextBox_TextChanged);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(39, 196);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.PlaceholderText = "Input path";
            this.inputFileTextBox.Size = new System.Drawing.Size(124, 23);
            this.inputFileTextBox.TabIndex = 4;
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Location = new System.Drawing.Point(175, 196);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.PlaceholderText = "Output path";
            this.outputFileTextBox.Size = new System.Drawing.Size(124, 23);
            this.outputFileTextBox.TabIndex = 5;
            // 
            // inputFileButton
            // 
            this.inputFileButton.Location = new System.Drawing.Point(39, 167);
            this.inputFileButton.Name = "inputFileButton";
            this.inputFileButton.Size = new System.Drawing.Size(124, 23);
            this.inputFileButton.TabIndex = 6;
            this.inputFileButton.Text = "Select input file";
            this.inputFileButton.UseVisualStyleBackColor = true;
            this.inputFileButton.Click += new System.EventHandler(this.inputFileButton_Click);
            // 
            // outputFileButton
            // 
            this.outputFileButton.Location = new System.Drawing.Point(175, 167);
            this.outputFileButton.Name = "outputFileButton";
            this.outputFileButton.Size = new System.Drawing.Size(124, 23);
            this.outputFileButton.TabIndex = 7;
            this.outputFileButton.Text = "Select output file";
            this.outputFileButton.UseVisualStyleBackColor = true;
            this.outputFileButton.Click += new System.EventHandler(this.outputFileButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(39, 250);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(124, 23);
            this.encryptButton.TabIndex = 8;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(175, 250);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(124, 23);
            this.decryptButton.TabIndex = 9;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // paddingModeComboBox
            // 
            this.paddingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paddingModeComboBox.FormattingEnabled = true;
            this.paddingModeComboBox.Location = new System.Drawing.Point(175, 117);
            this.paddingModeComboBox.Name = "paddingModeComboBox";
            this.paddingModeComboBox.Size = new System.Drawing.Size(124, 23);
            this.paddingModeComboBox.TabIndex = 10;
            this.paddingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.paddingModeComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 297);
            this.Controls.Add(this.paddingModeComboBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.outputFileButton);
            this.Controls.Add(this.inputFileButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.inputFileTextBox);
            this.Controls.Add(this.ivTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.cipherComboBox);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cipherComboBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.TextBox ivTextBox;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Button inputFileButton;
        private System.Windows.Forms.Button outputFileButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.ComboBox paddingModeComboBox;
    }
}

