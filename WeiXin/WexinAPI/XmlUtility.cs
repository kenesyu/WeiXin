using System;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace WeiXin.WexinAPI
{
    public class XmlUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }
    }
}