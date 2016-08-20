using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(
	typeof(XmHybrid.HybridWebView), 
	typeof(XmHybrid.iOS.HybridWebViewRenderer))]
namespace XmHybrid.iOS
{
	public class HybridWebViewRenderer : 
		ViewRenderer<XmHybrid.HybridWebView, WebKit.WKWebView>,  
		WebKit.IWKScriptMessageHandler
	{
		const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";

		public HybridWebViewRenderer()
		{
		}

		public void DidReceiveScriptMessage(
			WebKit.WKUserContentController userContentController, 
			WebKit.WKScriptMessage message)
		{
			Console.WriteLine("@@@@@@@@ " + message.Body.ToString());

			// XmHybrid.HybridWebView.InvokeAction (プラットフォーム共通ロジック) が呼ばれる
			Element.InvokeAction(message.Body.ToString());
		}

		WebKit.WKUserContentController userController;

		protected override void OnElementChanged(
			ElementChangedEventArgs<HybridWebView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				// コントローラーの初期化
				userController = new WebKit.WKUserContentController();

				// スクリプトオブジェクトを作成
				var script = new WebKit.WKUserScript(
						new Foundation.NSString(JavaScriptFunction), 
						WebKit.WKUserScriptInjectionTime.AtDocumentEnd, false);

				// WebKITにスクリプト追加
				userController.AddUserScript(script);

				// スクリプトのハンドラとして window.webkit.messageHandlers.invokeAction 追加
				userController.AddScriptMessageHandler(this, "invokeAction");

				// WebKITの設定
				var config = new WebKit.WKWebViewConfiguration { 
						UserContentController = userController };

				// WebKITを生成
				var webView = new WebKit.WKWebView(Frame, config);

				// WebKITをコントローラする
				SetNativeControl(webView);
			}

			if (e.OldElement != null)
			{	
				// クリア	
				userController.RemoveAllUserScripts();
				userController.RemoveScriptMessageHandler("invokeAction");
				var hybridWebView = e.OldElement as HybridWebView;
				hybridWebView.Cleanup();
			}

			if (e.NewElement != null)
			{
				// URLに対応するファイル
				string fileName =  System.IO.Path.Combine(
					Foundation.NSBundle.MainBundle.BundlePath, 
					string.Format("Assets/Content/{0}", Element.Uri));

				// WebKITにファイルをロードする
				Control.LoadRequest(
					new Foundation.NSUrlRequest(
						new Foundation.NSUrl(fileName, false)));
			}
		}
	}
}

