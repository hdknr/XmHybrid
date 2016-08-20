using System;

namespace XmHybrid.Droid
{
	public class JSBridge: Java.Lang.Object
	{
		protected WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;

		public JSBridge(HybridWebViewRenderer hybridRenderer)
		{
			hybridWebViewRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
		}

		[Android.Webkit.JavascriptInterface]
		[Java.Interop.Export("invokeAction")]
		public void InvokeAction(string data)
		{
			HybridWebViewRenderer hybridRenderer;

			if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
			{
				// 実際のHybridWebViewRendererに対して InvokeActionをコールする
				hybridRenderer.Element.InvokeAction(data);
			}
		}
	}
}