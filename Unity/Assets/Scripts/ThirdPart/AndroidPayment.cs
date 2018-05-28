using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace Model
{
    public class AndroidPayment : MonoBehaviour
    {
        private AndroidJavaClass ajc = null;
        private AndroidJavaObject ajo = null;
        public ILRuntime.Runtime.Enviorment.AppDomain AppDomain;

        // Use this for initialization
        void Start()
        {
            this.AppDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
#if UNITY_EDITOR
#elif UNITY_ANDROID
            ajc = new AndroidJavaClass("com.tianhan.game.AvatarMainActivity");
            ajo = ajc.CallStatic<AndroidJavaObject>("currentActivity");
#endif
        }

        /// <summary>
        /// 初始化支付SDK
        /// </summary>
        public void InitPay(string appid)
        {
            ajo.Call("InitPay", appid, "Global", "PayResult");
            Debug.Log($"in InitPay:appid={appid}");
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="orderId">订单Id</param>
        public void Pay(string orderId, string appid)
        {
            ajo.Call("Pay", $"transid={orderId}&appid={appid}");
            Debug.Log($"in Pay:orderId={orderId},appid={appid}");
        }

        /// <summary>
        /// 支付回调
        /// </summary>
        /// <param name="msg">返回的消息-2：其他，-1：取消支付，0：支付失败，1：支付成功</param>
        public void PayResult(string msg)
        {
            //预先获得IMethod，可以减低每次调用查找方法耗用的时间
            IType type = AppDomain.LoadedTypes["Hotfix.UIShopComponent"];
            object obj = ((ILType)type).Instantiate();
            //根据方法名称和参数个数获取方法
            IMethod method = type.GetMethod("ShopResult", 1);
            // 调用 Hotfix 中的支付成功函数
            AppDomain.Invoke(method, obj, msg);
        }
    }
}
