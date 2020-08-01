namespace Production_ClassManage
{
    partial class AddCourse
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCid = new System.Windows.Forms.TextBox();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dastaCourseView = new System.Windows.Forms.DataGridView();
            this.numCredit = new System.Windows.Forms.NumericUpDown();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChooseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dastaCourseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCredit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加课程";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "课程号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "课程名：";
            // 
            // txtCid
            // 
            this.txtCid.Location = new System.Drawing.Point(83, 28);
            this.txtCid.Name = "txtCid";
            this.txtCid.Size = new System.Drawing.Size(140, 21);
            this.txtCid.TabIndex = 4;
            // 
            // txtCname
            // 
            this.txtCname.Location = new System.Drawing.Point(83, 72);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(140, 21);
            this.txtCname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "课程学分：";
            // 
            // dastaCourseView
            // 
            this.dastaCourseView.AllowUserToAddRows = false;
            this.dastaCourseView.AllowUserToDeleteRows = false;
            this.dastaCourseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dastaCourseView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.Cname,
            this.Credit,
            this.ChooseCount});
            this.dastaCourseView.Location = new System.Drawing.Point(11, 19);
            this.dastaCourseView.Name = "dastaCourseView";
            this.dastaCourseView.ReadOnly = true;
            this.dastaCourseView.RowTemplate.Height = 23;
            this.dastaCourseView.Size = new System.Drawing.Size(403, 268);
            this.dastaCourseView.TabIndex = 8;
            // 
            // numCredit
            // 
            this.numCredit.DecimalPlaces = 1;
            this.numCredit.Location = new System.Drawing.Point(83, 117);
            this.numCredit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCredit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCredit.Name = "numCredit";
            this.numCredit.Size = new System.Drawing.Size(140, 21);
            this.numCredit.TabIndex = 10;
            this.numCredit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CID
            // 
            this.CID.DataPropertyName = "CID";
            this.CID.HeaderText = "课程号";
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Width = 80;
            // 
            // Cname
            // 
            this.Cname.DataPropertyName = "Cname";
            this.Cname.HeaderText = "课程名";
            this.Cname.Name = "Cname";
            this.Cname.ReadOnly = true;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.HeaderText = "课程分";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 80;
            // 
            // ChooseCount
            // 
            this.ChooseCount.DataPropertyName = "ChooseCount";
            this.ChooseCount.HeaderText = "选修人数";
            this.ChooseCount.Name = "ChooseCount";
            this.ChooseCount.ReadOnly = true;
            this.ChooseCount.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dastaCourseView);
            this.groupBox1.Location = new System.Drawing.Point(243, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 294);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已开设课程：";
            // 
            // AddCourse
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numCredit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCname);
            this.Controls.Add(this.txtCid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加课程";
            this.Load += new System.EventHandler(this.AddCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dastaCourseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCredit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCid;
        private System.Windows.Forms.TextBox txtCname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dastaCourseView;
        private System.Windows.Forms.NumericUpDown numCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChooseCount;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}