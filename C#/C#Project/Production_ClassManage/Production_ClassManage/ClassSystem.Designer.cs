namespace Production_ClassManage
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
            this.dataView = new System.Windows.Forms.DataGridView();
            this.SID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Specialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AScores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtScorse = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbSpec = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BirthdayData = new System.Windows.Forms.DateTimePicker();
            this.btnBrowsePic = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.SexBox = new System.Windows.Forms.GroupBox();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.rdoMen = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataTable = new System.Windows.Forms.GroupBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPageTo = new System.Windows.Forms.Button();
            this.btnPageEnd = new System.Windows.Forms.Button();
            this.btnPageOn = new System.Windows.Forms.Button();
            this.btnPageNext = new System.Windows.Forms.Button();
            this.btnfirstPage = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.labNow = new System.Windows.Forms.Label();
            this.btnOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SexBox.SuspendLayout();
            this.dataTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SID,
            this.Sname,
            this.Sex,
            this.Birthdate,
            this.Specialty,
            this.AScores,
            this.logo});
            this.dataView.Location = new System.Drawing.Point(6, 20);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowTemplate.Height = 23;
            this.dataView.Size = new System.Drawing.Size(915, 168);
            this.dataView.TabIndex = 0;
            this.dataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellClick);
            // 
            // SID
            // 
            this.SID.DataPropertyName = "SID";
            this.SID.HeaderText = "学号";
            this.SID.Name = "SID";
            this.SID.ReadOnly = true;
            this.SID.Width = 150;
            // 
            // Sname
            // 
            this.Sname.DataPropertyName = "Sname";
            this.Sname.HeaderText = "姓名";
            this.Sname.Name = "Sname";
            this.Sname.ReadOnly = true;
            this.Sname.Width = 120;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // Birthdate
            // 
            this.Birthdate.DataPropertyName = "Birthdate";
            this.Birthdate.HeaderText = "生日";
            this.Birthdate.Name = "Birthdate";
            this.Birthdate.ReadOnly = true;
            this.Birthdate.Width = 150;
            // 
            // Specialty
            // 
            this.Specialty.DataPropertyName = "Specialty";
            this.Specialty.HeaderText = "专业";
            this.Specialty.Name = "Specialty";
            this.Specialty.ReadOnly = true;
            this.Specialty.Width = 150;
            // 
            // AScores
            // 
            this.AScores.DataPropertyName = "AScores";
            this.AScores.HeaderText = "成绩";
            this.AScores.Name = "AScores";
            this.AScores.ReadOnly = true;
            // 
            // logo
            // 
            this.logo.DataPropertyName = "logo";
            this.logo.HeaderText = "头像";
            this.logo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.logo.Name = "logo";
            this.logo.ReadOnly = true;
            this.logo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.logo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnCourse);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.txtScorse);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CmbSpec);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BirthdayData);
            this.groupBox1.Controls.Add(this.btnBrowsePic);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PicBox);
            this.groupBox1.Controls.Add(this.SexBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生信息录入及相关操作：";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(233, 29);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 23);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(645, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "退出系统";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(399, 163);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(75, 23);
            this.btnCourse.TabIndex = 19;
            this.btnCourse.Text = "进入选课";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(276, 163);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(153, 163);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(30, 163);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "添加";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtScorse
            // 
            this.txtScorse.Location = new System.Drawing.Point(586, 88);
            this.txtScorse.Name = "txtScorse";
            this.txtScorse.Size = new System.Drawing.Size(119, 21);
            this.txtScorse.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(539, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "成绩：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "专业：";
            // 
            // CmbSpec
            // 
            this.CmbSpec.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbSpec.FormattingEnabled = true;
            this.CmbSpec.Location = new System.Drawing.Point(347, 89);
            this.CmbSpec.Name = "CmbSpec";
            this.CmbSpec.Size = new System.Drawing.Size(152, 20);
            this.CmbSpec.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "出生日期：";
            // 
            // BirthdayData
            // 
            this.BirthdayData.Location = new System.Drawing.Point(75, 88);
            this.BirthdayData.Name = "BirthdayData";
            this.BirthdayData.Size = new System.Drawing.Size(202, 21);
            this.BirthdayData.TabIndex = 9;
            // 
            // btnBrowsePic
            // 
            this.btnBrowsePic.Location = new System.Drawing.Point(804, 173);
            this.btnBrowsePic.Name = "btnBrowsePic";
            this.btnBrowsePic.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePic.TabIndex = 8;
            this.btnBrowsePic.Text = "浏览";
            this.btnBrowsePic.UseVisualStyleBackColor = true;
            this.btnBrowsePic.Click += new System.EventHandler(this.btnBrowsePic_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(715, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "选择头像：";
            // 
            // PicBox
            // 
            this.PicBox.Location = new System.Drawing.Point(785, 30);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(115, 124);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox.TabIndex = 6;
            this.PicBox.TabStop = false;
            // 
            // SexBox
            // 
            this.SexBox.Controls.Add(this.rdoWomen);
            this.SexBox.Controls.Add(this.rdoMen);
            this.SexBox.Location = new System.Drawing.Point(586, 20);
            this.SexBox.Name = "SexBox";
            this.SexBox.Size = new System.Drawing.Size(119, 31);
            this.SexBox.TabIndex = 5;
            this.SexBox.TabStop = false;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Location = new System.Drawing.Point(61, 12);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(35, 16);
            this.rdoWomen.TabIndex = 1;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // rdoMen
            // 
            this.rdoMen.AutoSize = true;
            this.rdoMen.Checked = true;
            this.rdoMen.Location = new System.Drawing.Point(12, 12);
            this.rdoMen.Name = "rdoMen";
            this.rdoMen.Size = new System.Drawing.Size(35, 16);
            this.rdoMen.TabIndex = 0;
            this.rdoMen.TabStop = true;
            this.rdoMen.Text = "男";
            this.rdoMen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "性别：";
            // 
            // txtSname
            // 
            this.txtSname.Location = new System.Drawing.Point(347, 31);
            this.txtSname.Name = "txtSname";
            this.txtSname.Size = new System.Drawing.Size(152, 21);
            this.txtSname.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "姓名：";
            // 
            // txtSid
            // 
            this.txtSid.Location = new System.Drawing.Point(75, 30);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(152, 21);
            this.txtSid.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "学号：";
            // 
            // dataTable
            // 
            this.dataTable.Controls.Add(this.txtPage);
            this.dataTable.Controls.Add(this.labPage);
            this.dataTable.Controls.Add(this.label1);
            this.dataTable.Controls.Add(this.btnPageTo);
            this.dataTable.Controls.Add(this.btnPageEnd);
            this.dataTable.Controls.Add(this.btnPageOn);
            this.dataTable.Controls.Add(this.btnPageNext);
            this.dataTable.Controls.Add(this.btnfirstPage);
            this.dataTable.Controls.Add(this.dataView);
            this.dataTable.Location = new System.Drawing.Point(11, 275);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(927, 258);
            this.dataTable.TabIndex = 2;
            this.dataTable.TabStop = false;
            this.dataTable.Text = "学生数据表：";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(676, 218);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(36, 21);
            this.txtPage.TabIndex = 9;
            this.txtPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPage_KeyPress);
            // 
            // labPage
            // 
            this.labPage.AutoSize = true;
            this.labPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(11, 197);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(0, 14);
            this.labPage.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(723, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "页";
            // 
            // btnPageTo
            // 
            this.btnPageTo.Location = new System.Drawing.Point(592, 217);
            this.btnPageTo.Name = "btnPageTo";
            this.btnPageTo.Size = new System.Drawing.Size(75, 23);
            this.btnPageTo.TabIndex = 5;
            this.btnPageTo.Text = "跳转到";
            this.btnPageTo.UseVisualStyleBackColor = true;
            this.btnPageTo.Click += new System.EventHandler(this.btnPageTo_Click);
            // 
            // btnPageEnd
            // 
            this.btnPageEnd.Location = new System.Drawing.Point(475, 217);
            this.btnPageEnd.Name = "btnPageEnd";
            this.btnPageEnd.Size = new System.Drawing.Size(75, 23);
            this.btnPageEnd.TabIndex = 4;
            this.btnPageEnd.Text = "尾页";
            this.btnPageEnd.UseVisualStyleBackColor = true;
            this.btnPageEnd.Click += new System.EventHandler(this.btnPageEnd_Click);
            // 
            // btnPageOn
            // 
            this.btnPageOn.Location = new System.Drawing.Point(358, 217);
            this.btnPageOn.Name = "btnPageOn";
            this.btnPageOn.Size = new System.Drawing.Size(75, 23);
            this.btnPageOn.TabIndex = 3;
            this.btnPageOn.Text = "上一页";
            this.btnPageOn.UseVisualStyleBackColor = true;
            this.btnPageOn.Click += new System.EventHandler(this.btnPageOn_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Location = new System.Drawing.Point(241, 217);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(75, 23);
            this.btnPageNext.TabIndex = 2;
            this.btnPageNext.Text = "下一页";
            this.btnPageNext.UseVisualStyleBackColor = true;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnfirstPage
            // 
            this.btnfirstPage.Location = new System.Drawing.Point(124, 217);
            this.btnfirstPage.Name = "btnfirstPage";
            this.btnfirstPage.Size = new System.Drawing.Size(75, 23);
            this.btnfirstPage.TabIndex = 1;
            this.btnfirstPage.Text = "首页";
            this.btnfirstPage.UseVisualStyleBackColor = true;
            this.btnfirstPage.Click += new System.EventHandler(this.btnfirstPage_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "当前登录账号：";
            // 
            // labNow
            // 
            this.labNow.AutoSize = true;
            this.labNow.Location = new System.Drawing.Point(110, 9);
            this.labNow.Name = "labNow";
            this.labNow.Size = new System.Drawing.Size(0, 12);
            this.labNow.TabIndex = 4;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(857, 12);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "退出登录";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "增设课程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 545);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.labNow);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "班级管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.SexBox.ResumeLayout(false);
            this.SexBox.PerformLayout();
            this.dataTable.ResumeLayout(false);
            this.dataTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox dataTable;
        private System.Windows.Forms.Button btnPageNext;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPageTo;
        private System.Windows.Forms.Button btnPageEnd;
        private System.Windows.Forms.Button btnPageOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox SexBox;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.RadioButton rdoMen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSid;
        private System.Windows.Forms.Button btnBrowsePic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Button btnfirstPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker BirthdayData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbSpec;
        private System.Windows.Forms.TextBox txtScorse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specialty;
        private System.Windows.Forms.DataGridViewTextBoxColumn AScores;
        private System.Windows.Forms.DataGridViewImageColumn logo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labNow;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button button1;
    }
}

