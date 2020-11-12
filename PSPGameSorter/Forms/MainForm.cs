using MetroSet_UI.Forms;
using System;
using System.Windows.Forms;

namespace PSPGameSorter
{
    public partial class frmMain : MetroSetForm
    {
        Utils utils;

        public frmMain()
        {
            InitializeComponent();

            utils = Utils.Instance;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }
               
        private void frmMain_ClientSizeChanged(object sender, EventArgs e)
        {
            // Quick and dirty fix
            // When back of the form is double clicked, it maximizes
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;        
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                utils.CheckFolders();
                lbContent.Items.AddRange(utils.RetrieveGames());
            }
            catch (MissingFoldersException ex)      // The folders don't exist, can't continue
            {
                MetroSetMessageBox.Show(this, ex.Message, Strings.NO_FOLDER_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (MissingGamesException ex)        // There are no games in the folders, can't continue
            {
                MetroSetMessageBox.Show(this, ex.Message, Strings.NO_GAMES_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            cmbDrive.Items.Clear();
            lbContent.Items.Clear();

            LoadDrives();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;       // Making the user aware of delay like a b0ss
                utils.Sort();                           // Trying to sort the games
            } catch (Exception ex)
            {
                MetroSetMessageBox.Show(this, ex.Message, Strings.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;      // The wait is over
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // Checking that we don't move up the first item
            if (lbContent.SelectedIndex > 0)
                MoveGame(lbContent.SelectedIndex, -1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Checking that we don't move down the last item
            if (lbContent.SelectedIndex < lbContent.Items.Count - 1)
                MoveGame(lbContent.SelectedIndex, 1);
        }

        /// <summary>
        /// Moves the game in the internal list in Utils class, and in the shown ListBox
        /// </summary>
        /// <param name="pos">The current position of the game</param>
        /// <param name="dir">Direction of movement, -1 is up, 1 is down</param>
        private void MoveGame(int pos, int dir)
        {
            try
            {
                utils.MoveGame(pos, dir);

                string aux = lbContent.SelectedItem.ToString();
                lbContent.Items.RemoveAt(pos);
                lbContent.Items.Insert(pos + dir, aux);

                lbContent.SelectedIndex = pos + dir;
            } catch (ArgumentOutOfRangeException ex)    // Should not really happen, but who knows
            {
                MetroSetMessageBox.Show(this, ex.Message, Strings.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtain available drives and show them in ComboBox
        /// </summary>
        private void LoadDrives()
        {
            try
            {
                cmbDrive.Items.AddRange(utils.GetDrives());     // Show all drives in combo
                cmbDrive.SelectedIndex = 0;  // We always select the first drive, which should always exist, but just in case...
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MetroSetMessageBox.Show(this, Strings.NO_DRIVES_MESSAGE, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MetroSetMessageBox.Show(this, ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
