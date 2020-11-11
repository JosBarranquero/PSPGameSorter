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
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                cmbDrive.Items.Add(drive.Name);
            }

            // We always select the first drive, which should always exist, but just in case...
            try
            {
                cmbDrive.SelectedIndex = 0;
            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(Strings.NO_DRIVES_MESSAGE, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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
        }
    }
}
