using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(
	typeof(XmHybrid.HybridWebView), 
	typeof(XmHybrid.iOS.HybridWebViewRenderer))]
namespace XmHybrid.iOS
{
	public class HybridWebViewRenderer : 
		ViewRenderer<XmHybrid.HybridWebView, WebKit.WKWebView>,  WebKit.IWKScriptMessageHandler

	{
		const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";

		public HybridWebViewRenderer()
		{
		}

		public void DidReceiveScriptMessage(
			WebKit.WKUserContentController userContentController, 
			WebKit.WKScriptMessage message)
		{
			Element.InvokeAction(message.Body.ToString());
		}
	}
}

