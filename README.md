this project fork from Microsoft [WebView2Samples](https://github.com/MicrosoftEdge/WebView2Samples), plus large PDF file size handling

# Read Pdf in WinForm by WebView2 

Only amended the winForms project 

which located in GettingStartedGuides/WinForms_GettingStarted

Tested 7MB, 15MB, 26MB pdf, all are successfully read and view in webView2

# Main changes

add requestedFilter on URL `https://example.com` or `https://template/*` in my code

in the captured event, custom generate your webpage with the big pdf in base64 in HTML

fire your webView2 always on the `https://example.com` or `https://template/*`<br>
e.g `webView.Source = new Uri($@"https://template/");`

## Debug
Which I didn't implement

Suggested to append id in URL e.g https://example.com?file=fileId for easy to trace, logging for debug and/or HTTP redirections purpose

## Futher

the user requirements may concern save as, print by right click or tool bar on webView2

Please read HiddenPdfToolbarItems Property

https://learn.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2settings.hiddenpdftoolbaritems?view=webview2-dotnet-1.0.2903.40


capture the mouse and deactivate “right click”

https://stackoverflow.com/questions/18398058/disable-right-click-menu-on-webview

##

```
void AddResourceFilterCmdExecuted(object target, ExecutedRoutedEventArgs e)
{
    // Add a filter to intercept requests made to https://example.com
    // Then replace the response with a large html string.
    webView.CoreWebView2.AddWebResourceRequestedFilter("https://example.com", CoreWebView2WebResourceContext.All);
    webView.CoreWebView2.WebResourceRequested += WebView_OnWebResourceRequested;
}

void WebView_OnWebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
{
    // Intercept the web resource request; set the response as the large html content string.
    string responseDataString = "<html><head><title>Hello World</title></head><body><h1>Large content</h1></body></html>";
    UTF8Encoding utfEncoding = new UTF8Encoding();
    byte[] responseData = utfEncoding.GetBytes(
        responseDataString);
    ...
    e.Response = webResourceResponse;
}
```

# Reference

[NavigateToString with a very large string shows error "Value does not fall within the expected range"](https://github.com/MicrosoftEdge/WebView2Feedback/issues/1355)

[Introduction to Microsoft Edge WebView2 - Microsoft Edge Developer documentation | Microsoft Learn](https://learn.microsoft.com/zh-hk/microsoft-edge/webview2/?form=MA13LH#sequence-of-samples-to-install-and-run)

[Using local content in WebView2 apps - Loading local content by handling the WebResourceRequested event | Microsoft Learn.](https://learn.microsoft.com/en-us/microsoft-edge/webview2/concepts/working-with-local-content?tabs=dotnetcsharp#loading-local-content-by-handling-the-webresourcerequested-event)

[Getting Started tutorials](https://learn.microsoft.com/en-us/microsoft-edge/webview2/get-started/get-started)
