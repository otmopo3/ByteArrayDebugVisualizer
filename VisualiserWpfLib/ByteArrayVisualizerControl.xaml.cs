using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace VisualiserWpfLib
{
	/// <summary>
	/// Interaction logic for ByteArrayVisualizerControl.xaml
	/// </summary>
	public partial class ByteArrayVisualizerControl
	{
		private readonly IVisualizerObjectProvider _objectProvider;

		public ByteArrayVisualizerControl()
		{
			InitializeComponent();
		}

		public ByteArrayVisualizerControl(IVisualizerObjectProvider objectProvider) : this()
		{
			_objectProvider = objectProvider;

			var prevCtx = SynchronizationContext.Current;

			var syncCtx = new DispatcherSynchronizationContext();

			SynchronizationContext.SetSynchronizationContext(syncCtx);

			try
			{
				FillText();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(prevCtx);
			}
		}

		[STAThread]
		private async void FillText()
		{
			var byteArrayObj = (byte[])_objectProvider.GetObject();

			var text = await GetByteStringFromBytes(byteArrayObj);

			//ByteArrayTextBlock.Text = text;

			//Utf8BytesTextBlock.Text = await GetUtf8StringFromBytes(byteArrayObj);

			HexaEditor.Stream = new MemoryStream(byteArrayObj);
		}

		private static Task<string> GetByteStringFromBytes(byte[] bytes)
		{
			var task = new Task<string>(() =>
			{
				return BitConverter.ToString(bytes);
			}, TaskCreationOptions.LongRunning);


			task.Start();

			return task;
		}

		private static Task<string> GetUtf8StringFromBytes(byte[] bytes)
		{
			var task = new Task<string>(() =>
			{
				return Encoding.UTF8.GetString(bytes);

			}, TaskCreationOptions.LongRunning);

			task.Start();

			return task;
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			//var bytesStrings = ByteArrayTextBlock.Text.Split('-');

			//var bytes = new byte[bytesStrings.Length];

			//for (int i = 0; i < bytesStrings.Length; i++)
			//{
			//	var bytesString = bytesStrings[i];

			//	var curByte = byte.Parse(bytesString, NumberStyles.HexNumber);
			//	bytes[i] = curByte;
			//}

			//if (_objectProvider.IsObjectReplaceable)
			//{
			//	_objectProvider.ReplaceObject(bytes);
			//	_objectProvider.TransferObject(bytes);
			//}
		}
	}
}
