using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(
	typeof(XmHybrid.HybridWebView), 
	typeof(XmHybrid.Droid.HybridWebViewRenderer))]

namespace XmHybrid.Droid
{
	public class HybridWebViewRenderer:
		 ViewRenderer<XmHybrid.HybridWebView, Android.Webkit.WebView>
	{
		public HybridWebViewRenderer()
		{
		}
	}
}

