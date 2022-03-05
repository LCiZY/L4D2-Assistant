
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
            this.SuspendLayout();

            // 
            // checkBox_LT
            // 
            this.checkBox_LT.AutoSize = true;
            this.checkBox_LT.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_LT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LT.ForeColor = System.Drawing.Color.Black;
            this.checkBox_LT.Location = new System.Drawing.Point(49, 29);
            this.checkBox_LT.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_LT.Name = "checkBox_LT";
            this.checkBox_LT.Size = new System.Drawing.Size(74, 28);
            this.checkBox_LT.TabIndex = 5;
            this.checkBox_LT.Text = "连跳";
            this.checkBox_LT.UseVisualStyleBackColor = false;
            this.checkBox_LT.CheckedChanged += new System.EventHandler(this.findL4D2PID);
            // 
            // checkBox_SK
            // 
            this.checkBox_SK.AutoSize = true;
            this.checkBox_SK.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_SK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SK.ForeColor = System.Drawing.Color.Black;
            this.checkBox_SK.Location = new System.Drawing.Point(205, 29);
            this.checkBox_SK.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_SK.Name = "checkBox_SK";
            this.checkBox_SK.Size = new System.Drawing.Size(74, 28);
            this.checkBox_SK.TabIndex = 6;
            this.checkBox_SK.Text = "速砍";
            this.checkBox_SK.UseVisualStyleBackColor = false;
            // 
            // checkBox_LD
            // 
            this.checkBox_LD.AutoSize = true;
            this.checkBox_LD.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_LD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LD.ForeColor = System.Drawing.Color.Black;
            this.checkBox_LD.Location = new System.Drawing.Point(372, 29);
            this.checkBox_LD.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_LD.Name = "checkBox_LD";
            this.checkBox_LD.Size = new System.Drawing.Size(74, 28);
            this.checkBox_LD.TabIndex = 7;
            this.checkBox_LD.Text = "连点";
            this.checkBox_LD.UseVisualStyleBackColor = false;
            // 
            // label_LT
            // 
            this.label_LT.AutoSize = true;
            this.label_LT.BackColor = System.Drawing.Color.Transparent;
            this.label_LT.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LT.ForeColor = System.Drawing.Color.Black;
            this.label_LT.Location = new System.Drawing.Point(49, 62);
            this.label_LT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LT.Name = "label_LT";
            this.label_LT.Size = new System.Drawing.Size(111, 29);
            this.label_LT.TabIndex = 10;
            this.label_LT.Text = "(按住空格)";
            // 
            // label_SK
            // 
            this.label_SK.AutoSize = true;
            this.label_SK.BackColor = System.Drawing.Color.Transparent;
            this.label_SK.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SK.ForeColor = System.Drawing.Color.Black;
            this.label_SK.Location = new System.Drawing.Point(205, 62);
            this.label_SK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SK.Name = "label_SK";
            this.label_SK.Size = new System.Drawing.Size(83, 29);
            this.label_SK.TabIndex = 9;
            this.label_SK.Text = "(按住X)";
            // 
            // label_LD
            // 
            this.label_LD.AutoSize = true;
            this.label_LD.BackColor = System.Drawing.Color.Transparent;
            this.label_LD.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LD.ForeColor = System.Drawing.Color.Black;
            this.label_LD.Location = new System.Drawing.Point(372, 62);
            this.label_LD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LD.Name = "label_LD";
            this.label_LD.Size = new System.Drawing.Size(83, 29);
            this.label_LD.TabIndex = 8;
            this.label_LD.Text = "(按住T)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(512, 274);
            this.Controls.Add(this.label_LT);
            this.Controls.Add(this.label_SK);
            this.Controls.Add(this.label_LD);
            this.Controls.Add(this.checkBox_LD);
            this.Controls.Add(this.checkBox_SK);
            this.Controls.Add(this.checkBox_LT);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

