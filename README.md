## プロジェクト作成

- "Multiplatform" > "Xamarin.Forms" > "Forms App"
- "App Name" : "XmHybrid", "Organization Identifier" : "jp.lafoglia.wildcard"

## HybridWebView サンプルを参考

- [Implementing a HybridWebView](https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/hybridwebview/)
- [HybridWebView Custom Renderer](https://developer.xamarin.com/samples/xamarin-forms/customrenderers/hybridwebview/)
- [github](https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/HybridWebView)

### 1. HybridWebView 作成

- "XmHybrid" PCLプロジェクト > 追加 > 新しいファイルを追加 > 空のクラス : HybridWebView
- Xamarin.Forms.View からサブクラス化
- UriProperty: [BindableProperty](https://developer.xamarin.com/api/type/Xamarin.Forms.BindableProperty/) を追加
- UriPropertyでのやり取りをUriで受ける
- Javascriptの関数の処理をActionとしてRegisterActionで設定可能にする
- 登録したActionを引数として data 文字列を渡してInvokeAction経由でJavascriptから呼び出す

### 2. HybridWebViewの利用

- ContentPage.Content として、 XmHybrid をXAMLに追加
- Javascriptから呼ばれるメソッドを匿名関数で追加。(ダイアログを出す)
