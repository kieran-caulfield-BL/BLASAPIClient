namespace ActionstepApiClient
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoBasic = new System.Windows.Forms.RadioButton();
            this.rdoNTLM = new System.Windows.Forms.RadioButton();
            this.rdoOAuth2 = new System.Windows.Forms.RadioButton();
            this.rdoRollYourOwn = new System.Windows.Forms.RadioButton();
            this.rdoNetCred = new System.Windows.Forms.RadioButton();
            this.rdoBearer = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(91, 8);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(323, 20);
            this.txtURL.TabIndex = 0;
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(91, 182);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(404, 148);
            this.txtResponse.TabIndex = 1;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(420, 4);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(75, 23);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "GO!";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Request URL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Response";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(91, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(142, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(314, 34);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(100, 20);
            this.txtPassWord.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(255, 41);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 7;
            this.Password.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Userid";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoOAuth2);
            this.groupBox1.Controls.Add(this.rdoNTLM);
            this.groupBox1.Controls.Add(this.rdoBasic);
            this.groupBox1.Location = new System.Drawing.Point(91, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auth Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoBearer);
            this.groupBox2.Controls.Add(this.rdoNetCred);
            this.groupBox2.Controls.Add(this.rdoRollYourOwn);
            this.groupBox2.Location = new System.Drawing.Point(272, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Technique";
            // 
            // rdoBasic
            // 
            this.rdoBasic.AutoSize = true;
            this.rdoBasic.Location = new System.Drawing.Point(17, 19);
            this.rdoBasic.Name = "rdoBasic";
            this.rdoBasic.Size = new System.Drawing.Size(51, 17);
            this.rdoBasic.TabIndex = 0;
            this.rdoBasic.TabStop = true;
            this.rdoBasic.Text = "Basic";
            this.rdoBasic.UseVisualStyleBackColor = true;
            this.rdoBasic.CheckedChanged += new System.EventHandler(this.rdoBasic_CheckedChanged);
            // 
            // rdoNTLM
            // 
            this.rdoNTLM.AutoSize = true;
            this.rdoNTLM.Location = new System.Drawing.Point(17, 42);
            this.rdoNTLM.Name = "rdoNTLM";
            this.rdoNTLM.Size = new System.Drawing.Size(55, 17);
            this.rdoNTLM.TabIndex = 1;
            this.rdoNTLM.TabStop = true;
            this.rdoNTLM.Text = "NTLM";
            this.rdoNTLM.UseVisualStyleBackColor = true;
            this.rdoNTLM.CheckedChanged += new System.EventHandler(this.rdoNTLM_CheckedChanged);
            // 
            // rdoOAuth2
            // 
            this.rdoOAuth2.AutoSize = true;
            this.rdoOAuth2.Location = new System.Drawing.Point(17, 65);
            this.rdoOAuth2.Name = "rdoOAuth2";
            this.rdoOAuth2.Size = new System.Drawing.Size(64, 17);
            this.rdoOAuth2.TabIndex = 2;
            this.rdoOAuth2.TabStop = true;
            this.rdoOAuth2.Text = "OAuth 2";
            this.rdoOAuth2.UseVisualStyleBackColor = true;
            this.rdoOAuth2.CheckedChanged += new System.EventHandler(this.rdoOAuth2_CheckedChanged);
            // 
            // rdoRollYourOwn
            // 
            this.rdoRollYourOwn.AutoSize = true;
            this.rdoRollYourOwn.Location = new System.Drawing.Point(20, 19);
            this.rdoRollYourOwn.Name = "rdoRollYourOwn";
            this.rdoRollYourOwn.Size = new System.Drawing.Size(87, 17);
            this.rdoRollYourOwn.TabIndex = 1;
            this.rdoRollYourOwn.TabStop = true;
            this.rdoRollYourOwn.Text = "RollYourOwn";
            this.rdoRollYourOwn.UseVisualStyleBackColor = true;
            this.rdoRollYourOwn.CheckedChanged += new System.EventHandler(this.rdoRollYourOwn_CheckedChanged);
            // 
            // rdoNetCred
            // 
            this.rdoNetCred.AutoSize = true;
            this.rdoNetCred.Location = new System.Drawing.Point(20, 42);
            this.rdoNetCred.Name = "rdoNetCred";
            this.rdoNetCred.Size = new System.Drawing.Size(89, 17);
            this.rdoNetCred.TabIndex = 2;
            this.rdoNetCred.TabStop = true;
            this.rdoNetCred.Text = "NetCredential";
            this.rdoNetCred.UseVisualStyleBackColor = true;
            this.rdoNetCred.CheckedChanged += new System.EventHandler(this.rdoNetCred_CheckedChanged);
            // 
            // rdoBearer
            // 
            this.rdoBearer.AutoSize = true;
            this.rdoBearer.Location = new System.Drawing.Point(20, 65);
            this.rdoBearer.Name = "rdoBearer";
            this.rdoBearer.Size = new System.Drawing.Size(56, 17);
            this.rdoBearer.TabIndex = 3;
            this.rdoBearer.TabStop = true;
            this.rdoBearer.Text = "Bearer";
            this.rdoBearer.UseVisualStyleBackColor = true;
            this.rdoBearer.CheckedChanged += new System.EventHandler(this.rdoBearer_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 342);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtURL);
            this.Name = "Form1";
            this.Text = "c# Rest Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoOAuth2;
        private System.Windows.Forms.RadioButton rdoNTLM;
        private System.Windows.Forms.RadioButton rdoBasic;
        private System.Windows.Forms.RadioButton rdoBearer;
        private System.Windows.Forms.RadioButton rdoNetCred;
        private System.Windows.Forms.RadioButton rdoRollYourOwn;
    }
}

