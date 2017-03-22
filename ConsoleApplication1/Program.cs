using System;
using System.Text;
using DebugVis;

namespace ConsoleApplication1
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			byte[] myArray = Encoding.UTF8.GetBytes("Привет? kag dela?");
			ByteArrayDebugVisualizer.TestShowVisualizer(myArray);
		}
	}
}
