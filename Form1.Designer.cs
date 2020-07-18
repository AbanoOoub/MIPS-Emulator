namespace MIPS
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
            this.usercode_txtbox = new System.Windows.Forms.TextBox();
            this.pc_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Initialize_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mipsReg_gridview = new System.Windows.Forms.DataGridView();
            this.MipsReg_regcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MipsReg_Valuecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiplineReg_gridview = new System.Windows.Forms.DataGridView();
            this.PiplineReg_Regcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiplineReg_Valuecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.DataMemory_gridview = new System.Windows.Forms.DataGridView();
            this.DataMem_AddressCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataMem_ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.RunCycle_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mipsReg_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PiplineReg_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataMemory_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Code";
            // 
            // usercode_txtbox
            // 
            this.usercode_txtbox.Location = new System.Drawing.Point(66, 45);
            this.usercode_txtbox.Multiline = true;
            this.usercode_txtbox.Name = "usercode_txtbox";
            this.usercode_txtbox.Size = new System.Drawing.Size(271, 670);
            this.usercode_txtbox.TabIndex = 1;
            // 
            // pc_txtbox
            // 
            this.pc_txtbox.Location = new System.Drawing.Point(97, 745);
            this.pc_txtbox.Name = "pc_txtbox";
            this.pc_txtbox.Size = new System.Drawing.Size(107, 24);
            this.pc_txtbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 747);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "PC";
            // 
            // Initialize_btn
            // 
            this.Initialize_btn.Location = new System.Drawing.Point(221, 734);
            this.Initialize_btn.Name = "Initialize_btn";
            this.Initialize_btn.Size = new System.Drawing.Size(116, 43);
            this.Initialize_btn.TabIndex = 4;
            this.Initialize_btn.Text = "Initialize";
            this.Initialize_btn.UseVisualStyleBackColor = true;
            this.Initialize_btn.Click += new System.EventHandler(this.Initialize_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mips Register";
            // 
            // mipsReg_gridview
            // 
            this.mipsReg_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mipsReg_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mipsReg_gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MipsReg_regcol,
            this.MipsReg_Valuecol});
            this.mipsReg_gridview.Location = new System.Drawing.Point(411, 45);
            this.mipsReg_gridview.Name = "mipsReg_gridview";
            this.mipsReg_gridview.RowHeadersWidth = 51;
            this.mipsReg_gridview.RowTemplate.Height = 26;
            this.mipsReg_gridview.Size = new System.Drawing.Size(262, 669);
            this.mipsReg_gridview.TabIndex = 6;
            // 
            // MipsReg_regcol
            // 
            this.MipsReg_regcol.HeaderText = "Register";
            this.MipsReg_regcol.MinimumWidth = 6;
            this.MipsReg_regcol.Name = "MipsReg_regcol";
            // 
            // MipsReg_Valuecol
            // 
            this.MipsReg_Valuecol.HeaderText = "Value";
            this.MipsReg_Valuecol.MinimumWidth = 6;
            this.MipsReg_Valuecol.Name = "MipsReg_Valuecol";
            // 
            // PiplineReg_gridview
            // 
            this.PiplineReg_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PiplineReg_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PiplineReg_gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PiplineReg_Regcol,
            this.PiplineReg_Valuecol});
            this.PiplineReg_gridview.Location = new System.Drawing.Point(725, 45);
            this.PiplineReg_gridview.Name = "PiplineReg_gridview";
            this.PiplineReg_gridview.RowHeadersWidth = 51;
            this.PiplineReg_gridview.RowTemplate.Height = 26;
            this.PiplineReg_gridview.Size = new System.Drawing.Size(369, 669);
            this.PiplineReg_gridview.TabIndex = 8;
            // 
            // PiplineReg_Regcol
            // 
            this.PiplineReg_Regcol.HeaderText = "Register";
            this.PiplineReg_Regcol.MinimumWidth = 6;
            this.PiplineReg_Regcol.Name = "PiplineReg_Regcol";
            // 
            // PiplineReg_Valuecol
            // 
            this.PiplineReg_Valuecol.HeaderText = "Value";
            this.PiplineReg_Valuecol.MinimumWidth = 6;
            this.PiplineReg_Valuecol.Name = "PiplineReg_Valuecol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(722, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pipline Register";
            // 
            // DataMemory_gridview
            // 
            this.DataMemory_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataMemory_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataMemory_gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataMem_AddressCol,
            this.DataMem_ValueCol});
            this.DataMemory_gridview.Location = new System.Drawing.Point(1161, 45);
            this.DataMemory_gridview.Name = "DataMemory_gridview";
            this.DataMemory_gridview.RowHeadersWidth = 51;
            this.DataMemory_gridview.RowTemplate.Height = 26;
            this.DataMemory_gridview.Size = new System.Drawing.Size(231, 669);
            this.DataMemory_gridview.TabIndex = 10;
            // 
            // DataMem_AddressCol
            // 
            this.DataMem_AddressCol.HeaderText = "Address";
            this.DataMem_AddressCol.MinimumWidth = 6;
            this.DataMem_AddressCol.Name = "DataMem_AddressCol";
            // 
            // DataMem_ValueCol
            // 
            this.DataMem_ValueCol.HeaderText = "Value";
            this.DataMem_ValueCol.MinimumWidth = 6;
            this.DataMem_ValueCol.Name = "DataMem_ValueCol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1158, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Memory";
            // 
            // RunCycle_btn
            // 
            this.RunCycle_btn.Location = new System.Drawing.Point(411, 734);
            this.RunCycle_btn.Name = "RunCycle_btn";
            this.RunCycle_btn.Size = new System.Drawing.Size(262, 43);
            this.RunCycle_btn.TabIndex = 11;
            this.RunCycle_btn.Text = "Run 1 Cycle";
            this.RunCycle_btn.UseVisualStyleBackColor = true;
            this.RunCycle_btn.Click += new System.EventHandler(this.RunCycle_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 812);
            this.Controls.Add(this.RunCycle_btn);
            this.Controls.Add(this.DataMemory_gridview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PiplineReg_gridview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mipsReg_gridview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Initialize_btn);
            this.Controls.Add(this.pc_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usercode_txtbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mipsReg_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PiplineReg_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataMemory_gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usercode_txtbox;
        private System.Windows.Forms.TextBox pc_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Initialize_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView mipsReg_gridview;
        private System.Windows.Forms.DataGridView PiplineReg_gridview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DataMemory_gridview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MipsReg_regcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MipsReg_Valuecol;
        private System.Windows.Forms.Button RunCycle_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PiplineReg_Regcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PiplineReg_Valuecol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMem_AddressCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMem_ValueCol;
    }
}

