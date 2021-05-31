﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace JaosnGameNet
{
    public class Login : MonoBehaviour
    {
        [SerializeField] Text SendRequest;
        string url = "http://localhost/UnityGame_PHP/Login.php";
        [SerializeField] Button SendLogin;
        [SerializeField] Button RegeistLogin;
        [SerializeField] InputField InputUserName, InputPassword;
        // Start is called before the first frame update
        void Start()
        {
            SendLogin.onClick.AddListener(() => StartCoroutine(CorLogin(InputUserName.text, InputPassword.text)));
            RegeistLogin.onClick.AddListener(() => SceneManager.LoadScene("Regist"));


        }
        /// <summary>
        /// 連線
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        IEnumerator CorLogin(string UserName, string Password)
        {

            WWWForm form = new WWWForm();
            form.AddField("loginUser", UserName);
            form.AddField("loginPassword", Password);
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();
                if (www.isHttpError || www.isNetworkError)//沒連上網路
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("上傳表單成功");
                    //取得連線資訊
                    SendRequest.text=www.downloadHandler.text;
                    ///連線後做什麼
                }

            }

        }
        

    }
}