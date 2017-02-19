using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using VisualiserWpfLib;

namespace DebugVis
{
	public partial class ArrayVisualizerForm : Form
	{
		private ElementHost ctrlHost;

		private UIElement _myControl;

		public ArrayVisualizerForm(UIElement myControl)
		{
			_myControl = myControl;

			InitializeComponent();
		}

		private void ArrayVisualizerForm_Load(object sender, EventArgs e)
		{
			ctrlHost = new ElementHost();
			ctrlHost.Dock = DockStyle.Fill;
			panel1.Controls.Add(ctrlHost);
			ctrlHost.Child = _myControl;
		}
	}
}
