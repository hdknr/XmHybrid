using System;
using Xamarin.Forms;


namespace XmHybrid 
{
	public class HybridWebView : View
	{
		public HybridWebView()
		{
		}

		public static readonly BindableProperty UriProperty = BindableProperty.Create(
   			propertyName: "Uri",
   			returnType: typeof(string),
   			declaringType: typeof(HybridWebView),
   			defaultValue: default(string));

		public string Uri
		{
			get { return (string)GetValue(UriProperty); }
			set { SetValue(UriProperty, value); }
		}

		Action<string> action;
		public void RegisterAction(Action<string> callback)
		{
			action = callback;
		}

		public void InvokeAction(string data)
		{
			if (action == null || data == null)
			{
				return;
			}
			action.Invoke(data);
		}

		public void Cleanup()
		{
			action = null;
		}
	}
}

