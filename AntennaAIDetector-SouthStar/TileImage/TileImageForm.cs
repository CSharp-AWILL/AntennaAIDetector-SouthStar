using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaAIDetector_SouthStar.TileImage
{
    public partial class TileImageForm : Form
    {
        private TileImage _tileImage = null;
        public TileImageForm(TileImage tileImage)
        {
            _tileImage = tileImage;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tileImage.Run();
        }
    }
}
