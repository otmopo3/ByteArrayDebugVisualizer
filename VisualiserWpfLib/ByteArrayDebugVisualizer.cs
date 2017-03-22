using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VisualiserWpfLib;

[assembly: System.Diagnostics.DebuggerVisualizer(
		typeof(DebugVis.ByteArrayDebugVisualizer),
		typeof(VisualizerObjectSource),
		Target = typeof(byte[]),
		Description = "Byte array visualizer")]

[assembly: System.Diagnostics.DebuggerVisualizer(
		typeof(DebugVis.ExceptionDebugVisualizer),
		typeof(VisualizerObjectSource),
		Target = typeof(Exception),
		Description = "Exception visualizer")]

namespace DebugVis
{

	public class ByteArrayDebugVisualizer : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			var userControl1 = new ByteArrayVisualizerControl(objectProvider);

			var arrayVisualizer = new ArrayVisualizerForm(userControl1);

			windowService.ShowDialog(arrayVisualizer);
		}

		public static void TestShowVisualizer(object objectToVisualize)
		{
			VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(ByteArrayDebugVisualizer));
			visualizerHost.ShowVisualizer();
		}
	}

	public class ExceptionDebugVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			var exception = (Exception) objectProvider.GetObject();

			var exceptionVisualizerForm = new ExceptionVisualizerForm();

			exceptionVisualizerForm.VisuzlizeException(exception);

			windowService.ShowDialog(exceptionVisualizerForm);
		}
	}
}
