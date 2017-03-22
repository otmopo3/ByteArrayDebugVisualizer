using System;
using System.Windows.Forms;

namespace VisualiserWpfLib
{
	public partial class ExceptionVisualizerForm : Form
	{
		public ExceptionVisualizerForm()
		{
			InitializeComponent();
		}

		public void VisuzlizeException(Exception exeption)
		{
			var text = exeption.GetType() + Environment.NewLine;

			text += exeption.Message + Environment.NewLine;

			text += exeption.StackTrace;

			label1.Text = text;
		}
	}
}
