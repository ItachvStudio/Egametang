using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarSample : MonoBehaviour
{

    public Button btn;

    //-------------------------------------------------------------------------
    private Texture m_texture;
    private string m_LogMessage;
    private NativeHandle m_Native;
    //-------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        m_Native = new NativeHandle();
        m_LogMessage = "";
        /*btn.onClick.AddListener(delegate {
            jumpSMS();

        });*/
    }

    public void jumpSMS()
    {
        SceneManager.LoadScene("Demo");
    }

    //-------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }
    //-------------------------------------------------------------------------
    void OnGUI()
    {
        if (GUI.Button(new Rect(300, 400, 600, 200), "设置用户头像"))
        {
            m_LogMessage = "Check Unity Button";
            m_Native.SettingAvaterFormMobile("Global", "OnAvaterCallBack", "image.png");
        }

        GUI.Label(new Rect(10, 100, 500, 500), m_LogMessage);

        if (null != m_texture)
        {
            GUI.DrawTexture(new Rect(100, 300, 300, 300), m_texture);
        }
    }
    //-------------------------------------------------------------------------
    void OnAvaterCallBack(string strResult)
    {
        m_LogMessage += " - " + strResult;

        if (strResult.Equals(ENUM_AVATAR_RESULT.eResult_Success.ToString()))
        {
            // 成功
            StartCoroutine(LoadTexture("image.png"));
        }
        else if (strResult.Equals(ENUM_AVATAR_RESULT.eResult_Cancel.ToString()))
        {
            // 取消
        }
        else if (strResult.Equals(ENUM_AVATAR_RESULT.eResult_Failed.ToString()))
        {
            // 失败
        }
    }
    //-------------------------------------------------------------------------
    IEnumerator LoadTexture(string name)
    {
        string path = "file://" + Application.persistentDataPath + "/" + name;
        using (WWW www = new WWW(path))
        {
            yield return www;

            if (www.error != null)
            {

            }
            else
            {
                if (www.isDone)
                {
                    //将图片赋予卡牌项
                    m_texture = www.texture;
                }
            }
        };
    }
    //-------------------------------------------------------------------------
}





























































