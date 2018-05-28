using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;


public class BuglyHelper : MonoBehaviour
{

    // Use this for initialization
    /*void Start()
    {
        BuglyAgent.PrintLog(LogSeverity.LogInfo, "bugly Start()");

        //SetupGUIStyle();

        InitBuglySDK();

        BuglyAgent.PrintLog(LogSeverity.LogWarning, "Init bugly sdk done");
        // set tag
#if UNITY_ANDROID
        BuglyAgent.SetScene(3450);
#else
        BuglyAgent.SetScene (3261);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    private const string BuglyAppIDForiOS = "e671484f58";
    //private const string BuglyAppIDForAndroid = "900022932";
    private const string BuglyAppIDForAndroid = "77bbcaca53";

    void InitBuglySDK()
    {

        // TODO NOT Required. Set the crash reporter type and log to report
        // BuglyAgent.ConfigCrashReporter (1, 2);

        // TODO NOT Required. Enable debug log print, please set false for release version
#if DEBUG
        BuglyAgent.ConfigDebugMode(true);
#endif
        BuglyAgent.ConfigDebugMode(true);
        // TODO NOT Required. Register log callback with 'BuglyAgent.LogCallbackDelegate' to replace the 'Application.RegisterLogCallback(Application.LogCallback)'
        // BuglyAgent.RegisterLogCallback (CallbackDelegate.Instance.OnApplicationLogCallbackHandler);

        // BuglyAgent.ConfigDefault ("Bugly", null, "ronnie", 0);

#if UNITY_IPHONE || UNITY_IOS
        BuglyAgent.InitWithAppId (BuglyAppIDForiOS);
#elif UNITY_ANDROID
        BuglyAgent.InitWithAppId(BuglyAppIDForAndroid);
#endif

        // TODO Required. If you do not need call 'InitWithAppId(string)' to initialize the sdk(may be you has initialized the sdk it associated Android or iOS project),
        // please call this method to enable c# exception handler only.
        BuglyAgent.EnableExceptionHandler();

        // TODO NOT Required. If you need to report extra data with exception, you can set the extra handler
        //        BuglyAgent.SetLogCallbackExtrasHandler (MyLogCallbackExtrasHandler);

        BuglyAgent.PrintLog(LogSeverity.LogInfo, "Init the bugly sdk");
    }*/
}
