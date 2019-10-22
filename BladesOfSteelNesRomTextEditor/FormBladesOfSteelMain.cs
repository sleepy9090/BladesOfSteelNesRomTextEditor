/**
 * @file           FormBladesOfSteelMain.cs
 * @brief          Creates the form for changing title and game text.
 *
 * @copyright      Shawn M. Crawford
 * @date           10/21/2019
 *
 * @remark Author  Shawn M. Crawford
 *
 * @note           N/A
 * 
 */
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BladesOfSteelNesRomTextEditor
{
    public partial class FormBladesOfSteelMain : Form
    {
        public string FullFilename { get; set; }

        public FormBladesOfSteelMain()
        {
            InitializeComponent();
            EnableDisableFormControls(false);
            SetTextBoxesMaxLength();
        }

        private void EnableDisableFormControls(bool isControlEnabled)
        {
            updateToolStripMenuItem.Enabled = isControlEnabled;
            buttonUpdate.Enabled = isControlEnabled;

            foreach (Control control in Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control controlInGroupBox in control.Controls)
                    {
                        if (controlInGroupBox is TextBox)
                        {
                            TextBox textBox = (TextBox)controlInGroupBox;
                            textBox.Enabled = isControlEnabled;
                        }
                    }
                }
            }
        }

        private void SetTextBoxesMaxLength()
        {
            textBox1.MaxLength = 0x7;
            textBox2.MaxLength = 0x8;
            textBox3.MaxLength = 0xD;
            textBox4.MaxLength = 0x18;
            textBox5.MaxLength = 0xB;
            textBox6.MaxLength = 0x18;
            textBox7.MaxLength = 0x8;
            textBox8.MaxLength = 0x7;
            textBox9.MaxLength = 0xB;
            textBox10.MaxLength = 0x8;
            textBox11.MaxLength = 0x7;
            textBox12.MaxLength = 0x8;
            textBox13.MaxLength = 0x9;
            textBox14.MaxLength = 0x9;
            textBox15.MaxLength = 0xB;
            textBox16.MaxLength = 0xA;
            textBox17.MaxLength = 0xA;
            textBox18.MaxLength = 0xD;
            textBox19.MaxLength = 0xE;
            textBox20.MaxLength = 0xA;
            textBox21.MaxLength = 0x6;
            textBox22.MaxLength = 0x6;
            textBox23.MaxLength = 0x7;
            textBox24.MaxLength = 0x6;
            textBox25.MaxLength = 0x3;
            textBox26.MaxLength = 0x6;
            textBox27.MaxLength = 0xD;
            textBox28.MaxLength = 0x6;
            textBox29.MaxLength = 0x7;
            textBox30.MaxLength = 0x3;
            textBox31.MaxLength = 0xB;
            textBox32.MaxLength = 0x4;
            textBox33.MaxLength = 0x4;
            textBox34.MaxLength = 0x5;
            textBox35.MaxLength = 0x4;
            textBox36.MaxLength = 0x4;
            textBox37.MaxLength = 0x5;
        }

        private void ButtonOpenRom_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = @"Open file...";
            openFileDialog.Filter = @"nes files (*.nes)|*.nes|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FullFilename = openFileDialog.FileName;
                textBoxFullFilename.Text = FullFilename;
                LoadRomData();
                EnableDisableFormControls(true);
            }
        }

        private void LoadRomData()
        {
            try
            {
                Backend backend = new Backend(FullFilename);

                // Title Text
                textBox1.Text = backend.GetText(0x7, 0x1C9BB, 1); // 1 PLAYER
                textBox2.Text = backend.GetText(0x8, 0x1C9C6, 1); // 2 PLAYERS
                textBox3.Text = backend.GetText(0xD, 0x10107, 1); // TM AND © 1988
                textBox4.Text = backend.GetText(0x18, 0x10117, 1); // KONAMI INDUSTRY CO.,LTD.
                textBox5.Text = backend.GetText(0xB, 0x10132, 1); // LICENSED  BY
                textBox6.Text = backend.GetText(0x18, 0x10140, 1); // NINTENDO OF AMERICA INC.
                
                // Game Test
                textBox7.Text = backend.GetText(0x8, 0x791C); // NEW YORK
                textBox8.Text = backend.GetText(0x7, 0x7925); // CHICAGO
                textBox9.Text = backend.GetText(0xB, 0x792D); // LOS ANGELES
                textBox10.Text = backend.GetText(0x8, 0x7939); // MONTREAL
                textBox11.Text = backend.GetText(0x7, 0x7942); // TORONTO
                textBox12.Text = backend.GetText(0x8, 0x794A); // EDMONTON
                textBox13.Text = backend.GetText(0x9, 0x7953); // VANCOUVER
                textBox14.Text = backend.GetText(0x9, 0x795D); // MINNESOTA
                textBox15.Text = backend.GetText(0xB, 0x7A2E); // SELECT GAME
                textBox16.Text = backend.GetText(0xA, 0x7A3A); // EXHIBITION
                textBox17.Text = backend.GetText(0xA, 0x7A45); // TOURNAMENT
                textBox18.Text = backend.GetText(0xD, 0x7A50); // JUNIOR LEAGUE
                textBox19.Text = backend.GetText(0xE, 0x7A5E); // COLLEGE LEAGUE
                textBox20.Text = backend.GetText(0xA, 0x7A6D); // PRO LEAGUE
                textBox21.Text = backend.GetText(0x6, 0x1CB7F); // JUNIOR
                textBox22.Text = backend.GetText(0x6, 0x1CB86); // LEAGUE
                textBox23.Text = backend.GetText(0x7, 0x1CB8F); // COLLEGE
                textBox24.Text = backend.GetText(0x6, 0x1CB97); // LEAGUE
                textBox25.Text = backend.GetText(0x3, 0x1CBA0); // PRO
                textBox26.Text = backend.GetText(0x6, 0x1CBA4); // LEAGUE
                textBox27.Text = backend.GetText(0xD, 0x1CBF6); // SELECT LEAGUE
                textBox28.Text = backend.GetText(0x6, 0x1CC06); // JUNIOR
                textBox29.Text = backend.GetText(0x7, 0x1CC0F); // COLLEGE
                textBox30.Text = backend.GetText(0x3, 0x1CC19); // PRO
                textBox31.Text = backend.GetText(0xB, 0x1CC1F); // SELECT TEAM
                textBox32.Text = backend.GetText(0x4, 0x1CC7D); // HALF
                textBox33.Text = backend.GetText(0x4, 0x1CC82); // TIME
                textBox34.Text = backend.GetText(0x5, 0x1CC87); // DEMO1
                textBox35.Text = backend.GetText(0x4, 0x1CC8F); // HALF
                textBox36.Text = backend.GetText(0x4, 0x1CC94); // TIME
                textBox37.Text = backend.GetText(0x5, 0x1CC99); // DEMO2
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(FullFilename);

                backend.UpdateText(0x7, textBox1.Text, 0x1C9BB, 1);
                backend.UpdateText(0x8, textBox2.Text, 0x1C9C6, 1);
                backend.UpdateText(0xD, textBox3.Text, 0x10107, 1);
                backend.UpdateText(0x18, textBox4.Text, 0x10117, 1);
                backend.UpdateText(0xB, textBox5.Text, 0x10132, 1);
                backend.UpdateText(0x18, textBox6.Text, 0x10140, 1);

                backend.UpdateText(0x8, textBox7.Text, 0x791C);
                backend.UpdateText(0x7, textBox8.Text, 0x7925);
                backend.UpdateText(0xB, textBox9.Text, 0x792D);
                backend.UpdateText(0x8, textBox10.Text, 0x7939);
                backend.UpdateText(0x7, textBox11.Text, 0x7942);
                backend.UpdateText(0x8, textBox12.Text, 0x794A);
                backend.UpdateText(0x9, textBox13.Text, 0x7953);
                backend.UpdateText(0x9, textBox14.Text, 0x795D);
                backend.UpdateText(0xB, textBox15.Text, 0x7A2E);
                backend.UpdateText(0xA, textBox16.Text, 0x7A3A);
                backend.UpdateText(0xA, textBox17.Text, 0x7A45);
                backend.UpdateText(0xD, textBox18.Text, 0x7A50);
                backend.UpdateText(0xE, textBox19.Text, 0x7A5E);
                backend.UpdateText(0xA, textBox20.Text, 0x7A6D);
                backend.UpdateText(0x6, textBox21.Text, 0x1CB7F);
                backend.UpdateText(0x6, textBox22.Text, 0x1CB86);
                backend.UpdateText(0x7, textBox23.Text, 0x1CB8F);
                backend.UpdateText(0x6, textBox24.Text, 0x1CB97);
                backend.UpdateText(0x3, textBox25.Text, 0x1CBA0);
                backend.UpdateText(0x6, textBox26.Text, 0x1CBA4);
                backend.UpdateText(0xD, textBox27.Text, 0x1CBF6);
                backend.UpdateText(0x6, textBox28.Text, 0x1CC06);
                backend.UpdateText(0x7, textBox29.Text, 0x1CC0F);
                backend.UpdateText(0x3, textBox30.Text, 0x1CC19);
                backend.UpdateText(0xB, textBox31.Text, 0x1CC1F);
                backend.UpdateText(0x4, textBox32.Text, 0x1CC7D);
                backend.UpdateText(0x4, textBox33.Text, 0x1CC82);
                backend.UpdateText(0x5, textBox34.Text, 0x1CC87);
                backend.UpdateText(0x4, textBox35.Text, 0x1CC8F);
                backend.UpdateText(0x4, textBox36.Text, 0x1CC94);
                backend.UpdateText(0x5, textBox37.Text, 0x1CC99);

                MessageBox.Show(@"Updated!", @"Blades of Steel Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonOpenRom_Click(sender, e);
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonUpdate_Click(sender, e);
        }

        private void ValidateTitleTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            /*
             * 1 2 8 9 A B C D E F
             * I K L M N O P R S T
             * U Y . , © space
             */
            Regex regex = new Regex("[^A-Fa-fK-Pk-pR-Ur-u1-28-9IiYy.,©\\s]");

            foreach (Control control in Controls)
            {
                if (control is GroupBox)
                {
                    if (control.Name == groupBoxTitle.Name)
                    {
                        foreach (Control controlInGroupBox in control.Controls)
                        {
                            if (controlInGroupBox is TextBox)
                            {
                                TextBox textBox = (TextBox)controlInGroupBox;
                                MatchCollection matches = regex.Matches(textBox.Text);
                                if (matches.Count > 0)
                                {
                                    Console.WriteLine(@"textbox: " + textBox.Text);
                                    isValid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (isValid)
            {
                MessageBox.Show(@"Title text is valid!", @"Blades of Steel Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Title text is invalid."
                                + Environment.NewLine
                                + @"If the ROM is updated, invalid characters will be replaced with a space."
                                + Environment.NewLine
                                + Environment.NewLine
                                + @"Valid characters: "
                                + Environment.NewLine
                                + @"1 2 8 9 A B C D E F"
                                + Environment.NewLine
                                + @"I K L M N O P R S T"
                                + Environment.NewLine
                                + @"U Y . , © space",
                                @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateGameTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            /*
             * 0 1 2 3 4 5 6 7 8 9
             * A B C D E F G H I J
             * K L M N O P Q R S T
             * U V W X Y Z space
             */
            Regex regex = new Regex("[^a-zA-Z0-9\\s]");

            foreach (Control control in Controls)
            {
                if (control is GroupBox)
                {
                    if (control.Name == groupBoxGame.Name)
                    {
                        foreach (Control controlInGroupBox in control.Controls)
                        {
                            if (controlInGroupBox is TextBox)
                            {
                                TextBox textBox = (TextBox)controlInGroupBox;
                                MatchCollection matches = regex.Matches(textBox.Text);
                                if (matches.Count > 0)
                                {
                                    Console.WriteLine(@"textbox: " + textBox.Text);
                                    isValid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (isValid)
            {
                MessageBox.Show(@"Game text is valid!", @"Blades of Steel Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Game text is invalid."
                                + Environment.NewLine
                                + @"If the ROM is updated, invalid characters will be replaced with a space."
                                + Environment.NewLine
                                + Environment.NewLine
                                + @"Valid characters: "
                                + Environment.NewLine
                                + @"0 1 2 3 4 5 6 7 8 9"
                                + Environment.NewLine
                                + @"A B C D E F G H I J"
                                + Environment.NewLine
                                + @"K L M N O P Q R S T"
                                + Environment.NewLine
                                + @"U V W X Y Z space",
                                @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
