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

	}
}

