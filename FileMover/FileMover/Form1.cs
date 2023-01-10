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

    public partial class Form1 : Form
    {
        private List<string> folderPaths;
        private FolderBrowserDialog folderBrowserDialog;
        private DateTime fromDate;
        private DateTime toDate;
        private List<string> toFolders;
        private List<string> fromFolders;
        private int toPathCode = 0;
        private int fromPathCode = 1;
        public Form1()
        {
            InitializeComponent();
            folderPaths = new List<string>();
            toFolders = new List<string>();
            fromFolders = new List<string>();
        }

        private void fromBrowser_HelpRequest(object sender, EventArgs e)
        {

        }

        private void fetchFolderPath(int toOrFrom, TextBox inputFieldName)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (inputFieldName.Text != "")
                {
                    Console.WriteLine("in if");
                    addFolderPath(toOrFrom, inputFieldName);
                }
                else
                {
                    Console.WriteLine("in else");
                    addFolderPath(toOrFrom, inputFieldName);
                }
            }
        }

        // TODO - If a field already has a directory path in it but a new path is chosen, find the old in the List<string>
        // replace it with the new in order to maintain the correct order of directories in the List
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
            fetchFolderPath(toPathCode, fromInputOne);
        }

        private void fromBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInputTwo);
        }

        private void fromBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInputThree);
        }

        private void fromBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInputFour);
        }

        private void fromBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInputFive);
        }

        private void fromBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(toPathCode, fromInputSix);
        }
        #endregion
        #region toButtons
        private void button1_Click_1(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputOne);
        }

        private void toBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputTwo);
        }

        private void toBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputThree);
        }

        private void toBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputFour);
        }

        private void toBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputFive);
        }

        private void toBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(fromPathCode, toInputSix);
        }
        #endregion
        #region executeButtons
        private void button1_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputOne, toInputOne);
        }

        private void executeBtnTwo_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputTwo, toInputTwo);
        }

        private void executeBtnThree_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputThree, toInputThree);
        }

        private void executeBtnFour_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputFour, toInputFour);
        }

        private void executeBtnFive_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputFive, toInputFive);
        }

        private void executeBtnSix_Click(object sender, EventArgs e)
        {
            MoveAllDataInDir(fromInputSix, toInputSix);
        }

        #endregion
        #region clearButtons
        private void button1_Click_2(object sender, EventArgs e)
        {
            fromInputOne.Text = "";
            fromInputTwo.Text = "";
            fromInputThree.Text = "";
            fromInputFour.Text = "";
            fromInputFive.Text = "";
            fromInputSix.Text = "";

            toInputOne.Text = "";
            toInputTwo.Text = "";
            toInputThree.Text = "";
            toInputFour.Text = "";
            toInputFive.Text = "";
            toInputSix.Text = "";

            folderPaths.Clear();
        }

        private void clearButton1_Click(object sender, EventArgs e)
        {
            clearField(fromInputOne, toInputOne);
        }

        private void clearButton2_Click(object sender, EventArgs e)
        {
            clearField(fromInputTwo, toInputTwo);
        }

        private void clearButton3_Click(object sender, EventArgs e)
        {
            clearField(fromInputThree, toInputThree);
        }

        private void clearButton4_Click(object sender, EventArgs e)
        {
            clearField(fromInputFour, toInputFour);
        }

        private void clearButton5_Click(object sender, EventArgs e)
        {
            clearField(fromInputFive, toInputFive);
        }

        private void clearButton6_Click(object sender, EventArgs e)
        {
            clearField(fromInputSix, toInputSix);
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
            onExit();
            // TODO - Execute all move functions IF the FROM and TO directories dont override each other
            // and skips over empty directory input fields
            // TODO - Return this function to the executeButtons region when finished
        }

        private void FetchAllDataInDir()
        {
            // TODO - See about moving some stuff that fetches Data in from a Directory 
            // from the MoveAllDataInDir function
        }

        // Gets the path to the Documents folder and begins the process of creating a folder and .txt directory path files
        private void saveLastDirectories()
        {
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            createFolder(documentsPath);
        }

        // Creates a folder named FileMover in which the directory path .txt files are stored
        private void createFolder(string pathString)
        {
            string fileName = "FileMover";
            pathString = System.IO.Path.Combine(pathString, fileName);
            
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
            else
            {
                Console.WriteLine("Folder \"{0}\" already exists.", fileName);
            }

            string sFolderPaths = "";
            string fromFileName = "fromFilePaths.txt";
            writeSaveFile(fromFolders, sFolderPaths, pathString, fromFileName);

            sFolderPaths = "";
            string toFileName = "toFilePaths.txt";
            writeSaveFile(toFolders, sFolderPaths, pathString, toFileName);
        }

        // Writes .txt files with TO or FROM directory paths
        private void writeSaveFile(List<string> folders, string sFoldersPath, string documentsPath, string toOrFrom)
        {
            int i = 0;
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

        private void loadLastDirectories()
        {
            File.OpenText("");
            // TODO - Load last used directories from save file
        }

        private void MoveAllDataInDir(TextBox fromInput, TextBox toInput)
        {
            try
            {
                // TODO - Clean this mess up <3
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
                    Console.WriteLine(files.Count);
                    string moveFrom = fromInput.Text + @"\" + fileName.ToString();
                    string moveTo = toInput.Text + @"\" + fileName.ToString();
                    moveFiles(moveFrom, moveTo);
                    Console.WriteLine(increment);
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
            Console.WriteLine(fromDate);
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            toDate = toDateTimePicker.Value;
            Console.WriteLine(toDate);
        }

        // TODO - Make the app save data on exit
        private void onExit()
        {
            saveLastDirectories();
        }
    }
}
