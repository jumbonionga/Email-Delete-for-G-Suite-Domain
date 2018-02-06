namespace Email_Delete_for_Google_Apps_Domain
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
            this.label1 = new System.Windows.Forms.Label();
            this.Execute = new System.Windows.Forms.Button();
            this.MessageID = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message ID";
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(636, 19);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(75, 47);
            this.Execute.TabIndex = 1;
            this.Execute.Text = "Authorize and Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // MessageID
            // 
            this.MessageID.Location = new System.Drawing.Point(82, 33);
            this.MessageID.Name = "MessageID";
            this.MessageID.Size = new System.Drawing.Size(521, 20);
            this.MessageID.TabIndex = 2;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(12, 65);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 261);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.MessageID);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Email Delete for Google Apps Domain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.TextBox MessageID;
        private System.Windows.Forms.Label Status;
    }
}

