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
        //private OpenFileDialog openFileDialog;
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

        private void listOutChildFolders()
        {

        }

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

        private void ExecuteAllBtn_Click(object sender, EventArgs e)
        {
            // TODO - Execute all move functions IF the FROM and TO directories dont override each other
            // and skips over empty directory input fields
        }

        private void FetchAllDataInDir()
        {
            // TODO - See about moving some stuff that fetches Data in from a Directory 
            // from the MoveAllDataInDir function
        }

        private void MoveAllDataInDir(TextBox fromInput, TextBox toInput)
        {
            // TODO - Clean this mess up <3
            List<string> files = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(fromInput.Text);
            FileInfo[] dirFilesCount = dir.GetFiles("*.txt");
            int increment = 100 / dirFilesCount.Count();
            incrementLoadingBar(0, true);
            foreach (var fileName in dirFilesCount)
            {
                files.Add(fileName.ToString());
                FilesRemainingLabel.Text = files.Count.ToString();
                Console.WriteLine(files.Count);
                string moveFrom = fromInput.Text + @"\" + fileName.ToString();
                string moveTo = toInput.Text + @"\" + fileName.ToString();
                moveFiles(moveFrom, moveTo);
                Console.WriteLine(increment);
                incrementLoadingBar(increment, false);
            }
            Console.WriteLine("Executed Move");
        }

        private void moveFiles(string moveFrom, string moveTo)
        {
            File.Move(moveFrom, moveTo);
        }

        private void incrementLoadingBar(int totalNum, bool reset)
        {
            // TODO - Fix - Loading bar gets stucky wucky at the end, doesn't go up to 100% for some reason
            if (reset == true)
            {
                progressBar1.Value = totalNum;
            }
            else if (reset == false)
            {
                progressBar1.Value += totalNum;
            }
        }

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
    }
}
