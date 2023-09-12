﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing;
using System.Diagnostics;
using System.Windows.Browser;

namespace Funq.Silverlight.Tests
{
	public partial class App : Application
	{
		public App()
		{
			this.Startup += this.OnApplicationStartup;
			this.Exit += this.OnApplicationExit;
			this.UnhandledException += this.OnApplicationUnhandledException;

			this.InitializeComponent();
		}

		private void OnApplicationStartup(object sender, StartupEventArgs e)
		{
			this.RootVisual = UnitTestSystem.CreateTestPage();
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
		}

		private void OnApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			// If the app is running outside of the debugger then report the exception using
			// the browser's exception mechanism. On IE this will display it a yellow alert 
			// icon in the status bar and Firefox will display a script error.
			if (!Debugger.IsAttached)
			{

				// NOTE: This will allow the application to continue running after an exception has been thrown
				// but not handled. 
				// For production applications this error handling should be replaced with something that will 
				// report the error to the website and stop the application.
				e.Handled = true;
				Deployment.Current.Dispatcher.BeginInvoke(
					(Action<ApplicationUnhandledExceptionEventArgs>)this.ReportErrorToDOM,
					e);
			}
		}

		private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
		{
			try
			{
				var errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace
					.Replace('"', '\'')
					.Replace("\r\n", @"\n");

				HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
			}
			catch (Exception)
			{
			}
		}
	}
}