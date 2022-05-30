namespace ExBinder
{
    partial class Form1
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
            this.btnBindAndRun = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBindAndRun
            // 
            this.btnBindAndRun.Location = new System.Drawing.Point(47, 43);
            this.btnBindAndRun.Name = "btnBindAndRun";
            this.btnBindAndRun.Size = new System.Drawing.Size(114, 23);
            this.btnBindAndRun.TabIndex = 0;
            this.btnBindAndRun.Text = "Bind Dynamicaly";
            this.btnBindAndRun.UseVisualStyleBackColor = true;
            this.btnBindAndRun.Click += new System.EventHandler(this.btnBindAndRun_Click);
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(167, 43);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(110, 23);
            this.btnUnload.TabIndex = 1;
            this.btnUnload.Text = "Unload Domain";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 127);
            this.Controls.Add(this.btnUnload);
            this.Controls.Add(this.btnBindAndRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dynamic Binding Invoker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBindAndRun;
        private System.Windows.Forms.Button btnUnload;
    }
}

