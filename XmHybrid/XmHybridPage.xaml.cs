using Xamarin.Forms;

namespace XmHybrid
{
	public partial class XmHybridPage : ContentPage
	{
		public XmHybridPage()
		{
			InitializeComponent();

			this.hybridWebView.RegisterAction(
				data => DisplayAlert(
					"Alert", "こんにちは:" + data, "OK"));
		}
	}
}

