using ETModel;
using UnityEngine;
using Model;

public class WebLogic : MonoBehaviour
{
    private int bottom = 5;
    private int top = 5;

    /*public void OpenH5(string url, int topPoint, int bottomPoint)
    {
        Log.Debug($"--h5 url--{url}");
        GameObject webViewGameObject = GameObject.Find("WebView");
        if (webViewGameObject == null)
        {
            webViewGameObject = new GameObject("WebView");
        }
        this.bottom = bottomPoint;
        this.top = topPoint;
        UniWebView webView = webViewGameObject.AddComponent<UniWebView>();
        webView.OnLoadComplete += OnLoadComplete;
        webView.InsetsForScreenOreitation += InsetsForScreenOreitation;
        webView.toolBarShow = true;
        webView.url = url;
        webView.Load();
    }

    void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            webView.Show();
        }
        else
        {
            Debug.LogError("Something wrong in webview loading: " + errorMessage);
        }
    }
    UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation)
    {

        if (orientation == UniWebViewOrientation.Portrait)
        {
            return new UniWebViewEdgeInsets(top, 5, bottom, 5);
        }
        else
        {
            return new UniWebViewEdgeInsets(top, 5, bottom, 5);
        }
    }
*/
    
}
