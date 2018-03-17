using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using WindowsDesktop;
using GlobalHotKey;
using System.Drawing;
using System.IO;

namespace VirtualDesktopManager
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private IList<VirtualDesktop> desktops;
		private List<VirtualDesktopPreference> Preferences
			= new List<VirtualDesktopPreference>();
        private IntPtr[] activePrograms;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private readonly HotKeyManager _rightHotkey;
        private readonly HotKeyManager _leftHotkey;
        private readonly HotKeyManager _numberHotkey;

        private bool closeToTray;

        private bool useAltKeySettings;

		private bool saved = true;

		private void LoadDesktopPreferences()
		{
			var prefPath = Path.Combine(AppContext.BaseDirectory, "preferences.json");
			if (System.IO.File.Exists(prefPath))
			{
				string contents;
				using (var stream = System.IO.File.OpenRead(prefPath))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						contents = reader.ReadToEnd();
					}
				}
				Preferences = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VirtualDesktopPreference>>(contents);
				for (int i = 0; i < Preferences.Count; i++)
				{
					Preferences[i].VirtualDesktopId = desktops[i].Id;
				}
			}
			else
			{
				Preferences = desktops.Select(desktop => new VirtualDesktopPreference() { VirtualDesktopId = desktop.Id }).ToList();
			}
		}

		private void SaveDesktopPreferences()
		{
			var prefPath = Path.Combine(AppContext.BaseDirectory, "preferences.json");
			using (var stream = System.IO.File.Create(prefPath))
			{
				using (var writer = new StreamWriter(stream))
				{
					writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(Preferences));
				}
			}
		}

        public Form1()
        {
            InitializeComponent();

            handleChangedNumber();
			LoadPreferences();
			LoadDesktopPreferences();
			RefreshListView();

            closeToTray = true;

            _rightHotkey = new HotKeyManager();
            _rightHotkey.KeyPressed += RightKeyManagerPressed;

            _leftHotkey = new HotKeyManager();
            _leftHotkey.KeyPressed += LeftKeyManagerPressed;

            _numberHotkey = new HotKeyManager();
            _numberHotkey.KeyPressed += NumberHotkeyPressed;

            VirtualDesktop.CurrentChanged += VirtualDesktop_CurrentChanged;
            VirtualDesktop.Created += VirtualDesktop_Added;
            VirtualDesktop.Destroyed += VirtualDesktop_Destroyed;

            this.FormClosing += Form1_FormClosing;

            useAltKeySettings = Properties.Settings.Default.AltHotKey;
            checkBox1.Checked = useAltKeySettings;

            //listView1.Items.Clear();
            //listView1.Columns.Add("File").Width = 400;
            //foreach (var file in Properties.Settings.Default.DesktopBackgroundFiles)
            //{
            //    listView1.Items.Add(NewListViewItem(file));
            //}
        }

		private void RefreshListView()
		{
			for (int i = 0; i < Preferences.Count; i++)
			{
				var preference = Preferences[i];
				var desktop = desktops[i];

				string idStr = preference.VirtualDesktopId.ToString();
				idStr = "..." + idStr.Substring(idStr.Length - 5);
				string order = (i + 1).ToString();
				string name = preference.Name ?? $"Desktop {order}";
				string path = preference.Wallpaper;
				path = path == null ? "not set" : Path.GetFileName(path);

				ListViewItem item = null;
				if (i < listView1.Items.Count)
					item = listView1.Items[i];
				if (item == null)
				{
					listView1.Items.Add(new ListViewItem(new string[]
						{
							order,
							idStr,
							name,
							path
						}));
				}
				else
				{
					var subs = item.SubItems;
					if (subs[0].Text != order)
						subs[0].Text = order;
					if (subs[1].Text != idStr)
						subs[1].Text = idStr;
					if (subs[2].Text != name)
						subs[2].Text = name;
					if (subs[3].Text != path)
						subs[3].Text = path;
				}
			}
			while (Preferences.Count < listView1.Items.Count)
			{
				listView1.Items.RemoveAt(Preferences.Count);
			}
		}

		private void RefreshDetails()
		{
			if (listView1.SelectedItems.Count != 1)
			{
				detailsGroup.Enabled = false;
			}
			else
			{
				detailsGroup.Enabled = true;
				var selected = Preferences[listView1.SelectedIndices[0]];
				saveButton.Enabled = !saved;
				clearButton.Enabled = (selected.Wallpaper != null);
				nameBox.Text = selected.Name ?? "";
				pictureBox.ImageLocation = selected.Wallpaper;
			}
		}

		private void LoadPreferences()
		{
			Preferences.Clear();
			foreach (var desktop in desktops)
			{
				Preferences.Add(new VirtualDesktopPreference()
				{
					VirtualDesktopId = desktop.Id
				});
			}
		}

        private void NumberHotkeyPressed(object sender, KeyPressedEventArgs e)
        {   
            var index = (int) e.HotKey.Key - (int)Key.D0 - 1;
            var currentDesktopIndex = getCurrentDesktopIndex();

            if (index == currentDesktopIndex)
            {
                return;
            }

            if (index > desktops.Count - 1)
            {
                return;
            }
                
            desktops.ElementAt(index)?.Switch();            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeToTray)
            {
                e.Cancel = true;
                this.Visible = false;
                this.ShowInTaskbar = false;
                notifyIcon1.BalloonTipTitle = "Still Running...";
                notifyIcon1.BalloonTipText = "Right-click on the tray icon to exit.";
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        private void handleChangedNumber()
        {
            desktops = VirtualDesktop.GetDesktops();
            activePrograms = new IntPtr[desktops.Count];
        }

        private void VirtualDesktop_Added(object sender, VirtualDesktop e)
        {
            handleChangedNumber();
        }

        private void VirtualDesktop_Destroyed(object sender, VirtualDesktopDestroyEventArgs e)
        {
            handleChangedNumber();
        }

        private void VirtualDesktop_CurrentChanged(object sender, VirtualDesktopChangedEventArgs e)
        {
			RefreshCurrentDesktop();
        }

		private void RefreshCurrentDesktop()
		{
			// 0 == first
			int currentDesktopIndex = getCurrentDesktopIndex();

			string pictureFile = PickNthFile(currentDesktopIndex);
			if (pictureFile != null)
			{
				Native.SetBackground(pictureFile);
			}

			restoreApplicationFocus(currentDesktopIndex);
			changeTrayIcon(currentDesktopIndex);
			if (Preferences.Count > currentDesktopIndex)
				notifyIcon1.Text = Preferences[currentDesktopIndex].Name ?? $"Desktop {currentDesktopIndex + 1}";
		}

        private string PickNthFile(int currentDesktopIndex)
        {
            int n = Properties.Settings.Default.DesktopBackgroundFiles.Count;
            if (n == 0)
                return null;
            int index = currentDesktopIndex % n;
            return Properties.Settings.Default.DesktopBackgroundFiles[index];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rightHotkey.Dispose();
            _leftHotkey.Dispose();
            _numberHotkey.Dispose();

            closeToTray = false;

            this.Close();
        }

        private void normalHotkeys()
        {            
            try
            {
                _rightHotkey.Register(Key.Right, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
                _leftHotkey.Register(Key.Left, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
                RegisterNumberHotkeys(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            }
            catch (Exception err)
            {
                notifyIcon1.BalloonTipTitle = "Error setting hotkeys";
                notifyIcon1.BalloonTipText = "Could not set hotkeys. Please open settings and try the alternate combination.";
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        private void alternateHotkeys()
        {
            try
            {
                _rightHotkey.Register(Key.Right, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
                _leftHotkey.Register(Key.Left, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
                RegisterNumberHotkeys(System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
            }
            catch (Exception err)
            {
                notifyIcon1.BalloonTipTitle = "Error setting hotkeys";
                notifyIcon1.BalloonTipText = "Could not set hotkeys. Please open settings and try the default combination.";
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        private void RegisterNumberHotkeys(ModifierKeys modifiers)
        {
            _numberHotkey.Register(Key.D1, modifiers);
            _numberHotkey.Register(Key.D2, modifiers);
            _numberHotkey.Register(Key.D3, modifiers);
            _numberHotkey.Register(Key.D4, modifiers);
            _numberHotkey.Register(Key.D5, modifiers);
            _numberHotkey.Register(Key.D6, modifiers);
            _numberHotkey.Register(Key.D7, modifiers);
            _numberHotkey.Register(Key.D8, modifiers);
            _numberHotkey.Register(Key.D9, modifiers);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //labelStatus.Text = "";

            if (!useAltKeySettings)
                normalHotkeys();
            else
                alternateHotkeys();

            var desktop = initialDesktopState();
            changeTrayIcon();

            this.Visible = false;
        }

        private int getCurrentDesktopIndex()
        {
            return desktops.IndexOf(VirtualDesktop.Current);
        }

        private void saveApplicationFocus(int currentDesktopIndex = -1)
        {
            IntPtr activeAppWindow = GetForegroundWindow();

            if (currentDesktopIndex == -1)
                currentDesktopIndex = getCurrentDesktopIndex();

            activePrograms[currentDesktopIndex] = activeAppWindow;
        }

        private void restoreApplicationFocus(int currentDesktopIndex = -1)
        {
            if (currentDesktopIndex == -1)
                currentDesktopIndex = getCurrentDesktopIndex();

            if (activePrograms[currentDesktopIndex] != null && activePrograms[currentDesktopIndex] != IntPtr.Zero)
            {
                SetForegroundWindow(activePrograms[currentDesktopIndex]);
            }
        }

        private void changeTrayIcon(int currentDesktopIndex = -1)
        {
            if(currentDesktopIndex == -1) 
                currentDesktopIndex = getCurrentDesktopIndex();

            var desktopNumber = currentDesktopIndex + 1;
            var desktopNumberString = desktopNumber.ToString();

            var fontSize = 140;
            var xPlacement = 100;
            var yPlacement = 50;

            if(desktopNumber > 9 && desktopNumber < 100)
            {
                fontSize = 125;
                xPlacement = 75;
                yPlacement = 65;
            } else if(desktopNumber > 99)
            {
                fontSize = 80;
                xPlacement = 90;
                yPlacement = 100;
            }

            Bitmap newIcon = Properties.Resources.mainIcoPng;
            Font desktopNumberFont = new Font("Segoe UI", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);

            var gr = Graphics.FromImage(newIcon);
            gr.DrawString(desktopNumberString, desktopNumberFont, Brushes.White, xPlacement, yPlacement);

            Icon numberedIcon = Icon.FromHandle(newIcon.GetHicon());
            notifyIcon1.Icon = numberedIcon;

            DestroyIcon(numberedIcon.Handle);
            desktopNumberFont.Dispose();
            newIcon.Dispose();
            gr.Dispose();
        }

        VirtualDesktop initialDesktopState()
        {
            var desktop = VirtualDesktop.Current;
            int desktopIndex = getCurrentDesktopIndex();

            saveApplicationFocus(desktopIndex);

            return desktop;
        }

        void RightKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            var desktop = initialDesktopState();
            
            if(desktop.GetRight() != null)
            {
                desktop.GetRight()?.Switch();
            } else
            {
                desktops.First()?.Switch();
            }
        }

        void LeftKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            var desktop = initialDesktopState();

            if (desktop.GetLeft() != null)
            {
                desktop.GetLeft()?.Switch();
            }
            else
            {
                desktops.Last()?.Switch();
            }
        }

        private void openSettings()
        {
            this.Visible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSettings();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            openSettings();
        }

		private void MoveSelectedItem(bool up)
		{
			int swap = 0;
			try
			{
				if (listView1.SelectedItems.Count == 1)
				{
					int indx = listView1.SelectedIndices[0];
					int totl = listView1.Items.Count;
					var selected = Preferences[indx];

					if (indx == 0 && up)
					{
						swap = totl - 1;
					}
					else if (indx == totl - 1 && !up)
					{
						swap = 0;
					}
					else
					{
						swap = indx + (up ? -1 : 1);
					}

					var name = selected.Name;
					var wallpaper = selected.Wallpaper;

					var other = Preferences[swap];
					selected.Name = other.Name;
					selected.Wallpaper = other.Wallpaper;
					other.Name = name;
					other.Wallpaper = wallpaper;
				}
				else
				{
					MessageBox.Show("You must select exactly one item to move it. Please select one item and try again.",
						"Item Select", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
			catch (Exception) { }
			finally
			{
				RefreshListView();
				listView1.Items[swap].Selected = true;
				listView1.Select();
			}
		}

        private void upButton_Click(object sender, EventArgs e)
        {
			MoveSelectedItem(true);
        }

        private void downButton_Click(object sender, EventArgs e)
		{
			MoveSelectedItem(false);
		}

        private void saveButton_Click(object sender, EventArgs e)
        {
            _rightHotkey.Unregister(Key.Right, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            _leftHotkey.Unregister(Key.Left, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            _rightHotkey.Unregister(Key.Right, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
            _leftHotkey.Unregister(Key.Left, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);

            if (checkBox1.Checked)
            {
                alternateHotkeys();
                Properties.Settings.Default.AltHotKey = true;
            }
            else
            {
                normalHotkeys();
                Properties.Settings.Default.AltHotKey = false;
            }

			if (listView1.SelectedItems.Count == 1)
			{
				int indx = listView1.SelectedIndices[0];
				var preference = Preferences[indx];
				var name = nameBox.Text;
				if (name == "")
					name = null;
				preference.Name = name;
				preference.Wallpaper = pictureBox.ImageLocation;
			}

            Properties.Settings.Default.DesktopBackgroundFiles.Clear();
			if (Preferences.Any(pref => pref.Wallpaper != null))
			{
				string wallpaper = null;
				for (int i = 0; i < Preferences.Count; i++)
				{
					if (wallpaper == null)
					{
						var pref = Preferences[(Preferences.Count - i) % Preferences.Count];
						wallpaper = pref.Wallpaper;
					}
				}
				foreach (var pref in Preferences)
				{
					wallpaper = pref.Wallpaper ?? wallpaper;
					Properties.Settings.Default.DesktopBackgroundFiles.Add(wallpaper);
				}
			}

            Properties.Settings.Default.Save();
			SaveDesktopPreferences();

			saved = true;
			RefreshListView();
			RefreshDetails();

			RefreshCurrentDesktop();
            //labelStatus.Text = "Changes were successful.";
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
			var desktop = VirtualDesktop.Create();
			handleChangedNumber();
			Preferences.Add(new VirtualDesktopPreference() { VirtualDesktopId = desktop.Id });
			RefreshListView();
        }

        private static ListViewItem NewListViewItem(string file)
        {
            return new ListViewItem()
            {
                Text = Path.GetFileName(file),
                ToolTipText = file,
                Name = Path.GetFileName(file),
                Tag = file
            };
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
				if (listView1.Items.Count == 1)
				{
					MessageBox.Show("Can't remove the last desktop.",
						"Item Select", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
                else if (listView1.SelectedItems.Count == 1)
                {
					var indx = listView1.SelectedIndices[0];
					var desktop = desktops[indx];
					Preferences.RemoveAt(indx);
					desktop.Remove();
					handleChangedNumber();
					RefreshListView();
				}
				else
				{
					MessageBox.Show("You must select exactly one item to remove it. Please select one item and try again.",
						"Item Select", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
            catch (Exception ex)
            {
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
			VirtualDesktop.Current.GetRight().Switch();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshDetails();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;
			openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 0;
			openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			openFileDialog1.Multiselect = false;
			openFileDialog1.Title = "Select desktop background image";
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				var path = openFileDialog1.FileName;
				pictureBox.ImageLocation = path;
				saved = false;
				saveButton.Enabled = true;
				clearButton.Enabled = true;
			}
		}

		private void nameBox_TextChanged(object sender, EventArgs e)
		{
			saved = false;
			saveButton.Enabled = true;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			saved = false;
			saveButton.Enabled = true;
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			pictureBox.ImageLocation = null;
			saved = false;
			saveButton.Enabled = true;
		}
	}
}
