
namespace TMP_SeaBattle
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(160, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(182, 30);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "SEA BATTLE";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.BackColor = System.Drawing.Color.White;
            this.ipLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ipLabel.Location = new System.Drawing.Point(20, 80);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(173, 19);
            this.ipLabel.TabIndex = 1;
            this.ipLabel.Text = "Введите адрес сервера:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.BackColor = System.Drawing.Color.White;
            this.portLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.portLabel.Location = new System.Drawing.Point(20, 120);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(163, 19);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Введите порт сервера:";
            // 
            // ipInput
            // 
            this.ipInput.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ipInput.Location = new System.Drawing.Point(240, 77);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(192, 27);
            this.ipInput.TabIndex = 3;
            // 
            // portInput
            // 
            this.portInput.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.portInput.Location = new System.Drawing.Point(240, 117);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(192, 27);
            this.portInput.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.Location = new System.Drawing.Point(180, 160);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 40);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Начать!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.Button startButton;
    }
}

