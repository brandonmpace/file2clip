/*
	This simple tool will copy files passed as arguments into the Windows clipboard.

	http://stackoverflow.com/questions/17189010/how-to-copy-cut-a-file-not-the-contents-to-the-clipboard-in-windows-on-the-com
*/
// TODO: comment these out one at a time to see if they are all really needed..
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("File2Clip")]
[assembly: AssemblyDescription("copies file to clipboard")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Brandon M. Pace, based on https://github.com/rostok/")]
[assembly: AssemblyProduct("File2Clip")]
[assembly: AssemblyCopyright("Copyright © 2016, 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

namespace File2Clip {
	public class App
	{
		[STAThread]
		static void Main(string[] args)
		{
			List<string> list = new List<string>();

			foreach (string s in args) {
				list.Add(s);
			}

			StringCollection paths = new StringCollection();
			foreach (string s in list) {
				paths.Add(System.IO.Path.IsPathRooted(s) ? s : System.IO.Directory.GetCurrentDirectory() + @"\" + s);
			}
			if (paths.Count>0) {
				 Clipboard.SetFileDropList(paths);
			}
		}
	}
}
