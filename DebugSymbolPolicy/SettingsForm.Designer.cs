namespace CustomPolicies.DebugSymbolsPolicy
{
    partial class SettingsForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.remove = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.constraints = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.add = new System.Windows.Forms.Button();
            this.completeDebugInformation = new System.Windows.Forms.RadioButton();
            this.pdbOnly = new System.Windows.Forms.RadioButton();
            this.noDebugSymbols = new System.Windows.Forms.RadioButton();
            this.configurationName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(27, 400);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(477, 400);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 7;
            this.save.Text = "&Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(188, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "DebugSymbols";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 355);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.remove);
            this.groupBox3.Controls.Add(this.clear);
            this.groupBox3.Controls.Add(this.constraints);
            this.groupBox3.Location = new System.Drawing.Point(6, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 179);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Current Constraints ";
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Location = new System.Drawing.Point(447, 19);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 14;
            this.remove.Text = "&Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.Location = new System.Drawing.Point(447, 48);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 13;
            this.clear.Text = "&Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // constraints
            // 
            this.constraints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.constraints.FormattingEnabled = true;
            this.constraints.Location = new System.Drawing.Point(9, 19);
            this.constraints.Name = "constraints";
            this.constraints.Size = new System.Drawing.Size(432, 147);
            this.constraints.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.add);
            this.groupBox2.Controls.Add(this.completeDebugInformation);
            this.groupBox2.Controls.Add(this.pdbOnly);
            this.groupBox2.Controls.Add(this.noDebugSymbols);
            this.groupBox2.Controls.Add(this.configurationName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(5, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 132);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Add a new constraint ";
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add.Enabled = false;
            this.add.Location = new System.Drawing.Point(448, 103);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 13;
            this.add.Text = "&Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // completeDebugInformation
            // 
            this.completeDebugInformation.AutoSize = true;
            this.completeDebugInformation.Checked = true;
            this.completeDebugInformation.Location = new System.Drawing.Point(10, 99);
            this.completeDebugInformation.Name = "completeDebugInformation";
            this.completeDebugInformation.Size = new System.Drawing.Size(245, 17);
            this.completeDebugInformation.TabIndex = 12;
            this.completeDebugInformation.TabStop = true;
            this.completeDebugInformation.Text = "Should come with complete debug information.";
            this.completeDebugInformation.UseVisualStyleBackColor = true;
            // 
            // pdbOnly
            // 
            this.pdbOnly.AutoSize = true;
            this.pdbOnly.Location = new System.Drawing.Point(10, 76);
            this.pdbOnly.Name = "pdbOnly";
            this.pdbOnly.Size = new System.Drawing.Size(166, 17);
            this.pdbOnly.TabIndex = 11;
            this.pdbOnly.Text = "Should come with PDB\'s only.";
            this.pdbOnly.UseVisualStyleBackColor = true;
            // 
            // noDebugSymbols
            // 
            this.noDebugSymbols.AutoSize = true;
            this.noDebugSymbols.Location = new System.Drawing.Point(10, 53);
            this.noDebugSymbols.Name = "noDebugSymbols";
            this.noDebugSymbols.Size = new System.Drawing.Size(223, 17);
            this.noDebugSymbols.TabIndex = 10;
            this.noDebugSymbols.Text = "Should not come with any debug symbols.";
            this.noDebugSymbols.UseVisualStyleBackColor = true;
            // 
            // configurationName
            // 
            this.configurationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationName.Location = new System.Drawing.Point(297, 22);
            this.configurationName.Name = "configurationName";
            this.configurationName.Size = new System.Drawing.Size(226, 20);
            this.configurationName.TabIndex = 9;
            this.configurationName.TextChanged += new System.EventHandler(this.configurationName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Assemblies built with a configuration who\'se name contains";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(572, 466);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton completeDebugInformation;
        private System.Windows.Forms.RadioButton pdbOnly;
        private System.Windows.Forms.RadioButton noDebugSymbols;
        private System.Windows.Forms.TextBox configurationName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ListBox constraints;
    }
}