using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace CustomPolicies.DebugSymbolsPolicy
{
    public partial class SettingsForm : Form
    {
		
		#region [rgn] Constructors (1)

		public SettingsForm()
        {
            InitializeComponent();

            LoadExistingConstraints();
        }
		
		#endregion [rgn]

		#region [rgn] Methods (8)

		// [rgn] Private Methods (8)

		private void add_Click(object sender, EventArgs e)
        {
            DebugInfo requestedDebugInfo;

            if (noDebugSymbols.Checked)
            {
                requestedDebugInfo = DebugInfo.False;
            }
            else if (pdbOnly.Checked)
            {
                requestedDebugInfo = DebugInfo.PdbOnly;
            }
            else // completeDebugInformation.Checked
            {
                requestedDebugInfo = DebugInfo.Full;
            }

            DebugSymbolConstraint constraint = new DebugSymbolConstraint(configurationName.Text, requestedDebugInfo);
            constraints.Items.Add(constraint);

            ResetControls();
        }
		
		private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
		
		private void clear_Click(object sender, EventArgs e)
        {
            constraints.Items.Clear();
        }
		
		private void configurationName_TextChanged(object sender, EventArgs e)
        {
            add.Enabled = configurationName.Text.Length > 0;
        }
		
		private void LoadExistingConstraints()
        {
            DebugSymbolConstraintCollection existingConstraints = DebugSymbolConstraintCollection.Load();
            foreach (DebugSymbolConstraint constraint in existingConstraints)
            {
                constraints.Items.Add(constraint);
            }
        }
		
		private void remove_Click(object sender, EventArgs e)
        {
            if (constraints.SelectedItem != null)
            {
                constraints.Items.RemoveAt(constraints.SelectedIndex);
            }
        }
		
		private void ResetControls()
        {
            configurationName.Clear();
            completeDebugInformation.Checked = true;
            add.Enabled = false;
        }
		
		private void save_Click(object sender, EventArgs e)
        {
            // Save the selected constraints to the user's settings.
            DebugSymbolConstraintCollection selectedConstraints = new DebugSymbolConstraintCollection();
            for (int i = 0; i < constraints.Items.Count; i++)
            {
                selectedConstraints.Add((DebugSymbolConstraint)constraints.Items[i]);
            }

            selectedConstraints.Save();

            DialogResult = DialogResult.OK;
            Close();
        }
		
		#endregion [rgn]

    }
}