using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using CustomPolicies.FxCopDeltaPolicy.Properties;
using System.IO;

namespace CustomPolicies.FxCopDeltaPolicy
{
    public partial class SettingsForm : Form
    {
		
		#region [rgn] Constructors (1)

		public SettingsForm()
        {
            InitializeComponent();

            this.fxCopCommandPath.Text = Settings.Default.FxCopCommandPath;

            if (Settings.Default.RuleAssemblies != null)
            {
                foreach (string ruleAssembly in Settings.Default.RuleAssemblies)
                {
                    this.ruleAssemblies.Items.Add(ruleAssembly);
                }
            }

            if (Settings.Default.DisabledRules != null)
            {
                foreach (string disabledRule in Settings.Default.DisabledRules)
                {
                    this.disabledRules.Items.Add(disabledRule);
                }
            }

            // Hook Remove & Clear Buttons to the appropriate ListBoxs.
            removeRuleAssembly.Tag = this.ruleAssemblies;
            clearRuleAssemblies.Tag = this.ruleAssemblies;
            removeDisabledRule.Tag = this.disabledRules;
            clearDisabledRules.Tag = this.disabledRules;
        }
		
		#endregion [rgn]

		#region [rgn] Methods (8)

		// [rgn] Private Methods (8)

		private void addDisabledRule_Click(object sender, EventArgs e)
        {
            disabledRules.Items.Add(disabledRule.Text);
            disabledRule.Text = string.Empty;
        }
		
		private void addRuleAssembly_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rule assembly file (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruleAssemblies.Items.Add(openFileDialog.FileName);
            }

        }
		
		private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FxCopCmd file (FxCopCmd.exe)|FxCopCmd.exe";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fxCopCommandPath.Text = openFileDialog.FileName;
            }
        }
		
		private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
		
		private void clear_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ListBox listBox = (ListBox)button.Tag;
            listBox.Items.Clear();
        }
		
		private void disabledRule_TextChanged(object sender, EventArgs e)
        {
            addDisabledRule.Enabled = disabledRule.Text.Length > 0;
        }
		
		private void remove_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ListBox listBox = (ListBox)button.Tag;

            if (listBox.SelectedItem != null)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
        }
		
		private void save_Click(object sender, EventArgs e)
        {
            // Validate & Save the FxCopCommand path setting.
            string fxCopPath = this.fxCopCommandPath.Text;
            bool fxCopCommandPathExists = File.Exists(fxCopPath);
            if (fxCopCommandPathExists)
            {
                Settings.Default.FxCopCommandPath = fxCopPath;
            }
            else
            {
                string message = string.Format("Cannot find the file \"{0}\".", fxCopPath);
                MessageBox.Show(message, "FxCopDelta Settings");

                return;
            }

            // Save the RuleAssemblies setting.
            Settings.Default.RuleAssemblies = new StringCollection();
            foreach (string ruleAssembly in ruleAssemblies.Items)
            {
                Settings.Default.RuleAssemblies.Add(ruleAssembly);
            }

            // Save the DisabledRules setting.
            Settings.Default.DisabledRules = new StringCollection();
            foreach (string disabledRule in disabledRules.Items)
            {
                Settings.Default.DisabledRules.Add(disabledRule);
            }

            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }
		
		#endregion [rgn]

    }
}