using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4Image_WindowsFormApp_v2._0._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            BarCode(value);
            QRCode(value);
        }

        private void BarCode(string value)
        {
            T4Image.BarCode bc = new T4Image.BarCode(BarcodeStandard.TYPE.CODE128, value, true, 300, 150);
            pic_Barcode.Image = bc.Export().ImageFile;
        }

        private void QRCode(string value)
        {
            T4Image.QRCode qc = new T4Image.QRCode(value);
            pic_QR.Image = qc.Export().ImageFile;
        }
    }
}
