﻿using System;
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
	}
}

