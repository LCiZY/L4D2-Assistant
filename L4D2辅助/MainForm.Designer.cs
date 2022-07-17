
namespace L4D2辅助
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.checkBox_LD = new System.Windows.Forms.CheckBox();
            this.checkBox_SK = new System.Windows.Forms.CheckBox();
            this.checkBox_LT = new System.Windows.Forms.CheckBox();
            this.label_LT = new System.Windows.Forms.Label();
            this.label_SK = new System.Windows.Forms.Label();
            this.label_LD = new System.Windows.Forms.Label();
            this.config_key_SK = new System.Windows.Forms.TextBox();
            this.config_key_LD = new System.Windows.Forms.TextBox();
            this.LT_spec_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox_LD
            // 
            this.checkBox_LD.AutoSize = true;
            this.checkBox_LD.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_LD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LD.ForeColor = System.Drawing.Color.Black;
            this.checkBox_LD.Location = new System.Drawing.Point(418, 35);
            this.checkBox_LD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_LD.Name = "checkBox_LD";
            this.checkBox_LD.Size = new System.Drawing.Size(74, 28);
            this.checkBox_LD.TabIndex = 7;
            this.checkBox_LD.Text = "连点";
            this.checkBox_LD.UseVisualStyleBackColor = false;
            // 
            // checkBox_SK
            // 
            this.checkBox_SK.AutoSize = true;
            this.checkBox_SK.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_SK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SK.ForeColor = System.Drawing.Color.Black;
            this.checkBox_SK.Location = new System.Drawing.Point(231, 35);
            this.checkBox_SK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_SK.Name = "checkBox_SK";
            this.checkBox_SK.Size = new System.Drawing.Size(74, 28);
            this.checkBox_SK.TabIndex = 6;
            this.checkBox_SK.Text = "速砍";
            this.checkBox_SK.UseVisualStyleBackColor = false;
            // 
            // checkBox_LT
            // 
            this.checkBox_LT.AutoSize = true;
            this.checkBox_LT.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_LT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LT.ForeColor = System.Drawing.Color.Black;
            this.checkBox_LT.Location = new System.Drawing.Point(55, 35);
            this.checkBox_LT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_LT.Name = "checkBox_LT";
            this.checkBox_LT.Size = new System.Drawing.Size(74, 28);
            this.checkBox_LT.TabIndex = 5;
            this.checkBox_LT.Text = "连跳";
            this.checkBox_LT.UseVisualStyleBackColor = false;
            this.checkBox_LT.CheckedChanged += new System.EventHandler(this.findL4D2PID);
            // 
            // label_LT
            // 
            this.label_LT.AutoSize = true;
            this.label_LT.BackColor = System.Drawing.Color.Transparent;
            this.label_LT.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LT.ForeColor = System.Drawing.Color.Black;
            this.label_LT.Location = new System.Drawing.Point(55, 74);
            this.label_LT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LT.Name = "label_LT";
            this.label_LT.Size = new System.Drawing.Size(0, 29);
            this.label_LT.TabIndex = 10;
            // 
            // label_SK
            // 
            this.label_SK.AutoSize = true;
            this.label_SK.BackColor = System.Drawing.Color.Transparent;
            this.label_SK.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SK.ForeColor = System.Drawing.Color.Black;
            this.label_SK.Location = new System.Drawing.Point(231, 74);
            this.label_SK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SK.Name = "label_SK";
            this.label_SK.Size = new System.Drawing.Size(0, 29);
            this.label_SK.TabIndex = 9;
            // 
            // label_LD
            // 
            this.label_LD.AutoSize = true;
            this.label_LD.BackColor = System.Drawing.Color.Transparent;
            this.label_LD.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LD.ForeColor = System.Drawing.Color.Black;
            this.label_LD.Location = new System.Drawing.Point(418, 74);
            this.label_LD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LD.Name = "label_LD";
            this.label_LD.Size = new System.Drawing.Size(0, 29);
            this.label_LD.TabIndex = 8;
            // 
            // config_key_SK
            // 
            this.config_key_SK.Location = new System.Drawing.Point(231, 72);
            this.config_key_SK.Name = "config_key_SK";
            this.config_key_SK.Size = new System.Drawing.Size(120, 28);
            this.config_key_SK.TabIndex = 12;
            this.config_key_SK.Text = "按住Z";
            this.config_key_SK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.config_key_SK_Click);
            this.config_key_SK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.config_key_SK_KeyDown);
            // 
            // config_key_LD
            // 
            this.config_key_LD.Location = new System.Drawing.Point(418, 72);
            this.config_key_LD.Name = "config_key_LD";
            this.config_key_LD.Size = new System.Drawing.Size(120, 28);
            this.config_key_LD.TabIndex = 13;
            this.config_key_LD.Text = "按住X";
            this.config_key_LD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.config_key_LD_Click);
            this.config_key_LD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.config_key_LD_KeyDown);
            // 
            // LT_spec_label
            // 
            this.LT_spec_label.AutoSize = true;
            this.LT_spec_label.BackColor = System.Drawing.Color.Transparent;
            this.LT_spec_label.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LT_spec_label.ForeColor = System.Drawing.Color.Black;
            this.LT_spec_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LT_spec_label.Location = new System.Drawing.Point(57, 74);
            this.LT_spec_label.Name = "LT_spec_label";
            this.LT_spec_label.Size = new System.Drawing.Size(80, 18);
            this.LT_spec_label.TabIndex = 14;
            this.LT_spec_label.Text = "按住空格";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_Click);
            this.Deactivate += new System.EventHandler(this.Form_Deactivate);
            this.Activated += new System.EventHandler(this.Form_Activate);
            
            this.ClientSize = new System.Drawing.Size(576, 329);
            this.Controls.Add(this.LT_spec_label);
            this.Controls.Add(this.config_key_LD);
            this.Controls.Add(this.config_key_SK);
            this.Controls.Add(this.label_LT);
            this.Controls.Add(this.label_SK);
            this.Controls.Add(this.label_LD);
            this.Controls.Add(this.checkBox_LD);
            this.Controls.Add(this.checkBox_SK);
            this.Controls.Add(this.checkBox_LT);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "L4D2辅助";
            this.Load += new System.EventHandler(this.Init);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_LD;
        private System.Windows.Forms.CheckBox checkBox_SK;
        private System.Windows.Forms.CheckBox checkBox_LT;
        private System.Windows.Forms.Label label_LT;
        private System.Windows.Forms.Label label_SK;
        private System.Windows.Forms.Label label_LD;
        private System.Windows.Forms.TextBox config_key_SK;
        private System.Windows.Forms.TextBox config_key_LD;
        private System.Windows.Forms.Label LT_spec_label;
    }
}

