using System.Collections;
using System.Collections.Generic;
using ETModel;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using UnityEngine;
using UnityEngine.Networking;
using Model;

public class AvatarHelper : MonoBehaviour
{

    private string m_LogMessage;
    private NativeHandle m_Native;
    //-------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        m_Native = new NativeHandle();
        m_LogMessage = "";
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GetAvatarFromAlbumn()
    {
        m_Native.SettingAvaterFormMobile("Global", "OnAvaterCallBack", "image.png");
    }

    /// <summary>
    /// 从平台上获取照片成功之后的回调
    /// </summary>
    /// <param name="strResult"></param>
    void OnAvaterCallBack(string strResult)
    {
        m_LogMessage += " - " + strResult;

        if (strResult.Equals(ENUM_AVATAR_RESULT.eResult_Success.ToString()))
        {
            // 成功
            //Game.EventSystem.Run(EventIdType.GetPhotoSuccess, strResult);
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

    /// <summary>
    /// 上传头像
    /// </summary>
    /*private async void UploadImg(S2CPlayerInfo playerInfo)
    {
        TimerComponent timerComponent = Game.Scene.GetComponent<TimerComponent>();
        string url = $"{playerInfo.resource_url}uploadImg";
        WWWForm form = new WWWForm();
        form.AddField("uid", playerInfo.uid);
        form.AddField("server_id", playerInfo.server_id);
        form.AddField("region_id", playerInfo.domain_id);
        Texture2D texture2D = this.riUpImg.texture as Texture2D;
        form.AddBinaryData("file", texture2D.EncodeToPNG());

        UnityWebRequest request = UnityWebRequest.Post(url, form);
        request.Send();

        while (!request.isDone)
        {
            await timerComponent.WaitAsync(50);
        }

        string results = request.downloadHandler.text;

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            UploadImg uploadImg = MongoHelper.FromJson<UploadImg>(results);
            Debug.Log(uploadImg.errno);
        }
    }*/
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
                    Texture2D m_texture = www.texture;
                    
                }
            }
        };
    }

    public void UploadTexture(Texture texture)
    {
        
    }
}
