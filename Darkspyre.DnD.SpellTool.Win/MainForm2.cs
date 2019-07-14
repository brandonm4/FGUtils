
using Darkspyre.DnD.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darkspyre.DnD.SpellTool.Win
{
    public partial class MainForm2 : Form
    {
        public DataLibrary dataLibrary { get; set; } = new DataLibrary();
        public MainForm2()
        {
            InitializeComponent();
            
        }
    }
}
