using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMover
{

    public partial class Form1 : Form
    {
        private List<string> folderNames;
        private FolderBrowserDialog folderBrowserDialog;
        //private OpenFileDialog openFileDialog;
        private DateTime fromDate;
        private DateTime toDate;
        public Form1()
        {
            InitializeComponent();
            folderNames = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void fromBrowser_HelpRequest(object sender, EventArgs e)
        {

        }

        private void fetchFolderPath(object btnRequest, TextBox inputFieldName)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (inputFieldName.Text != "")
                {
                    folderNames.RemoveAt(folderNames.Count-1);
                    folderNames.Add(folderBrowserDialog.SelectedPath);
                    inputFieldName.Text = folderNames.Last();
                    //Console.WriteLine(folderNames.Count);
                    //Console.WriteLine(folderNames.Last().ToString());
                }
                else
                {
                    folderNames.Add(folderBrowserDialog.SelectedPath);
                    inputFieldName.Text = folderNames.Last();
                    //Console.WriteLine(folderNames.Count);
                    //Console.WriteLine(folderNames.Last().ToString());
                }
            }
        }

        private void fromBtn_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputOne);
        }

        private void fromBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputTwo);
        }

        private void fromBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputThree);
        }

        private void fromBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputFour);
        }

        private void fromBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputFive);
        }

        private void fromBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, fromInputSix);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputOne);
        }

        private void toBtnTwo_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputTwo);
        }

        private void toBtnThree_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputThree);
        }

        private void toBtnFour_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputFour);
        }

        private void toBtnFive_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputFive);
        }

        private void toBtnSix_Click(object sender, EventArgs e)
        {
            fetchFolderPath(sender, toInputSix);
        }

        private void executeBtnTwo_Click(object sender, EventArgs e)
        {

        }

        private void executeBtnThree_Click(object sender, EventArgs e)
        {

        }

        private void executeBtnFour_Click(object sender, EventArgs e)
        {

        }

        private void executeBtnFive_Click(object sender, EventArgs e)
        {

        }

        private void executeBtnSix_Click(object sender, EventArgs e)
        {

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

            folderNames.Clear();
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
