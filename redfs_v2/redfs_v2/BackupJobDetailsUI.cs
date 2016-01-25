/*
The license text is further down this page, and you should only download and use the source code 
if you agree to the terms in that text. For convenience, though, I�ve put together a human-readable 
(as opposed to lawyer-readable) non-authoritative interpretation of the license which will hopefully 
answer any questions you have. Basically, the license says that:

1. You can use the code in your own products.
2. You can modify the code as you wish, and use the modified code in your free products.
3. You can redistribute the original, unmodified code, but you have to include the full license text below.
4. You can redistribute the modified code as you wish (without the full license text below).
5. In all cases, you must include a credit mentioning 'Vikrama Reddy' as the original author of the source.
6. I'm not liable for anything you do with the code, no matter what. So be sensible.
7. You can't use my name or other marks to promote your products based on the code.
8. If you agree to all of that, go ahead and download the source. Otherwise, don't.
9. Derived work must have 'redfs' in the title. Ex. RedFS-advanced, Lite-Redfs, XRedfs etc.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace redfs_v2
{
    public partial class BackupJobDetailsUI : Form
    {
        public BackupJobDetailsUI(string name, List<backup_pair> pairs, List<job_item> joblist)
        {
            InitializeComponent();
            textBox3.Text = name;

            if (pairs != null)
            {
                for (int i = 0; i < pairs.Count; i++)
                {
                    backup_pair bp = pairs.ElementAt(i);
                    dgv_fldlist.Rows.Add(new string[] { bp.SourcePath, bp.DestinationPath, (bp.IsFile)? "Y": "N" });
                }
                dgv_fldlist.Invalidate();
            }

            if (joblist != null)
            {
                for (int i = 0; i < joblist.Count; i++) 
                {
                    job_item ji = joblist.ElementAt(i);
                    dgv_joblist.Rows.Add(new string[] {ji.JobID.ToString(), ji.JobName, ji.StartTime, DEFS.getDataInStringRep(ji.NewCopiedData) });
                }
                dgv_joblist.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackupJobDetailsUI_Load(object sender, EventArgs e)
        {

        }
    }
}
