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

		const string JavaScriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
		void InjectJS(string script)
		{
			if (Control != null)
			{
				Control.LoadUrl(string.Format("javascript: {0}", script));
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				// WebKIT の初期化
				var webView = new Android.Webkit.WebView(Forms.Context);
				webView.Settings.JavaScriptEnabled = true;

				// ビューコントローラとして登録
				SetNativeControl(webView);
			}

			if (e.OldElement != null)
			{
				// ブリッジオブジェクトを削除
				Control.RemoveJavascriptInterface("jsBridge");
				var hybridWebView = e.OldElement as HybridWebView;

				// Actionをクリア
				hybridWebView.Cleanup();
			}

			if (e.NewElement != null)
			{
				// ブリッジオブジェクトを介してJavascriptからの呼び出しを受ける
				Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");

				// HTMLのロード
				Control.LoadUrl(string.Format("file:///android_asset/Content/{0}", Element.Uri));

				// Javascriptの挿入
				InjectJS(JavaScriptFunction);
			}
		}
	}
}

