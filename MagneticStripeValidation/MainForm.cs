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
using System.Threading.Tasks;
using System.Threading;


namespace MagneticStripeValidation
{
    public partial class MainForm : Form
    {
        private Dictionary<int, Dictionary<int, string>> _storedData = new Dictionary<int, Dictionary<int, string>>();
        private List<GiftCard> _giftCards = new List<GiftCard>();
        //private List<string> _trackData;
        private Dictionary<string, int> _trackData = new Dictionary<string, int>();
        private int _trackDataKey = 0;
        private string _fileName = "";
        private string _logsRootFolder = @"C:\Services\Loyalty\GiftCard\Logs";
        private bool _excludeSpecial = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {  }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtDelimeters.Text))
            {
                string delimeters = TxtDelimeters.Text;
                OpenFileDialog selectedFile = new OpenFileDialog();

                if (selectedFile.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(selectedFile.FileName);
                    LblFileName.Text = file.Name ;
                    _fileName = file.Name;
                    TxtStatus.Text += StoreData(selectedFile.FileName, delimeters);
                    Worker.WorkerReportsProgress = true;
                    Worker.RunWorkerAsync();

                    if (!Worker.IsBusy) Worker.CancelAsync();
                }
            }
            else
            {
                TxtStatus.Text += "Please input the delimeters of the file. Example: |-,-$-@" + Environment.NewLine;
            }
        }


        private void TxtMagstripeData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtStatus.Clear();
                if (string.IsNullOrEmpty(TxtMagstripeData.Text))
                    TxtStatus.Text += "PLEASE SWIPE A CARD." + Environment.NewLine;
                else
                {
                    string barcode = TxtBarcode.Text;
                    string trackData = ExcludeTrackThree(TxtMagstripeData.Text);
                    string track1Length = TxtTrack1Length.Text;
                    string track2Length = TxtTrack2Length.Text;

                    if (_storedData.Count() > 0)
                    {
                        if (!string.IsNullOrEmpty(track1Length) || !string.IsNullOrEmpty(track2Length))
                        {
                            //string validateMessage = ValidateMagstripeData(trackData);
                            string compareMessage = CompareMagstripeData(trackData);

                            if (compareMessage.Contains("Successfully"))
                            {
                                TxtStatus.Text += compareMessage;
                                //TxtStatus.Text += compareMessage;
                                TxtStatus.Text += ValidateBarcode(barcode, trackData);
                            }
                            else
                            {
                                TxtStatus.Text += compareMessage;
                                //TxtStatus.Text += compareMessage;
                            }
                        }
                        else
                        {
                            TxtStatus.Text += "Please input a length for TRACK 1 AND TRACK 2." + Environment.NewLine;
                        }
                    }
                    else
                    {
                        TxtStatus.Text += "Please import a file to proceed." + Environment.NewLine;
                    }
                }
                TxtMagstripeData.Clear();
                TxtBarcode.Clear();
                TxtBarcode.Focus();
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(TxtBarcode.Text))
                {
                    TxtMagstripeData.Focus();
                }
                else
                {
                    TxtStatus.Text += "Please input BARCODE." + Environment.NewLine;
                }
            }
        }
                     







        #region Custom Functions

        /// <summary>
        /// Converting a string array to char array
        /// </summary>
        /// <param name="stringArray">Array of Strings</param>
        /// <returns></returns>
        private char[] ConvertStringArray(string stringArray)
        {
            char[] charArray = new char[stringArray.Length];
            
            for (int index = 0; index < stringArray.Length; index++)
            {
                charArray[index] = Convert.ToChar(stringArray[index]);
            }
            return charArray;
        }

        /// <summary>
        /// Used to store data before validating the magstripe 
        /// </summary>
        /// <param name="fileName">File that is being based on.</param>
        /// <param name="delimeters">The Delimeter of the file or the splitter of the data inside the file</param>
        /// <returns></returns>
        private string StoreData(string fileName, string delimeters)
        {
            int counter = 0;
            string errorMessage = "";
            string[] lines = File.ReadAllLines(fileName);
            Dictionary<int, Dictionary<int, string>> data = new Dictionary<int, Dictionary<int, string>>();

            _storedData.Clear();
            _trackData.Clear();

            char[] convertedDelimeter = ConvertStringArray(delimeters);

            if ( lines.Length != 0)
            {
                foreach (var line in lines)
                {
                    string[] columns = line.Split(convertedDelimeter);
                    Dictionary<int, string> info = new Dictionary<int, string>();

                    for (int key = 0; key < columns.Length; key++)
                    {
                        info.Add(key, columns[key]);


                        if (columns[key].Contains("%B"))
                        {
                            _trackDataKey = key;
                            _trackData.Add(columns[key].Substring(0, columns[key].LastIndexOf('?') + 1), counter);
                        }
                            
                    }

                    data.Add(counter, info);
                    counter++;
                }
            }
            else errorMessage += "Please import a file to proceed" + Environment.NewLine;

            _storedData = data;

            return errorMessage;
        }

        private int CheckStoredData(BackgroundWorker worker, DoWorkEventArgs eventArgs)
        {
            int highestPercentageReached = 0;
            if (worker.CancellationPending)
            {
                eventArgs.Cancel = true;
            }
            else
            {
                int totalNumbers = 0;
                int currentNumber = 0;
                string[] directories = Directory.GetDirectories(_logsRootFolder);
                totalNumbers = GetTotalLines(directories);

                foreach (string directory in directories)
                {
                    string[] files = Directory.GetFiles(directory, "*" + _fileName + "*.*");
                    foreach (string file in files)
                    {
                        string[] lines = File.ReadAllLines(file);
                        if (lines.Length > 0)
                        {

                            for (int line = 0; line < lines.Length; line++)
                            {
                                currentNumber++;
                                decimal percentComplete = 0;
                                percentComplete = (currentNumber / (decimal)(totalNumbers)) * 100;

                                if (percentComplete > highestPercentageReached)
                                {
                                    highestPercentageReached = (int)percentComplete;
                                    worker.ReportProgress((int)percentComplete);
                                }
                                string trackData = lines[line].Substring(lines[line].LastIndexOf('-') + 2);

                                var foundData = _trackData.ContainsKey(trackData);
                                if (foundData)
                                {
                                    _storedData.Remove(_trackData[trackData]);
                                    _trackData.Remove(trackData);
                                }
                            }
                        }
                    }
                }
            }

            return highestPercentageReached;
        }

        private int GetTotalLines(string[] directories)
        {
            int totalCount = 0;
            foreach (string directory in directories)
            {
                string[] files = Directory.GetFiles(directory, "*" + _fileName + "*.*");
                foreach (string file in files)
                {
                    string[] lines = File.ReadAllLines(file);
                    totalCount += lines.Length;
                }
            }
            return totalCount;
        }



        /// <summary>
        /// Validating Magnetic Stripe Data based on the standard format
        /// </summary>
        /// <param name="trackData">Magnetic stripe data</param>
        /// <returns></returns>
        private string ValidateMagstripeData(string trackData)
        {
            bool isFail = false;
            int track1Length = Convert.ToInt32(TxtTrack1Length.Text);
            int track2Length = Convert.ToInt32(TxtTrack2Length.Text);
            string track2Data;
            string track1Data;
            string error = "";

            if (_excludeSpecial)
            {
                track1Data = trackData.Substring(track1Length);
                track2Data = trackData.Substring(track2Length);
            }
            else
            {
                track1Data = trackData.Substring(0, trackData.IndexOf('?') + 1);
                track2Data = trackData.Substring(trackData.IndexOf(';'), trackData.LastIndexOf('?') - track1Length + 1);

                if (track1Data.Length != track1Length)
                {
                    error += "Track1 Data Length is incorrect. Magstripe Track1 Length: " + track1Data.Length + Environment.NewLine;
                    isFail = true;
                }
                else
                {
                    if (track1Data[0] != '%' || track1Data[1] != 'B' || track1Data[track1Length - 1] != '?')
                    {
                        error += "Track 1 data does not meet the standard requirements." + Environment.NewLine;
                        isFail = true;
                    }
                }

                if (track2Data.Length != track2Length)
                {
                    error += "Track2 Data Length is incorrect. Magstripe Track2 Length: " + track2Data.Length + Environment.NewLine;
                    isFail = true;
                }
                else
                {
                    if (track2Data[0] != ';' || track2Data[track2Length - 1] != '?')
                    {
                        error += "Track 2 data does not meet the standard requirements." + Environment.NewLine;
                        isFail = true;
                        return error;
                    }
                }
            }

            if (!isFail)
                error = "Successfully Validated Magstripe" + Environment.NewLine;

            return error; 
        }

        /// <summary>
        /// Compare Magstripe data to the data from the imported file
        /// </summary>
        /// <param name="trackData"></param>
        /// <returns></returns>
        private string CompareMagstripeData(string trackData)
        {
            string error = "";
            bool found = false;
            int line = 0;
            
            foreach (var info in _storedData)
            {
                if (info.Value.TryGetValue(_trackDataKey, out string outTrackData))
                {
                    line++;
                    error = ValidateMagstripeData(outTrackData);
                    if (error.Contains("Successfully"))
                    {
                        if (outTrackData.Contains(trackData))
                        {
                            error += "Comparing Magstripe Success" + Environment.NewLine;
                            found = true;
                            break;
                        }
                    }
                }
            }

            if (found == false)
                error += "Magstripe data did not match on any Track Data from the file."+ Environment.NewLine;
            
            return error;
        }

        /// <summary>
        /// Validate barcode on the file and compare the track data to the imported file
        /// </summary>
        /// <param name="barcode">Scanned Barcode</param>
        /// <param name="trackData">Swiped Magnetic Stripe Data</param>
        /// <returns></returns>
        private string ValidateBarcode(string barcode, string trackData)
        {
            string errorMessage = "";
            bool found = false;
            foreach (var storedData in _storedData)
            {
                try
                {
                    bool barcodeMatch = false;
                    bool trackDataMatch = false;

                    if (storedData.Value.TryGetValue(1, out string outBarcode))
                        if (!string.IsNullOrEmpty(outBarcode))
                            if (barcode == outBarcode)
                                barcodeMatch = true;

                    if (storedData.Value.TryGetValue(_trackDataKey, out string outTrackData))
                        if (!string.IsNullOrEmpty(outTrackData))
                            if (trackData == ExcludeTrackThree(outTrackData))
                                trackDataMatch = true;

                    if (storedData.Value.TryGetValue(0, out string sequenceNumber)) { }
                    
                    if (barcodeMatch == true && trackDataMatch == true)
                    {
                        if (!CheckDuplicate(barcode))
                        {
                            CreateLogFile(trackData);
                            errorMessage += "Barcode and Magstripe is correct!" + Environment.NewLine;
                            errorMessage += "Sequence Number : " + sequenceNumber + Environment.NewLine;
                            found = true;
                        }
                        else errorMessage += "THE ACCOUNT IS ALREADY SWIPED. PLEASE SWIPE ANOTHER CARD." + Environment.NewLine;
                        
                    }
                }
                catch (Exception error)
                {
                    errorMessage += "Wrong input data. Error Message: " + error.Message + Environment.NewLine;
                }
            }

            if (found)
            {
                string removeMessage = RemoveSwiped(barcode);
                if (!removeMessage.Contains("Successful"))
                    errorMessage += removeMessage;
            }
            else errorMessage += "Barcode or Magnetic Stripe Data is incorrect!";
            return errorMessage;
        }

        /// <summary>
        /// Logs
        /// </summary>
        /// <param name="information"></param>
        private void CreateLogFile(string information)
        {
            string dateFolder = _logsRootFolder + @"\" + DateTime.Now.ToString("yyyyMMdd");
            string fileName = dateFolder + @"\" + _fileName + ".txt";
            
            Directory.CreateDirectory(dateFolder);

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss - ") + information + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(fileName, DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss - ") + information + Environment.NewLine);
            }
        }

        /// <summary>
        /// Used to load the data into the Data Grid View
        /// </summary>
        /// <param name="storedData">List of Data</param>
        private void LoadGridView(Dictionary<int, Dictionary<int, string>> storedData)
        {
            foreach (var data in storedData)
            {
                GiftCard card = new GiftCard();

                if (data.Value.TryGetValue(0, out string sequenceNumber))
                    card.SequenceNumber = sequenceNumber;

                if (data.Value.TryGetValue(1, out string barcode))
                    card.Barcode = barcode;

                if (data.Value.TryGetValue(2, out string cardHolderName))
                    card.CardHolderName = cardHolderName;

                if (data.Value.TryGetValue(3, out string cardNumber))
                    card.CardNumber = cardNumber.Substring(cardNumber.IndexOf('B') + 1, 18);

                _giftCards.Add(card);
            }

            BindingSource source = new BindingSource();
            source.DataSource = _giftCards.Select(data => new { data.SequenceNumber, data.CardNumber }).ToList();

            DGView.DataSource = source;
            DGView.Refresh();

        }

        /// <summary>
        /// Used to remove specific data on the Data Grid View
        /// </summary>
        /// <param name="barcode">Scanned Barcode</param>
        /// <returns></returns>
        private string RemoveSwiped(string barcode)
        {
            string message = "";
            try
            {
                var dataToRemove = _giftCards.FirstOrDefault(search => search.Barcode.Equals(barcode));
                _giftCards.Remove(dataToRemove);
                message = "Successful";

                BindingSource source = new BindingSource();
                source.DataSource = _giftCards.Select(data => new { data.SequenceNumber, data.CardHolderName }).ToList();

                DGView.DataSource = source;
                DGView.Refresh();
            }
            catch (Exception error)
            {
                message += error.Message;
            }
            return message;
        }

        /// <summary>
        /// GiftCard Model
        /// </summary>
        public struct GiftCard
        {
            public string SequenceNumber { get; set; }
            public string Barcode { get; set; }
            public string CardHolderName { get; set; }
            public string CardNumber { get; set; }
        }

        /// <summary>
        /// Excluding the Track 3 for validation
        /// </summary>
        /// <param name="trackData"></param>
        /// <returns></returns>
        private string ExcludeTrackThree(string trackData)
        {
            string track1 = trackData.Substring(0, trackData.IndexOf('?') + 1);
            string track2 = trackData.Substring(trackData.IndexOf(';'), trackData.LastIndexOf('?') - track1.Length + 1);
            string magstripeData = track1 + track2;
            return magstripeData;
        }
        
        /// <summary>
        /// Check if the data is already tagged or swiped
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        private bool CheckDuplicate(string barcode)
        {
            bool isDuplicate = _giftCards.Exists(data => data.Barcode == barcode);
            if (!isDuplicate)
                return true;
            else return false;
        }


        #endregion

        private void ChkExcludeSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExcludeSpecial.Checked) _excludeSpecial = true;
            else _excludeSpecial = false;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = CheckStoredData(worker, e);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtStatus.Text = "Checking Stored Data: " + e.ProgressPercentage.ToString() + "%";
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                TxtStatus.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                TxtStatus.Text = "Checking Complete! " + e.Result.ToString();
                LoadGridView(_storedData);
            }
        }
    }
}
