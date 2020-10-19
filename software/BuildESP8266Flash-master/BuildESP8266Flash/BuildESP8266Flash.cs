using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO; //For file writing

namespace BuildESP8266Flash
{
    public partial class BuildESP8266Flash : Form
    {
        public BuildESP8266Flash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Function to process the file select events
        private void selectFile(TextBox pathText)
        {
            string currentFilePath = pathText.Text;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            file.Title = "Select binary file";
            file.InitialDirectory = currentFilePath; //check if this is a directory, if not, open in the current directory
            if (file.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = file.FileName;
            }
            pathText.Text = currentFilePath;
        }

        //Check string is valid hex string (with or without leading 0x) and return the integer
        //The default final file size is 0x7efff = 520,191+1, so the limit of Int32 as 2,147,483,647 should be fine
        private Int32 ConvertHexStringToInt(String hexString, bool displayMessage )
        {
            try
            {
                hexString = hexString.Trim();
                //remove the 0x if present
                hexString = hexString.Replace("0x", "");
                hexString = hexString.Replace("0X", "");
                int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
                return num;
            }
            catch (FormatException)
            {
                if (displayMessage) {
                    MessageBox.Show("The input is not a valid hex format", "Format Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return -1;
            }
            catch (ArgumentNullException)
            {
                if (displayMessage)
                {
                    MessageBox.Show("The input is empty", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return -1;
            }
            catch (OverflowException)
            {
                if (displayMessage)
                {
                    MessageBox.Show("The input strign is greater than the Int32 limit", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return -1;
            }
        }

        //Write the required number of fill bytes
        //Note fillByteInt has been checked to be 0<= fillByteInt<=15
        private void WriteFillBytes( FileStream fs, Int32 numFillBytes, Int32 fillByteInt )
        {
            byte fillByte = (byte)fillByteInt;
            for ( int idx = 0; idx < numFillBytes; idx++ )
            {
                fs.WriteByte(fillByte);
            }
            return;
        }

        //Copy the input file to the output file, return the nnumber of bytes copied
        private Int32 CopyFileToOutput( FileStream fs, String fileName )
        {
            using ( FileStream fs_in = File.OpenRead( fileName ) )
            {
                Int32 fileLength = 0;
                byte[] b = new byte[1024];
                Int32 readLength;
                while ( ( readLength = fs_in.Read( b, 0, b.Length )) > 0 )
                {
                    fs.Write(b, 0, readLength);
                    fileLength += readLength;
                }
                return fileLength;
            }
        }

        //GUI Functions
        //========================
        private void selectButton1_Click(object sender, EventArgs e)
        {
            selectFile(pathText1);
        }

        private void selectButton2_Click(object sender, EventArgs e)
        {
            selectFile(pathText2);
        }

        private void selectButton3_Click(object sender, EventArgs e)
        {
            selectFile(pathText3);
        }

        private void selectButton4_Click(object sender, EventArgs e)
        {
            selectFile(pathText4);
        }

        private void selectButton5_Click(object sender, EventArgs e)
        {
            selectFile(pathText5);
        }

        private void selectButton6_Click(object sender, EventArgs e)
        {
            selectFile(pathText6);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string currentFilePath = savePathText.Text;
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            file.Title = "Select binary file";
            file.InitialDirectory = currentFilePath; //check if this is a directory, if not, open in the current directory
            if (file.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = file.FileName;
            }
            savePathText.Text = currentFilePath;
        }

        private void hexText1_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText1.Text, true);
        }
        private void hexText2_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText2.Text, true);
        }
        private void hexText3_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText3.Text, true);
        }
        private void hexText4_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText4.Text, true);
        }
        private void hexText5_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText5.Text, true);
        }
        private void hexText6_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(hexText6.Text, true);
        }
        private void fileSizeHexText_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(fileSizeHexText.Text, true);
        }
        private void fillByteHexText_Leave(object sender, EventArgs e)
        {
            ConvertHexStringToInt(fillByteHexText.Text, true);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            //Create tuple list
            List<Tuple<CheckBox, TextBox, TextBox>> inputList = new List<Tuple<CheckBox, TextBox, TextBox>>();
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox1, pathText1, hexText1));
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox2, pathText2, hexText2));
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox3, pathText3, hexText3));
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox4, pathText4, hexText4));
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox5, pathText5, hexText5));
            inputList.Add(new Tuple<CheckBox, TextBox, TextBox>(checkBox6, pathText6, hexText6));
            
            //Load the checked fields into an array - file name and starting index
            List<FilesToLoad> fileList = new List<FilesToLoad>();
            int numFilesToLoad = 0;
            for (int idx = 1; idx <= 6; idx++)
            {
                //Check if item is not ticked
                if (!inputList[idx-1].Item1.Checked) {
                    continue;
                }

                //Load the file name and offset into array
                String fileName = inputList[idx - 1].Item2.Text;
                String offsetHex = inputList[idx - 1].Item3.Text;
                Int32 offsetInt = ConvertHexStringToInt(offsetHex, false);
                if (offsetInt < 0)
                {
                    MessageBox.Show("Offset " + idx + " is not valid. Aborting", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                fileList.Add(new FilesToLoad(fileName, offsetInt));
                numFilesToLoad++;
            }
            fileList.Sort();

            //Get the final size and file byte
            Int32 finalFileSize_bytes = ConvertHexStringToInt(fileSizeHexText.Text, false);
            if (finalFileSize_bytes < 0)
            {
                MessageBox.Show("The final file size is not valid. Aborting", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int32 fillByte = ConvertHexStringToInt(fillByteHexText.Text, false);
            if (fillByte < 0 || fillByte > 15)
            {
                MessageBox.Show("The fill byte ("+fillByte+") is not valid. It should be a hex number between 0 and 15. Aborting", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Output file name
            String outputFile = savePathText.Text;
            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            {
                BinaryWriter binaryWriter = new BinaryWriter(fs);
                Int32 currentOutFileOffset = 0;
                Int32 numFillBytes;
                
                for (int idx = 0; idx < numFilesToLoad; idx++)
                {
                    //Get the offset
                    Int32 currentStartOffset = fileList[idx].Offset;
                    numFillBytes = currentStartOffset - currentOutFileOffset;
                    if ( numFillBytes < 0 )
                    {
                        MessageBox.Show(@"When trying to write file " + idx + ", the current offset is after the wanted start offset. " +
                            "Incompatible file sizes and offset values", "File Size/Offset Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; //using automatically closes the  file stream
                    }
                    if ( numFillBytes > 0 )
                    {
                        WriteFillBytes( fs,numFillBytes, fillByte );
                        currentOutFileOffset += numFillBytes;
                    }

                    //Write the file
                    Int32 numByteCopied = CopyFileToOutput( fs, fileList[idx].FileName );
                    currentOutFileOffset += numByteCopied;
                }

                //Add the final fill to get to the total length
                numFillBytes = finalFileSize_bytes - currentOutFileOffset + 1; //+1 for final byte, code is trying to get to just in front of desired offset
                if ( numFillBytes < 0 )
                {
                    MessageBox.Show(@"When trying finish the file the current offset is after the wanted file length. " +
                        "Incompatible file sizes and offset values", "File Size/Offset Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //using automatically closes the  file stream
                }
                if ( numFillBytes > 0 )
                {
                    WriteFillBytes( fs,numFillBytes, fillByte );
                    currentOutFileOffset += numFillBytes;
                }

            } //End output file using

            MessageBox.Show("Merged firmware file created", "File created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

    //Class to store the file names and offests in the list
    //From: http://stackoverflow.com/a/8914299 and http://stackoverflow.com/a/3309593
    public class FilesToLoad : IComparable
    {
        public String FileName { get; set; }
        public Int32 Offset { get; set; }

        public FilesToLoad()
        {
        }

        public FilesToLoad(string fileName, Int32 offset)
        {
            FileName = fileName;
            Offset = offset;
        }

        public int CompareTo(object obj)
        {
            FilesToLoad fileToLoad = obj as FilesToLoad;
            if (fileToLoad == null)
            {
                return 1;
            }
            if (fileToLoad.Offset < Offset )
            {
                return 1;
            }
            if (fileToLoad.Offset > Offset )
            {
                return -1;
            }

            // The Offsets are equivalent.
            return 0;
        }
    }
}
