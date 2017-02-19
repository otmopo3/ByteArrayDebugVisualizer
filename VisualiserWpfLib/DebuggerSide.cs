using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualiserWpfLib;

[assembly: System.Diagnostics.DebuggerVisualizer(
		typeof(DebugVis.DebuggerSide),
		typeof(VisualizerObjectSource),
		Target = typeof(byte[]),
		Description = "My First Visualizer")]

namespace DebugVis
{
	
    public class DebuggerSide : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			var userControl1 = new ByteArrayVisualizerControl(objectProvider);

			var arrayVisualizer = new ArrayVisualizerForm(userControl1);

			windowService.ShowDialog(arrayVisualizer);
		}

	    public static void TestShowVisualizer(object objectToVisualize)
		{
			VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DebuggerSide));
			visualizerHost.ShowVisualizer();
		}
	}
}
