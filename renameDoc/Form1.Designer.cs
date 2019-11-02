namespace renameDoc
{
    partial class Form1
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
            this.button_select = new System.Windows.Forms.Button();
            this.textBox_docDir = new System.Windows.Forms.TextBox();
            this.richTextBox_docList = new System.Windows.Forms.RichTextBox();
            this.textBox_fresh = new System.Windows.Forms.TextBox();
            this.textBox_rename = new System.Windows.Forms.TextBox();
            this.label_fresh = new System.Windows.Forms.Label();
            this.label_rename = new System.Windows.Forms.Label();
            this.richTextBox_rename = new System.Windows.Forms.RichTextBox();
            this.button_begin = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.label_select = new System.Windows.Forms.Label();
            this.textBox_select = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(12, 22);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "选择";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // textBox_docDir
            // 
            this.textBox_docDir.Location = new System.Drawing.Point(103, 22);
            this.textBox_docDir.Name = "textBox_docDir";
            this.textBox_docDir.Size = new System.Drawing.Size(571, 21);
            this.textBox_docDir.TabIndex = 1;
            // 
            // richTextBox_docList
            // 
            this.richTextBox_docList.Location = new System.Drawing.Point(12, 65);
            this.richTextBox_docList.Name = "richTextBox_docList";
            this.richTextBox_docList.Size = new System.Drawing.Size(662, 542);
            this.richTextBox_docList.TabIndex = 2;
            this.richTextBox_docList.Text = "";
            // 
            // textBox_fresh
            // 
            this.textBox_fresh.Location = new System.Drawing.Point(804, 24);
            this.textBox_fresh.Name = "textBox_fresh";
            this.textBox_fresh.Size = new System.Drawing.Size(284, 21);
            this.textBox_fresh.TabIndex = 5;
            // 
            // textBox_rename
            // 
            this.textBox_rename.Location = new System.Drawing.Point(804, 65);
            this.textBox_rename.Name = "textBox_rename";
            this.textBox_rename.Size = new System.Drawing.Size(284, 21);
            this.textBox_rename.TabIndex = 6;
            // 
            // label_fresh
            // 
            this.label_fresh.AutoSize = true;
            this.label_fresh.Location = new System.Drawing.Point(709, 31);
            this.label_fresh.Name = "label_fresh";
            this.label_fresh.Size = new System.Drawing.Size(89, 12);
            this.label_fresh.TabIndex = 7;
            this.label_fresh.Text = "刷新频率(秒)：";
            // 
            // label_rename
            // 
            this.label_rename.AutoSize = true;
            this.label_rename.Location = new System.Drawing.Point(711, 74);
            this.label_rename.Name = "label_rename";
            this.label_rename.Size = new System.Drawing.Size(77, 12);
            this.label_rename.TabIndex = 8;
            this.label_rename.Text = "重命名字符：";
            // 
            // richTextBox_rename
            // 
            this.richTextBox_rename.Location = new System.Drawing.Point(711, 262);
            this.richTextBox_rename.Name = "richTextBox_rename";
            this.richTextBox_rename.Size = new System.Drawing.Size(377, 345);
            this.richTextBox_rename.TabIndex = 9;
            this.richTextBox_rename.Text = "";
            // 
            // button_begin
            // 
            this.button_begin.Location = new System.Drawing.Point(711, 185);
            this.button_begin.Name = "button_begin";
            this.button_begin.Size = new System.Drawing.Size(85, 37);
            this.button_begin.TabIndex = 10;
            this.button_begin.Text = "开始";
            this.button_begin.UseVisualStyleBackColor = true;
            this.button_begin.Click += new System.EventHandler(this.button_begin_Click);
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(1003, 185);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(85, 37);
            this.button_end.TabIndex = 11;
            this.button_end.Text = "结束";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(713, 120);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(71, 12);
            this.label_select.TabIndex = 12;
            this.label_select.Text = "筛     选：";
            this.label_select.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_select
            // 
            this.textBox_select.Location = new System.Drawing.Point(804, 110);
            this.textBox_select.Name = "textBox_select";
            this.textBox_select.Size = new System.Drawing.Size(284, 21);
            this.textBox_select.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 634);
            this.Controls.Add(this.textBox_select);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_begin);
            this.Controls.Add(this.richTextBox_rename);
            this.Controls.Add(this.label_rename);
            this.Controls.Add(this.label_fresh);
            this.Controls.Add(this.textBox_rename);
            this.Controls.Add(this.textBox_fresh);
            this.Controls.Add(this.richTextBox_docList);
            this.Controls.Add(this.textBox_docDir);
            this.Controls.Add(this.button_select);
            this.Name = "Form1";
            this.Text = "暴躁的黄金五老牛";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.TextBox textBox_docDir;
        private System.Windows.Forms.RichTextBox richTextBox_docList;
        private System.Windows.Forms.TextBox textBox_fresh;
        private System.Windows.Forms.TextBox textBox_rename;
        private System.Windows.Forms.Label label_fresh;
        private System.Windows.Forms.Label label_rename;
        private System.Windows.Forms.RichTextBox richTextBox_rename;
        private System.Windows.Forms.Button button_begin;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.TextBox textBox_select;
    }
}

