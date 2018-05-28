using System.Collections;
using System.Collections.Generic;
using ETModel;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using UnityEngine;
using UnityEngine.Purchasing;
/*using UnityEngine.Store;

namespace Model
{
    public class IOSPayment : MonoBehaviour, IStoreListener
    {

        public ILRuntime.Runtime.Enviorment.AppDomain AppDomain;
        private IStoreController m_Controller;

        private bool m_PurchaseInProgress = false;
        //private UnityChannelLoginHandler unityChannelLoginHandler; // Helper for interfacing with UnityChannel API

        void Start()
        {
            this.AppDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
            var module = StandardPurchasingModule.Instance();
            Log.Debug("Awake");
            // The FakeStore supports: no-ui (always succeeding), basic ui (purchase pass/fail), and
            // developer ui (initialization, purchase, failure code setting). These correspond to
            // the FakeStoreUIMode Enum values passed into StandardPurchasingModule.useFakeStoreUIMode.
            module.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;

            var builder = ConfigurationBuilder.Instance(module);

            // Set this to true to enable the Microsoft IAP simulator for local testing.
            builder.Configure<IMicrosoftConfiguration>().useMockBillingSystem = false;


            // CloudMoolah Configuration setings
            // All games must set the configuration. the configuration need to apply on the CloudMoolah Portal.
            // CloudMoolah APP Key
            builder.Configure<IMoolahConfiguration>().appKey = "d93f4564c41d463ed3d3cd207594ee1b";
            // CloudMoolah Hash Key
            builder.Configure<IMoolahConfiguration>().hashKey = "cc";
            // This enables the CloudMoolah test mode for local testing.
            // You would remove this, or set to CloudMoolahMode.Production, before building your release package.
            builder.Configure<IMoolahConfiguration>().SetMode(CloudMoolahMode.AlwaysSucceed);

            // UnityChannel, provides access to Xiaomi MiPay.
            // Products are required to be set in the IAP Catalog window.  The file "MiProductCatalog.prop"
            // is required to be generated into the project's
            // Assets/Plugins/Android/assets folder, based off the contents of the
            // IAP Catalog window, for MiPay.

            // Define our products.
            // Either use the Unity IAP Catalog, or manually use the ConfigurationBuilder.AddProduct API.
            // Use IDs from both the Unity IAP Catalog and hardcoded IDs via the ConfigurationBuilder.AddProduct API.

            // Use the products defined in the IAP Catalog GUI.
            // E.g. Menu: "Window" > "Unity IAP" > "IAP Catalog", then add products, then click "App Store Export".
            var catalog = ProductCatalog.LoadDefaultCatalog();

            foreach (var product in catalog.allProducts)
            {
                if (product.allStoreIDs.Count > 0)
                {
                    var ids = new IDs();
                    foreach (var storeID in product.allStoreIDs)
                    {
                        ids.Add(storeID.id, storeID.store);
                    }
                    builder.AddProduct(product.id, product.type, ids);
                }
                else
                {
                    builder.AddProduct(product.id, product.type);
                }
            }

            builder.Configure<IAmazonConfiguration>().WriteSandboxJSON(builder.products);
            System.Action initializeUnityIap = () =>
            {
                // Now we're ready to initialize Unity IAP.
                UnityPurchasing.Initialize(this, builder);
            };

            //if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                initializeUnityIap();
            }

        }

        // Use this for initialization
       /* void Start()
        {
            /*ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct("slots777_500coins", ProductType.NonConsumable, new IDs()
            {
                {
                    "slots777_500coins",
                    AppleAppStore.Name
                }
            });
            builder.AddProduct("com.ItachvStudio.slots777", ProductType.Consumable, new IDs()
            {
                {
                    "com.ItachvStudio.slots777",
                    AppleAppStore.Name
                }
            });
            //builder.AddProduct("tianhan01_30diamond", ProductType.NonConsumable, new IDs()
            //{
            //    {
            //        "tianhan01_30diamond",
            //        AppleAppStore.Name
            //    }
            //});
            //builder.AddProduct("tianhan01_98diamond", ProductType.Consumable, new IDs()
            //{
            //    {
            //        "tianhan01_98diamond",
            //        AppleAppStore.Name
            //    }
            //});
            UnityPurchasing.Initialize(this, builder);#2#
            //Debug.Log("PurchaseManager Start--开始内购初始化");
        }
#1#
        /// <summary>
        /// 当 Unity IAP 准备购买时调用
        /// </summary>
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            this.m_Controller = controller;
            Debug.Log("PurchaseManager OnInitialized--初始化成功");
        }

        /// <summary>
        /// 当Unity IAP遇到不可恢复的初始化错误时调用。
        /// 注意，如果互联网不可用，这将不会被调用
        /// 将尝试初始化，直到它可用为止。
        /// </summary>
        /// <param name="error"></param>
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log($"PurchaseManager OnInitializeFailed--初始化失败--{error}");
        }

        public void IOSPayResult(string transId, string order_note, string result)
        {
            //预先获得IMethod，可以减低每次调用查找方法耗用的时间
            IType type = AppDomain.LoadedTypes["Hotfix.UILobbyComponent"];
            object obj = ((ILType)type).Instantiate();
            //根据方法名称和参数个数获取方法
            IMethod method = type.GetMethod("IOSShopResult", 1);
            object[] param = new[] { transId, order_note, result };
            // 调用 Hotfix 中的支付成功函数
            AppDomain.Invoke(method, obj, param);
        }

        /// <summary>
        /// 当购买完成时调用,
        /// 可以在oninitialize()之后的任何时间调用。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
        {
            m_PurchaseInProgress = false;
            //string sre = e.purchasedProduct.transactionID
            Debug.Log($"PurchaseManager ProcessPurchase--购买成功{e.purchasedProduct.receipt}");
            IOSPayResult(e.purchasedProduct.transactionID, e.purchasedProduct.receipt, "1");
            return PurchaseProcessingResult.Complete;
        }

        /// <summary>
        /// 当购买失败时调用。
        /// </summary>
        public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
        {
            m_PurchaseInProgress = false;
            Debug.Log("PurchaseManager OnPurchaseFailed--购买失败");
            IOSPayResult("","", "0");
        }

        public void OnPurchaseClicked(string productID)
        {
            if (m_PurchaseInProgress == true)
            {
                Debug.Log("Please wait, purchase in progress");
                return;
            }

            if (m_Controller == null)
            {
                Debug.LogError("Purchasing is not initialized");
                return;
            }

            if (m_Controller.products.WithID(productID) == null)
            {
                Debug.LogError("No product has id " + productID);
                return;
            }
            Debug.Log("PurchaseManager OnPurchaseClicked--执行购买");
            m_PurchaseInProgress = true;
            m_Controller.InitiatePurchase(m_Controller.products.WithID(productID), "aDemoDeveloperPayload");
        }

        public void TestPay()
        {
            OnPurchaseClicked("slots777_500coins");
        }
    }
}*/