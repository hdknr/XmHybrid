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
- Cleanup でactionをnullにリセット

### 2. HybridWebViewの利用

- ContentPage.Content として、 XmHybrid をXAMLに追加
- Javascriptから呼ばれるメソッドを匿名関数で追加。(ダイアログを出す)


### 3. カスタムビュー

index.html

iOS:

- iOS/Assets/Content/index.html にBundleResourceでHTMLを追加


		scehme は httpではなく https にすること

Android:

- Droid/Assets/Content/index.html に AndroidAssetでHTMLを追加

### 4. iOSでのカスタムレンダラ-

- "iOS"プロジェクト > 追加 > 新しいファイルを追加 > 空のクラス : HybridWebViewRenderer
- HybridWebViewRenderer をカスタムレンダラ化
- invokeCSharpActionを定義
- OnElementChanged でカスタムレンダラの処理を実装する


### 5. Androidでのカスタムレンダーラー

#### レンダラー用意

- "Droid"プロジェクト > 追加 > 新しいファイルを追加 > 空のクラス : HybridWebViewRenderer
- HybridWebViewRenderer をカスタムレンダラ化(ExportRenderer, WebKitでビューレンダリング)

#### JSBridge

- Javascriptからの呼び出しのブリッジクラス: Droidプロジェクト > 追加 > 新しいファイルを追加 > 空のクラス : JSBridge
- Java.Lang.Objectを継承
- HybridWebViewRendererに対する[System.WeekReference](https://developer.xamarin.com/api/type/System.WeakReference%3CT%3E/) を作成(GC用)
