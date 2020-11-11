using System;
using System.IO;
using System.Windows.Forms;

namespace PSPGameSorter
{
    public partial class frmMain : Form
    {
        Utils utils;

        public frmMain()
        {
            InitializeComponent();

            utils = Utils.Instance;
        }

        /**
         *  Obtain drives available and show them in combobox
         */
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!utils.CheckFolders())
            {
                MessageBox.Show(Strings.NO_FOLDER_MESSAGE, Strings.NO_FOLDER_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lbContent.Items.AddRange(utils.RetrieveGames());
            } catch (MissingGamesException ex)
            {
                MessageBox.Show(ex.Message, Strings.NO_GAMES_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            cmbDrive.Enabled = false;
            btnScan.Enabled = false;
            lbContent.Enabled = true;
            btnDown.Enabled = true;
            btnUp.Enabled = true;
            btnSort.Enabled = true;
        }

        private void cmbDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            utils.CurrentDrive = cmbDrive.SelectedItem.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbDrive.Enabled = true;
            btnScan.Enabled = true;
            lbContent.Enabled = false;

            lbContent.Items.Clear();

            LoadDrives();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                utils.Sort();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Strings.NO_FOLDER_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbContent.SelectedIndex > 0)
                MoveGame(lbContent.SelectedIndex, -1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbContent.SelectedIndex < lbContent.Items.Count - 1)
                MoveGame(lbContent.SelectedIndex, 1);
        }

        private void MoveGame(int pos, int dir)
        {
            utils.MoveGame(pos, dir);
            
            string aux = lbContent.SelectedItem.ToString();
            lbContent.Items.RemoveAt(pos);
            lbContent.Items.Insert(pos + dir, aux);

            lbContent.SelectedIndex = pos + dir;
        }

        private void LoadDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                cmbDrive.Items.Add(drive.Name);
            }

            // We always select the first drive, which should always exist, but just in case...
            try
            {
                cmbDrive.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(Strings.NO_DRIVES_MESSAGE, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
