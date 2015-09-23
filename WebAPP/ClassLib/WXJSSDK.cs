﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Domain;
using System.Configuration;
using WeiXin.WexinAPI;

/// <summary>
/// WXJSSDK 的摘要说明
/// </summary>
public class WXJSSDK
{
    private string appId;
    private string appSecret;
    //private DataTable DT;

    public WXJSSDK(string appId, string appSecret)
    {
        this.appId = appId;
        this.appSecret = appSecret;
    }

    //得到数据包，返回使用页面  
    public System.Collections.Hashtable getSignPackage()
    {
        string jsapiTicket = getJsApiTicket();
        string url = HttpContext.Current.Request.Url.ToString();
        string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
        string nonceStr = createNonceStr();


        // 这里参数的顺序要按照 key 值 ASCII 码升序排序  
        string rawstring = "jsapi_ticket=" + jsapiTicket + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + url + "";


        string signature = SHA1_Hash(rawstring);


        System.Collections.Hashtable signPackage = new System.Collections.Hashtable();
        signPackage.Add("appId", appId);
        signPackage.Add("nonceStr", nonceStr);
        signPackage.Add("timestamp", timestamp);
        signPackage.Add("url", url);
        signPackage.Add("signature", signature);
        signPackage.Add("rawString", rawstring);


        return signPackage;
    }


    //创建随机字符串  
    private string createNonceStr()
    {
        int length = 16;
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string str = "";
        Random rad = new Random();
        for (int i = 0; i < length; i++)
        {
            str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
        }
        return str;
    }


    //得到ticket 如果文件里时间 超时则重新获取  
    private string getJsApiTicket()
    {

        //string accessToken = API_Token.AccessToken;
        //IMpClient mpClient = new MpClient();
        //AccessTokenGetRequest request = new AccessTokenGetRequest()
        //{
        //    AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
        //};
        //AccessTokenGetResponse response = mpClient.Execute(request);
        //string accessToken = response.AccessToken.AccessToken;// getAccessToken();//获取系统的全局token 
        return API_JSAPITicker.JSAPITicket;
        //return accessToken;
    }


    ////得到accesstoken 如果文件里时间 超时则重新获取  
    //private string getAccessToken()
    //{
    //    // access_token 应该全局存储与更新，以下代码以写入到文件中做示例
    //    string access_token = "";
    //    string path = HttpContext.Current.Server.MapPath(@"/weixin/access_token.json");
    //    FileStream file = new FileStream(path, FileMode.Open);
    //    var serializer = new DataContractJsonSerializer(typeof(AccToken));
    //    AccToken readJSTicket = (AccToken)serializer.ReadObject(file);
    //    file.Close();
    //    if (readJSTicket.expires_in < ConvertDateTimeInt(DateTime.Now))
    //    {
    //        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appId + "&secret=" + appSecret + "";

    //        AccToken iden = Desrialize<AccToken>(new AccToken(), httpGet(url));

    //        access_token = iden.access_token;
    //        if (access_token != "")
    //        {
    //            iden.expires_in = ConvertDateTimeInt(DateTime.Now) + 7000;
    //            iden.access_token = access_token;

    //            string json = Serialize<AccToken>(iden);
    //            StreamWriterMetod(json, path);
    //        }
    //    }
    //    else
    //    {
    //        access_token = readJSTicket.access_token;
    //    }
    //    return access_token;
    //}


    //发起一个http请球，返回值  
    private string httpGet(string url)
    {
        try
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
            string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              

            return pageHtml;
        }


        catch (WebException webEx)
        {
            Console.WriteLine(webEx.Message.ToString());
            return null;
        }
    }


    //SHA1哈希加密算法  
    public string SHA1_Hash(string str_sha1_in)
    {
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
        byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
        string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
        str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
        return str_sha1_out;
    }


    /// <summary>  
    /// StreamWriter写入文件方法  
    /// </summary>  
    private void StreamWriterMetod(string str, string patch)
    {
        try
        {
            FileStream fsFile = new FileStream(patch, FileMode.OpenOrCreate);
            StreamWriter swWriter = new StreamWriter(fsFile);
            swWriter.WriteLine(str);
            swWriter.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>  
    /// 将c# DateTime时间格式转换为Unix时间戳格式  
    /// </summary>  
    /// <param name="time">时间</param>  
    /// <returns>double</returns>  
    public int ConvertDateTimeInt(System.DateTime time)
    {
        int intResult = 0;
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        intResult = Convert.ToInt32((time - startTime).TotalSeconds);
        return intResult;
    }
}
//创建Json序列化 及反序列化类目  
#region
//创建JSon类 保存文件 jsapi_ticket.json  
public class JSTicket
{

public string jsapi_ticket { get; set; }

public double expire_time { get; set; }
}
//创建 JSon类 保存文件 access_token.json  
    
public class AccToken
{

public string access_token { get; set; }

public double expires_in { get; set; }
}
    
//创建从微信返回结果的一个类 用于获取ticket  
public class Jsapi
{

public int errcode { get; set; }

public string errmsg { get; set; }

public string ticket { get; set; }

public string expires_in { get; set; }
}
#endregion 