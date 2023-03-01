using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMover
{

    public partial class FormFileMover : Form
    {
        private List<string> folderPaths;
        private FolderBrowserDialog folderBrowserDialog;
        private DateTime fromDate;
        private DateTime toDate;
        private List<string> toFolders;
        private List<string> fromFolders;
        private int toPathCode = 0;
        private int fromPathCode = 1;
        private string documentsPath;
        private string fileName;
        private string fromFileName = "fromFilePaths.txt";
        private string toFileName = "toFilePaths.txt";
        public FormFileMover()
        {
            InitializeComponent();

            documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileName = "FileMover";
            documentsPath = System.IO.Path.Combine(documentsPath, fileName);

            folderPaths = new List<string>();
            toFolders = new List<string>();
            fromFolders = new List<string>();
        }

        // Fetches the directory paths and sends them to be stored
        private void fetchFolderPath(int toOrFrom, TextBox inputFieldName)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (inputFieldName.Text != "")
                {
                    addFolderPath(toOrFrom, inputFieldName);
                }
                else
                {
                    addFolderPath(toOrFrom, inputFieldName);
                }
            }
        }

        // Adds directory paths to List<String> 
        private void addFolderPath(int toOrFrom, TextBox inputFieldName)
        {
            if (toOrFrom == 0)
            {
                if (fromFolders.Contains(folderBrowserDialog.SelectedPath) == true)
                {
                    inputFieldName.Text = folderBrowserDialog.SelectedPath;
                    Console.WriteLine("Path already exists");
                    return;
                }
                else
                {
                    fromFolders.Add(folderBrowserDialog.SelectedPath);
                    inputFieldName.Text = fromFolders.Last();
                    Console.WriteLine(fromFolders.Last().ToString());
                    Console.WriteLine(fromFolders.Count);
                }
            }
            else if (toOrFrom == 1)
            {
                if (toFolders.Contains(folderBrowserDialog.SelectedPath) == true)
                {
                    inputFieldName.Text = folderBrowserDialog.SelectedPath;
                    Console.WriteLine("Path already exists");
                    return;
                }
                else
                {
                    toFolders.Add(folderBrowserDialog.SelectedPath);
                    inputFieldName.Text = toFolders.Last();
                    Console.WriteLine(toFolders.Last().ToString());
                    Console.WriteLine(toFolders.Count);
                }
            }
        }

        #region fromButtons
        private void fromBtn_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput1);
        }

        private void fromBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput2);
        }

        private void fromBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput3);
        }

        private void fromBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput4);
        }

        private void fromBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput5);
        }

        private void fromBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInput6);
        }
        #endregion
        #region toButtons
        private void button1_Click_1(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput1);
        }

        private void toBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput2);
        }

        private void toBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput3);
        }

        private void toBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput4);
        }

        private void toBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput5);
        }

        private void toBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInput6);
        }
        #endregion
        #region executeButtons
        private void button1_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput1, toInput1);
        }

        private void executeBtnTwo_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput2, toInput2);
        }

        private void executeBtnThree_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput3, toInput3);
        }

        private void executeBtnFour_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput4, toInput4);
        }

        private void executeBtnFive_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput5, toInput5);
        }

        private void executeBtnSix_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInput6, toInput6);
        }

        #endregion
        #region clearButtons
        private void button1_Click_2(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            DialogResult dialogResult = MessageBox.Show("Do you wish to clear all directory paths.", "File Mover", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                fromInput1.Text = "";
                fromInput2.Text = "";
                fromInput3.Text = "";
                fromInput4.Text = "";
                fromInput5.Text = "";
                fromInput6.Text = "";

                toInput1.Text = "";
                toInput2.Text = "";
                toInput3.Text = "";
                toInput4.Text = "";
                toInput5.Text = "";
                toInput6.Text = "";

                folderPaths.Clear();
                toFolders.Clear();
                fromFolders.Clear();

                File.WriteAllText(documentsPath + @"\" + fromFileName, String.Empty);
                File.WriteAllText(documentsPath + @"\" + toFileName, String.Empty);
            }
            else
            {
                return;
            }
        }

        private void clearButton1_Click(object sender, EventArgs e)
        {
            clearField(fromInput1, toInput1);
        }

        private void clearButton2_Click(object sender, EventArgs e)
        {
            clearField(fromInput2, toInput2);
        }

        private void clearButton3_Click(object sender, EventArgs e)
        {
            clearField(fromInput3, toInput3);
        }

        private void clearButton4_Click(object sender, EventArgs e)
        {
            clearField(fromInput4, toInput4);
        }

        private void clearButton5_Click(object sender, EventArgs e)
        {
            clearField(fromInput5, toInput5);
        }

        private void clearButton6_Click(object sender, EventArgs e)
        {
            clearField(fromInput6, toInput6);
        }

        private void clearField(TextBox from, TextBox to)
        {
            folderPaths.Remove(from.Text);
            folderPaths.Remove(to.Text);
            from.Text = "";
            to.Text = "";
        }
        #endregion
        private void ExecuteAllBtn_Click(object sender, EventArgs e)
        {
            int inputFieldNum = 1;
            while (this.Controls.ContainsKey("fromInput" + inputFieldNum.ToString()))
            {
                TextBox fromInput = this.Controls["fromInput" + inputFieldNum.ToString()] as TextBox;
                TextBox toinput = this.Controls["toInput" + inputFieldNum.ToString()] as TextBox;
                MoveAllDataInDir(fromInput, toinput);
                inputFieldNum++;
            }
        }

        private void FetchAllDataInDir()
        {
            // TODO - See about moving some stuff that fetches Data in from a Directory 
            // from the MoveAllDataInDir function
        }

        // TODO - Saving paths is still wonky, fix it
        // Gets the path to the Documents folder and creates a folder and .txt directory path files
        private void saveLastDirectories(string pathString)
        {
            string sFolderPaths = "";
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
            else
            {
                Console.WriteLine("Folder \"{0}\" already exists.", fileName);
            }
            writeSaveFile(fromFolders, sFolderPaths, pathString, fromFileName);
            writeSaveFile(toFolders, sFolderPaths, pathString, toFileName);
        }

        // Writes .txt files with TO or FROM directory paths
        private void writeSaveFile(List<string> folders, string sFoldersPath, string documentsPath, string toOrFrom)
        {
            int i = 0;
            if (folders != null)
            {
                foreach (var item in folders)
                {
                    sFoldersPath += item + "\n";
                    Console.WriteLine(sFoldersPath);
                    if (i < folders.Count)
                    {
                        File.WriteAllText(documentsPath + @"\" + toOrFrom, sFoldersPath);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        // Loads last used directories from save file
        private void loadLastDirectories()
        {
            // True = "To" directories
            // False = "From" directories
            string toFileName = "toFilePaths.txt";
            string fromFileName = "fromFilePaths.txt";
            try
            {
                string toFileStringified = File.ReadAllText(documentsPath + @"\" + toFileName);
                string fromFileStringified = File.ReadAllText(documentsPath + @"\" + fromFileName);
                InputFieldsFromLoad(true, toFileStringified);
                InputFieldsFromLoad(false, fromFileStringified);
            }
            catch (Exception)
            {
                Console.WriteLine("First load of software, no load paths set, will create paths on exit.");
            }

        }

        // Used to populate the to and from fields
        private void InputFieldsFromLoad(bool toOrFrom, string stringToSlice)
        {
            string[] folders = stringToSlice.Split('\n');
            int inputFieldNum = 1;
            foreach (string folder in folders)
            {
                if (toOrFrom == true && folder != "")
                {
                    if (this.Controls.ContainsKey("toInput" + inputFieldNum.ToString()))
                    {
                        TextBox txtBox = this.Controls["toInput" + inputFieldNum.ToString()] as TextBox;
                        txtBox.Text = folder;
                        toFolders.Add(folder);
                        inputFieldNum++;
                    }
                }
                if (toOrFrom != true && folder != "")
                {
                    if (this.Controls.ContainsKey("fromInput" + inputFieldNum.ToString()))
                    {
                        TextBox txtBox = this.Controls["fromInput" + inputFieldNum.ToString()] as TextBox;
                        txtBox.Text = folder;
                        fromFolders.Add(folder);
                        inputFieldNum++;
                    }
                }
                Console.WriteLine(folder);
            }
            inputFieldNum = 1;
        }

        private void MoveAllDataInDir(TextBox fromInput, TextBox toInput)
        {
            try
            {
                List<string> files = new List<string>();
                DirectoryInfo dir = new DirectoryInfo(fromInput.Text);
                FileInfo[] dirFilesCount = dir.GetFiles("*");
                //Does the same as the "*" but with more RegEx for customisation, will keep it as a backup
                //FileInfo[] dirFilesCount = dir.GetFiles("*" + @"." + "*");

                int increment = 100 / dirFilesCount.Count();
                incrementLoadingBar(0, 0);

                foreach (var fileName in dirFilesCount)
                {
                    files.Add(fileName.ToString());
                    FilesRemainingLabel.Text = files.Count.ToString();
                    //Console.WriteLine(files.Count);
                    string moveFrom = fromInput.Text + @"\" + fileName.ToString();
                    string moveTo = toInput.Text + @"\" + fileName.ToString();


                    DateTime creation = File.GetCreationTime(moveFrom);
                    DateTime modification = File.GetLastWriteTime(moveFrom);

                    if (radioButtonDateCreated.Checked == true && fromDateTimePicker.Value.Date != toDateTimePicker.Value.Date && fromDateTimePicker.Value.Date < toDateTimePicker.Value.Date)
                    {
                        if (creation.Date <= toDateTimePicker.Value.Date && creation.Date >= fromDateTimePicker.Value.Date)
                        {
                            moveFiles(moveFrom, moveTo);

                            //Console.WriteLine("File created on: " + creation.Date);
                            //Console.WriteLine(radioButtonDateCreated.Checked);
                            //Console.WriteLine("From: " + fromDateTimePicker.Value.Date.ToString());
                            //Console.WriteLine("To: " + toDateTimePicker.Value.Date.ToString());
                            //Console.WriteLine(moveFrom.ToString());
                            //Console.WriteLine(moveTo.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Found files that do not match this criterium");
                        }
                    }
                    else if (radioButtonDateModified.Checked == true && fromDateTimePicker.Value.Date != toDateTimePicker.Value.Date && fromDateTimePicker.Value.Date < toDateTimePicker.Value.Date)
                    {
                        if (modification.Date <= toDateTimePicker.Value.Date && modification.Date >= fromDateTimePicker.Value.Date)
                        {
                            moveFiles(moveFrom, moveTo);

                            //Console.WriteLine("File modified on: " + modification.Date);
                            //Console.WriteLine(radioButtonDateModified.Checked);
                            //Console.WriteLine("From: " + fromDateTimePicker.Value.Date.ToString());
                            //Console.WriteLine("To: " + toDateTimePicker.Value.Date.ToString());
                            //Console.WriteLine(moveFrom.ToString());
                            //Console.WriteLine(moveTo.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Found files that do not match this criterium");
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Invalid date format", "File Mover", MessageBoxButtons.OK);
                        return;
                    }

                    //Console.WriteLine(increment);
                    if (files.Count != dirFilesCount.Count())
                    {
                        incrementLoadingBar(increment, 1);
                    }
                    else if (files.Count == dirFilesCount.Count())
                    {
                        incrementLoadingBar(100, 2);
                    }
                }
                Console.WriteLine("Executed Move");
            }
            catch (Exception)
            {
                MessageBox.Show("Directory path is empty, please input a valid path.");
            }

        }

        private void moveFiles(string moveFrom, string moveTo)
        {
            File.Move(moveFrom, moveTo);
        }

        private void incrementLoadingBar(int increment, int reset)
        {
            // 0 for reset
            // 1 for incrementing
            // 2 for 100%
            if (reset == 0)
            {
                progressBar1.Value = increment;
            }
            else if (reset == 1)
            {
                progressBar1.Value += increment;
            }
            else if (reset == 2)
            {
                progressBar1.Value = increment;
            }
        }

        // TODO - Implement DateTime influencing the movement of files
        // TODO - Add a RadioButton that defines if DateTime is influencing the movement of files
        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDate = fromDateTimePicker.Value;
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            toDate = toDateTimePicker.Value;
        }

        // Saves data on exit
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLastDirectories(this.documentsPath);
            DialogResult dialogResult = MessageBox.Show("Directory paths have been saved", "File Mover", MessageBoxButtons.OK);
            if (dialogResult == DialogResult.OK)
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadLastDirectories();
        }

        private void radioButtonDateCreated_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
