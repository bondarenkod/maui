using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Maui.Hosting;
using UIKit;

namespace Microsoft.Maui
{
	public class MauiUIApplicationDelegate<TApplication> : UIApplicationDelegate, IUIApplicationDelegate where TApplication : MauiApp
	{
		public override UIWindow? Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			if (!(Activator.CreateInstance(typeof(TApplication)) is TApplication app))
				throw new InvalidOperationException($"We weren't able to create the App {typeof(TApplication)}");

			var host = app.CreateBuilder().ConfigureServices(ConfigureNativeServices).Build(app);

			if (MauiApp.Current == null || MauiApp.Current.Services == null)
				throw new InvalidOperationException("App was not intialized");


			var mauiContext = new MauiContext(MauiApp.Current.Services);
			var window = app.CreateWindow(new ActivationState(mauiContext));

			window.MauiContext = mauiContext;

			//Hack for now we set this on the App Static but this should be on IFrameworkElement
			App.Current.SetHandlerContext(window.MauiContext);

			var content = (window.Page as IView) ?? window.Page.View;

			Window = new UIWindow
			{
				RootViewController = new UIViewController
				{
					View = content.ToNative(window.MauiContext)
				}
			};

			Window.MakeKeyAndVisible();

			return true;
		}

		void ConfigureNativeServices(HostBuilderContext ctx, IServiceCollection services)
		{

		}
	}
}
