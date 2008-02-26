namespace CustomPolicies.FxCopDeltaPolicy
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disabledRule = new System.Windows.Forms.TextBox();
            this.clearDisabledRules = new System.Windows.Forms.Button();
            this.removeDisabledRule = new System.Windows.Forms.Button();
            this.addDisabledRule = new System.Windows.Forms.Button();
            this.disabledRules = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clearRuleAssemblies = new System.Windows.Forms.Button();
            this.removeRuleAssembly = new System.Windows.Forms.Button();
            this.addRuleAssembly = new System.Windows.Forms.Button();
            this.ruleAssemblies = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.fxCopCommandPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "FxCopDelta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(147, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.disabledRule);
            this.groupBox1.Controls.Add(this.clearDisabledRules);
            this.groupBox1.Controls.Add(this.removeDisabledRule);
            this.groupBox1.Controls.Add(this.addDisabledRule);
            this.groupBox1.Controls.Add(this.disabledRules);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.clearRuleAssemblies);
            this.groupBox1.Controls.Add(this.removeRuleAssembly);
            this.groupBox1.Controls.Add(this.addRuleAssembly);
            this.groupBox1.Controls.Add(this.ruleAssemblies);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.browse);
            this.groupBox1.Controls.Add(this.fxCopCommandPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 445);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // disabledRule
            // 
            this.disabledRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.disabledRule.Location = new System.Drawing.Point(10, 270);
            this.disabledRule.Name = "disabledRule";
            this.disabledRule.Size = new System.Drawing.Size(443, 20);
            this.disabledRule.TabIndex = 13;
            this.disabledRule.TextChanged += new System.EventHandler(this.disabledRule_TextChanged);
            // 
            // clearDisabledRules
            // 
            this.clearDisabledRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDisabledRules.Location = new System.Drawing.Point(460, 330);
            this.clearDisabledRules.Name = "clearDisabledRules";
            this.clearDisabledRules.Size = new System.Drawing.Size(75, 23);
            this.clearDisabledRules.TabIndex = 12;
            this.clearDisabledRules.Text = "C&lear";
            this.clearDisabledRules.UseVisualStyleBackColor = true;
            this.clearDisabledRules.Click += new System.EventHandler(this.clear_Click);
            // 
            // removeDisabledRule
            // 
            this.removeDisabledRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeDisabledRule.Location = new System.Drawing.Point(460, 300);
            this.removeDisabledRule.Name = "removeDisabledRule";
            this.removeDisabledRule.Size = new System.Drawing.Size(75, 23);
            this.removeDisabledRule.TabIndex = 11;
            this.removeDisabledRule.Text = "&Remove";
            this.removeDisabledRule.UseVisualStyleBackColor = true;
            this.removeDisabledRule.Click += new System.EventHandler(this.remove_Click);
            // 
            // addDisabledRule
            // 
            this.addDisabledRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addDisabledRule.Enabled = false;
            this.addDisabledRule.Location = new System.Drawing.Point(460, 270);
            this.addDisabledRule.Name = "addDisabledRule";
            this.addDisabledRule.Size = new System.Drawing.Size(75, 23);
            this.addDisabledRule.TabIndex = 10;
            this.addDisabledRule.Text = "&Add";
            this.addDisabledRule.UseVisualStyleBackColor = true;
            this.addDisabledRule.Click += new System.EventHandler(this.addDisabledRule_Click);
            // 
            // disabledRules
            // 
            this.disabledRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.disabledRules.FormattingEnabled = true;
            this.disabledRules.Location = new System.Drawing.Point(10, 296);
            this.disabledRules.Name = "disabledRules";
            this.disabledRules.Size = new System.Drawing.Size(443, 134);
            this.disabledRules.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Disabled rules:";
            // 
            // clearRuleAssemblies
            // 
            this.clearRuleAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearRuleAssemblies.Location = new System.Drawing.Point(460, 132);
            this.clearRuleAssemblies.Name = "clearRuleAssemblies";
            this.clearRuleAssemblies.Size = new System.Drawing.Size(75, 23);
            this.clearRuleAssemblies.TabIndex = 7;
            this.clearRuleAssemblies.Text = "C&lear";
            this.clearRuleAssemblies.UseVisualStyleBackColor = true;
            this.clearRuleAssemblies.Click += new System.EventHandler(this.clear_Click);
            // 
            // removeRuleAssembly
            // 
            this.removeRuleAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeRuleAssembly.Location = new System.Drawing.Point(460, 102);
            this.removeRuleAssembly.Name = "removeRuleAssembly";
            this.removeRuleAssembly.Size = new System.Drawing.Size(75, 23);
            this.removeRuleAssembly.TabIndex = 6;
            this.removeRuleAssembly.Text = "&Remove";
            this.removeRuleAssembly.UseVisualStyleBackColor = true;
            this.removeRuleAssembly.Click += new System.EventHandler(this.remove_Click);
            // 
            // addRuleAssembly
            // 
            this.addRuleAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRuleAssembly.Location = new System.Drawing.Point(460, 72);
            this.addRuleAssembly.Name = "addRuleAssembly";
            this.addRuleAssembly.Size = new System.Drawing.Size(75, 23);
            this.addRuleAssembly.TabIndex = 5;
            this.addRuleAssembly.Text = "&Add";
            this.addRuleAssembly.UseVisualStyleBackColor = true;
            this.addRuleAssembly.Click += new System.EventHandler(this.addRuleAssembly_Click);
            // 
            // ruleAssemblies
            // 
            this.ruleAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleAssemblies.FormattingEnabled = true;
            this.ruleAssemblies.Location = new System.Drawing.Point(10, 72);
            this.ruleAssemblies.Name = "ruleAssemblies";
            this.ruleAssemblies.Size = new System.Drawing.Size(443, 160);
            this.ruleAssemblies.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rule assemblies:";
            // 
            // browse
            // 
            this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browse.Location = new System.Drawing.Point(459, 15);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 2;
            this.browse.Text = "&Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // fxCopCommandPath
            // 
            this.fxCopCommandPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fxCopCommandPath.Location = new System.Drawing.Point(206, 17);
            this.fxCopCommandPath.Name = "fxCopCommandPath";
            this.fxCopCommandPath.Size = new System.Drawing.Size(247, 20);
            this.fxCopCommandPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "FxCop command (FxCopCmd.exe) path:";
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(472, 497);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "&Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(22, 497);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 533);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(572, 567);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox fxCopCommandPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clearRuleAssemblies;
        private System.Windows.Forms.Button removeRuleAssembly;
        private System.Windows.Forms.Button addRuleAssembly;
        private System.Windows.Forms.ListBox ruleAssemblies;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button clearDisabledRules;
        private System.Windows.Forms.Button removeDisabledRule;
        private System.Windows.Forms.Button addDisabledRule;
        private System.Windows.Forms.ListBox disabledRules;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox disabledRule;
    }
}