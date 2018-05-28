using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class DeviceID
{
#if UNITY_IPHONE
    [DllImport("__Internal")]
    private static extern string GetIphoneADID();
#endif

    public static string Get() {
#if UNITY_EDITOR
        return SystemInfo.deviceUniqueIdentifier;
#elif UNITY_ANDROID
        /*AndroidJavaClass unityA = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject curA = unityA.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass AndroidID = new AndroidJavaClass("com.yang.GetAID.AndroidID");*/
        //public void getImei(){

		AndroidJavaClass ajc = new AndroidJavaClass("com.tianhan.game.AvatarMainActivity");
		AndroidJavaObject ajo = ajc.CallStatic<AndroidJavaObject>("currentActivity");
		string imei = ajo.Call<string>("getImei");
		Debug.Log("imei:----------->"+imei);
	//}

        //string aID = AndroidID.CallStatic<string>("GetID",curA);
        return imei;
#elif UNITY_IPHONE
        string iID = GetIphoneADID();
        return iID;
#endif
        //return "isnot in mobilePhone";
    }
}
