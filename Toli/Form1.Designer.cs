namespace Toli
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtEnglish = new TextBox();
            txtRussian = new TextBox();
            txtMongolian = new TextBox();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtEnglish
            // 
            txtEnglish.Location = new Point(26, 28);
            txtEnglish.Name = "txtEnglish";
            txtEnglish.Size = new Size(106, 23);
            txtEnglish.TabIndex = 0;
            // 
            // txtRussian
            // 
            txtRussian.Location = new Point(149, 28);
            txtRussian.Name = "txtRussian";
            txtRussian.Size = new Size(106, 23);
            txtRussian.TabIndex = 1;
            // 
            // txtMongolian
            // 
            txtMongolian.Location = new Point(271, 28);
            txtMongolian.Name = "txtMongolian";
            txtMongolian.Size = new Size(106, 23);
            txtMongolian.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(207, 77);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(106, 23);
            txtSearch.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(394, 26);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 24);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Нэмэх";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(26, 75);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(70, 24);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Засах";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(114, 75);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 24);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Устгах";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(319, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(70, 24);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Хайх";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(481, 234);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 384);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtMongolian);
            Controls.Add(txtRussian);
            Controls.Add(txtEnglish);
            Name = "Form1";
            Text = "Толь бичиг";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.TextBox txtRussian;
        private System.Windows.Forms.TextBox txtMongolian;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}