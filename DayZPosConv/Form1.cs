using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DayZPosConv.Converting;

namespace DayZPosConv
{
    public partial class Form1 : Form
    {
        private static string _welcomeText;
        private static IPosReader[] _readers;
        private static IPosConverter[] _converters;

        public Form1() => InitializeComponent();

        private void DoConvert(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            if (!(comboBox1.SelectedItem is IPosReader reader))
            {
                if(!GuessReaderType() || !(comboBox1.SelectedItem is IPosReader))
                    return;
                reader = (IPosReader) comboBox1.SelectedItem;
            }
            var converter = (IPosConverter) comboBox2.SelectedItem;
            textBox2.Text = string.Empty;
            try
            {
                if(converter.IsBatchConverter())
                    textBox2.Text = converter.Convert(reader.Read(textBox1.Text));
                else
                {
                    var sb = new StringBuilder();
                    foreach (var o in reader.Read(textBox1.Text))
                        sb.AppendLine(converter.Convert(o));
                    textBox2.Text = sb.ToString();
                }
            }
            catch (Exception exc)
            {
                textBox2.Text = _welcomeText;
                throw new Exception("Failed to convert!\nMake sure you've selected the correct source format!", exc);
            }
        }

        private bool GuessReaderType()
        {
            foreach (var posReader in _readers)
            {
                if (posReader.IsSourceSuitable(textBox1.Text))
                {
                    SelectReaderOfType(posReader.GetType());
                    return true;
                }
            }
            MessageBox.Show("Can't automatically guess the input data format.\nSelect it manually from the list!", "Fail",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void SelectReaderOfType(Type readerType)
        {
            for (var i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].GetType() == readerType)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _welcomeText = textBox2.Text;
            Text = $"DayZPosConv v{Application.ProductVersion} © Def";
            var allTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsInterface).ToArray();
            _readers = allTypes.Where(t => typeof(IPosReader).IsAssignableFrom(t)).Select(Activator.CreateInstance).Cast<IPosReader>().ToArray();
            _converters = allTypes.Where(t => typeof(IPosConverter).IsAssignableFrom(t)).Select(Activator.CreateInstance).Cast<IPosConverter>().ToArray();
            comboBox1.Items.Add("Auto");
            foreach (var posReader in _readers) 
                comboBox1.Items.Add(posReader);
            foreach (var posConverter in _converters) 
                comboBox2.Items.Add(posConverter);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void CopyFromSource(object sender, EventArgs e) => Clipboard.SetData(DataFormats.Text, textBox1.Text);
        
        private void CopyFromOutput(object sender, EventArgs e) => Clipboard.SetData(DataFormats.Text, textBox2.Text);
        
        private void PasteToSource(object sender, EventArgs e) => textBox1.Text = Clipboard.GetText(TextDataFormat.UnicodeText);

        private void btnImport_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { CheckFileExists = true };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            textBox1.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog{ CheckPathExists = true, RestoreDirectory = true, OverwritePrompt = true };
            if(sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllText(sfd.FileName, textBox2.Text, Encoding.UTF8);
        }
    }
}
