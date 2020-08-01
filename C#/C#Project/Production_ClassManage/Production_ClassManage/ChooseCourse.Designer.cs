namespace Production_ClassManage
{
    partial class ChooseCourse
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
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.学号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.课程号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成绩 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSid = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScores = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.labCourse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCourse
            // 
            this.cmbCourse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(139, 4);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(159, 22);
            this.cmbCourse.TabIndex = 0;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "欢迎进入选课，每个学生可最多选取三门课程进行选修";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前可选课程有：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "选择要选课的学生：";
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.学号,
            this.课程号,
            this.成绩});
            this.dataView.Location = new System.Drawing.Point(335, 12);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowTemplate.Height = 23;
            this.dataView.Size = new System.Drawing.Size(338, 314);
            this.dataView.TabIndex = 6;
            this.dataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellClick);
            // 
            // 学号
            // 
            this.学号.DataPropertyName = "学号";
            this.学号.HeaderText = "学号";
            this.学号.Name = "学号";
            this.学号.ReadOnly = true;
            // 
            // 课程号
            // 
            this.课程号.DataPropertyName = "课程号";
            this.课程号.HeaderText = "课程号";
            this.课程号.Name = "课程号";
            this.课程号.ReadOnly = true;
            // 
            // 成绩
            // 
            this.成绩.DataPropertyName = "成绩";
            this.成绩.HeaderText = "成绩";
            this.成绩.Name = "成绩";
            this.成绩.ReadOnly = true;
            // 
            // cmbSid
            // 
            this.cmbSid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSid.FormattingEnabled = true;
            this.cmbSid.Location = new System.Drawing.Point(139, 74);
            this.cmbSid.Name = "cmbSid";
            this.cmbSid.Size = new System.Drawing.Size(159, 22);
            this.cmbSid.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "查看全部信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "录入此学生的成绩：";
            // 
            // txtScores
            // 
            this.txtScores.Location = new System.Drawing.Point(139, 179);
            this.txtScores.Name = "txtScores";
            this.txtScores.Size = new System.Drawing.Size(159, 21);
            this.txtScores.TabIndex = 10;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(200, 236);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(98, 23);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "确认录入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(58, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "查询该学生选课信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(220, 125);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(78, 23);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "确认选课";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // labCourse
            // 
            this.labCourse.AutoSize = true;
            this.labCourse.Location = new System.Drawing.Point(137, 42);
            this.labCourse.Name = "labCourse";
            this.labCourse.Size = new System.Drawing.Size(113, 12);
            this.labCourse.TabIndex = 13;
            this.labCourse.Text = "当前课程选修数为：";
            // 
            // ChooseCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 367);
            this.Controls.Add(this.labCourse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtScores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbSid);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCourse);
            this.Name = "ChooseCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选课界面";
            this.Load += new System.EventHandler(this.ChooseCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.ComboBox cmbSid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 课程号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成绩;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScores;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label labCourse;
    }
}