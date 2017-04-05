//INSTANT C# NOTE: Formerly VB.NET project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

using System.Xml;

namespace MTS.ICLViewer
{
    public partial class Search : Form
    {
        public FrmViewer frmViewer = null;

		internal Search()
		{
			InitializeComponent();
		}
	  private void OK_Button_Click(object sender, System.EventArgs e)
	  {
		this.DialogResult = System.Windows.Forms.DialogResult.OK;
		bool textFound = false;
		this.Cursor = Cursors.WaitCursor;
		if (rbGeneral.Checked)
		{
		  if (tbGenSearch.Text.Trim().Length > 0)
		  {

              for (int i = (frmViewer.tvX9.SelectedNode == null) ? 0 : System.Convert.ToInt32(frmViewer.tvX9.SelectedNode.Name); i < frmViewer.x9Stuff.Count; i++)
			{
			  if (frmViewer.x9Stuff[i].recData.IndexOf(tbGenSearch.Text) >= 0)
			  {
                  frmViewer.tvX9.SelectedNode = frmViewer.tvX9.Nodes.Find(i.ToString(), true)[0];
				textFound = true;
				break;
			  }
			}
		  }
		}
		else
		{
		  if (tbTSearch.Text.Trim().Length > 0)
		  {
			string rType = cboRecType.SelectedItem.ToString().Substring(0, cboRecType.SelectedItem.ToString().IndexOf(" "));
			XmlNode fNode = frmViewer.xmlFields.SelectSingleNode("records/record[@type='" + rType + "']/field[@name='" + cboField.SelectedItem + "']");
			string sField = null;
			int fieldStart = 0;
			int fieldLen = 0;
			for (int i = ((frmViewer.tvX9.SelectedNode == null) ? 0 : System.Convert.ToInt32(frmViewer.tvX9.SelectedNode.Name)); i < frmViewer.x9Stuff.Count; i++)
			{
			  if (frmViewer.x9Stuff[i].recType == rType)
			  {
				if (fNode != null)
				{
				  fieldStart = System.Convert.ToInt32(fNode.Attributes["start"].Value) - 1;
				  fieldLen = System.Convert.ToInt32(fNode.Attributes["end"].Value) - fieldStart;
				  sField = frmViewer.x9Stuff[i].recData.Substring(fieldStart, fieldLen);
				  if (sField.IndexOf(tbTSearch.Text) >= 0)
				  {
					frmViewer.tvX9.SelectedNode = frmViewer.tvX9.Nodes.Find(i.ToString(), true)[0];
					textFound = true;
					break;
				  }
				}
			  }
			}
		  }
		}
		this.Cursor = Cursors.Default;
		if (! textFound)
		{
		  MessageBox.Show("Search text not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	  }

	  private void Cancel_Button_Click(object sender, System.EventArgs e)
	  {
		this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Close();
	  }

	  private void Search_Load(object sender, System.EventArgs e)
	  {

	  }

	  private void rbTargetted_CheckedChanged(object sender, System.EventArgs e)
	  {
		if (rbTargetted.Checked)
		{
		  pnlTSearch.Enabled = true;
		  Application.DoEvents();
		  if (cboRecType.Items.Count == 0)
		  {
			// Load record types
			XmlDocument xmlDoc = frmViewer.xmlFields;
			foreach (XmlNode n in xmlDoc.SelectNodes("records/record"))
			{
			  cboRecType.Items.Add(n.Attributes["type"].Value + " " + n.Attributes["name"].Value);
			}
			cboRecType.SelectedIndex = 0;
			Application.DoEvents();
			loadFields();
			cboRecType.Focus();
		  }
		}
	  }

	  private void loadFields()
	  {
		XmlDocument xmlDoc = frmViewer.xmlFields;
		cboField.Items.Clear();
		if (cboRecType.SelectedIndex >= 0)
		{
            foreach (XmlNode n in xmlDoc.SelectNodes("records/record[@type='" + cboRecType.SelectedItem.ToString().Substring(0, cboRecType.SelectedItem.ToString().IndexOf(" ")) + "']/field"))
		  {
			cboField.Items.Add(n.Attributes["name"].Value);
		  }
		}
	  }

	  private void cboRecType_SelectedIndexChanged(object sender, System.EventArgs e)
	  {
		loadFields();
	  }

	  private void rbGeneral_CheckedChanged(object sender, System.EventArgs e)
	  {
		if (rbGeneral.Checked)
		{
		  pnlTSearch.Enabled = false;
		  tbGenSearch.Focus();
		}
	  }
	}
} //end of root namespace