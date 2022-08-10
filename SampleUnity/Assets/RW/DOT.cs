using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using UnityEngine;
using System.Linq;
using DOT_Model;
#if UNITY_IOS && !UNITY_EDITOR
using DOTIosBridgeModel;
#endif

public class DOT {

#if UNITY_ANDROID && !UNITY_EDITOR // for android 

    private static AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    private static AndroidJavaObject context = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
    private static AndroidJavaClass unityHelperClass = new AndroidJavaClass("com.sdk.wisetracker.unity.UnityHelper");
    private static AndroidJavaObject unityHelperInstance = unityHelperClass.CallStatic<AndroidJavaObject>("getInstance");

 

    public static void setPushReceiver(string campaignId, string pushID)
    {
        Debug.Log("set push receiver");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("setPushReceiver", campaignId, pushID);
        }
    }

    public static void setPushClick(string pushId, string campaignId, string pushTitle, string pushBody, long expireTime)
    {
        Debug.Log("set push click");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("setPushClick", pushId, campaignId, pushTitle, pushBody, expireTime);
        }
    }

    public static void setPushToken(string pushToken)
    {
        Debug.Log("set push token");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("setPushToken", pushToken);
        }
    }

    public static void setDeepLink(string url)
    {
        Debug.Log("set deep link");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("setDeepLink", url);
        }
    }

    public static void setUser(User user)
    {
        Debug.Log("set user data");
        if (unityHelperInstance != null)
        {
            string userString = userObjectToDictionary(user);
            unityHelperInstance.Call("setUser", userString);
        }
    }

    public static string userObjectToDictionary(User user)
    {
        //if (user == null)
        //{
        //    return null;
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("isLogin", user.getIsLogin().ToString() ?? string.Empty);
        dictionary.Add("mbr", user.getMember() ?? string.Empty);
        dictionary.Add("mbl", user.getMemberGrade() ?? string.Empty);
        dictionary.Add("mbid", user.getMemberId() ?? string.Empty);
        dictionary.Add("sx", user.getGender() ?? string.Empty);
        dictionary.Add("ag", user.getAge() ?? string.Empty);
        dictionary.Add("ut1", user.getAttr1() ?? string.Empty);
        dictionary.Add("ut2", user.getAttr2() ?? string.Empty);
        dictionary.Add("ut3", user.getAttr3() ?? string.Empty);
        dictionary.Add("ut4", user.getAttr4() ?? string.Empty);
        dictionary.Add("ut5", user.getAttr5() ?? string.Empty);
        string json = Serializer.Serialize(dictionary);
        Debug.Log("user json string : " + json);
        return json;
    }

    public static void setUserLogout()
    {
        Debug.Log("set user data");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("setUserLogout");
        }
    }

    public static void logScreen(Dictionary<string, object> dictionary) 
    {
        Debug.Log("log screen event");
        if (unityHelperInstance != null)
        {
            string json = Serializer.Serialize(dictionary);
            unityHelperInstance.Call("logScreen", json);
        }
    }

    public static void onStartPage()
    {
        if (unityHelperInstance != null)
        {
            Debug.Log("set start page");
            unityHelperInstance.Call("onStartPage");
        }
    }

    public static void onStopPage()
    {
        if (unityHelperInstance != null)
        {
            Debug.Log("set stop page");
            unityHelperInstance.Call("onStopPage");
        }
    }
  

    public static void logPurchase(Dictionary<string, object> dictionary) 
    {
        Debug.Log("log purchase event");
        if (unityHelperInstance != null)
        {
            string json = Serializer.Serialize(dictionary);
            unityHelperInstance.Call("logPurchase", json);
        }
    }

    public static void logEvent(Dictionary<string, object> dictionary) 
    {
        Debug.Log("log event event");
        if (unityHelperInstance != null)
        {
            string json = Serializer.Serialize(dictionary);
            unityHelperInstance.Call("logEvent", json);
        }
    }

    public static void logClick(Dictionary<string, object> dictionary) 
    {
        Debug.Log("log screen event");
        if (unityHelperInstance != null)
        {
            string json = Serializer.Serialize(dictionary);
            unityHelperInstance.Call("logClick", json);
        }
    }

    

    sealed class Serializer
    {
        StringBuilder builder;

        Serializer()
        {
            builder = new StringBuilder();
        }

        public static string Serialize(object obj)
        {
            var instance = new Serializer();

            instance.SerializeValue(obj);

            return instance.builder.ToString();
        }

        void SerializeValue(object value)
        {
            IList asList;
            IDictionary asDict;
            string asStr;

            if (value == null)
            {
                builder.Append("null");
            }
            else if ((asStr = value as string) != null)
            {
                SerializeString(asStr);
            }
            else if (value is bool)
            {
                builder.Append((bool)value ? "true" : "false");
            }
            else if ((asList = value as IList) != null)
            {
                SerializeArray(asList);
            }
            else if ((asDict = value as IDictionary) != null)
            {
                SerializeObject(asDict);
            }
            else if (value is char)
            {
                SerializeString(new string((char)value, 1));
            }
            else
            {
                SerializeOther(value);
            }
        }

        void SerializeObject(IDictionary obj)
        {
            bool first = true;

            builder.Append('{');

            foreach (object e in obj.Keys)
            {
                if (!first)
                {
                    builder.Append(',');
                }

                SerializeString(e.ToString());
                builder.Append(':');

                SerializeValue(obj[e]);

                first = false;
            }

            builder.Append('}');
        }

        void SerializeArray(IList anArray)
        {
            builder.Append('[');

            bool first = true;

            foreach (object obj in anArray)
            {
                if (!first)
                {
                    builder.Append(',');
                }

                SerializeValue(obj);

                first = false;
            }

            builder.Append(']');
        }

        void SerializeString(string str)
        {
            builder.Append('\"');

            char[] charArray = str.ToCharArray();
            foreach (var c in charArray)
            {
                switch (c)
                {
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '\b':
                        builder.Append("\\b");
                        break;
                    case '\f':
                        builder.Append("\\f");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        int codepoint = Convert.ToInt32(c);
                        if ((codepoint >= 32) && (codepoint <= 126))
                        {
                            builder.Append(c);
                        }
                        else
                        {
                            builder.Append("\\u");
                            builder.Append(codepoint.ToString("x4"));
                        }
                        break;
                }
            }

            builder.Append('\"');
        }

        void SerializeOther(object value)
        {
            // NOTE: decimals lose precision during serialization.
            // They always have, I'm just letting you know.
            // Previously floats and doubles lost precision too.
            if (value is float)
            {
                builder.Append(((float)value).ToString("R"));
            }
            else if (value is int
              || value is uint
              || value is long
              || value is sbyte
              || value is byte
              || value is short
              || value is ushort
              || value is ulong)
            {
                builder.Append(value);
            }
            else if (value is double
              || value is decimal)
            {
                builder.Append(Convert.ToDouble(value).ToString("R"));
            }
            else
            {
                SerializeString(value.ToString());
            }
        }
    }

//#else
#elif UNITY_IOS && !UNITY_EDITOR // for ios
    public string[] optionalAmountKey = null;
    public double[] optionalAmountValue = null;

    DOT()
    {
        this.optionalAmountKey = null;
        this.optionalAmountValue = null;
    } 


    /**
     * Function Group 1
     ***/
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetPushReceiver(string campaignId, string pushID);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetPushClick(string pushId, string campaignId, string pushTitle, string pushBody, long expireTime);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetDeepLink(string url);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetPushToken(string pushToken);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetUser(UserIos user);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetUserLogout();

    

    public static void setPushReceiver(string campaignId, string pushID){
        CallSetPushReceiver(campaignId, pushID);
    }
    public static void setPushClick(string pushId, string campaignId, string pushTitle, string pushBody, long expireTime){
        CallSetPushClick( pushId,  campaignId,  pushTitle,  pushBody,  expireTime);
    }
    public static void setDeepLink(string url){
        CallSetDeepLink( url );
    }
    public static void setPushToken(string pushToken){
        CallSetPushToken( pushToken );
    } 
    public static void setUser(User user)
    {
        UserIos userIos = new UserIos(user);

        CallSetUser(userIos);
    } 
    public static void setUserLogout()
    { 
        CallSetUserLogout();
    }  
    

    /**
     * Function Group 2
     ***/
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallStartPage();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallStopPage(); 

    public static void onStartPage()
    {
        CallStartPage();
    }

    public static void onStopPage()
    {
        CallStopPage();
    }

    /**
     * Function Group 3
     ***/
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogScreen(string screenStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogClick(string clickStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogEvent(string eventStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogPurchase(string purchaseStr);
  

    public static void logScreen(Dictionary <string, object> dictionary) 
    {
        string jsonStr = Serializer.Serialize(dictionary);
        Debug.Log("screen json string : " + jsonStr);

        CallLogScreen(jsonStr);
    }
    
    public static void logClick(Dictionary <string, object> dictionary) 
    {
        string jsonStr = Serializer.Serialize(dictionary);
        Debug.Log("click json string : " + jsonStr);

        CallLogClick(jsonStr);
    }

    public static void logEvent(Dictionary <string, object> dictionary) 
    {
        string jsonStr = Serializer.Serialize(dictionary);
        Debug.Log("event json string : " + jsonStr);

        CallLogEvent(jsonStr);
    }

    public static void logPurchase(Dictionary <string, object> dictionary) 
    {
        string jsonStr = Serializer.Serialize(dictionary);
        Debug.Log("purchase json string : " + jsonStr);

        CallLogPurchase(jsonStr);
    }

    sealed class Serializer
    {
        StringBuilder builder;

        Serializer()
        {
            builder = new StringBuilder();
        }

        public static string Serialize(object obj)
        {
            var instance = new Serializer();

            instance.SerializeValue(obj);

            return instance.builder.ToString();
        }

        void SerializeValue(object value)
        {
            IList asList;
            IDictionary asDict;
            string asStr;

            if (value == null)
            {
                builder.Append("null");
            }
            else if ((asStr = value as string) != null)
            {
                SerializeString(asStr);
            }
            else if (value is bool)
            {
                builder.Append((bool)value ? "true" : "false");
            }
            else if ((asList = value as IList) != null)
            {
                SerializeArray(asList);
            }
            else if ((asDict = value as IDictionary) != null)
            {
                SerializeObject(asDict);
            }
            else if (value is char)
            {
                SerializeString(new string((char)value, 1));
            }
            else
            {
                SerializeOther(value);
            }
        }

        void SerializeObject(IDictionary obj)
        {
            bool first = true;

            builder.Append('{');

            foreach (object e in obj.Keys)
            {
                if (!first)
                {
                    builder.Append(',');
                }

                SerializeString(e.ToString());
                builder.Append(':');

                SerializeValue(obj[e]);

                first = false;
            }

            builder.Append('}');
        }

        void SerializeArray(IList anArray)
        {
            builder.Append('[');

            bool first = true;

            foreach (object obj in anArray)
            {
                if (!first)
                {
                    builder.Append(',');
                }

                SerializeValue(obj);

                first = false;
            }

            builder.Append(']');
        }

        void SerializeString(string str)
        {
            builder.Append('\"');

            char[] charArray = str.ToCharArray();
            foreach (var c in charArray)
            {
                switch (c)
                {
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '\b':
                        builder.Append("\\b");
                        break;
                    case '\f':
                        builder.Append("\\f");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        int codepoint = Convert.ToInt32(c);
                        if ((codepoint >= 32) && (codepoint <= 126))
                        {
                            builder.Append(c);
                        }
                        else
                        {
                            builder.Append("\\u");
                            builder.Append(codepoint.ToString("x4"));
                        }
                        break;
                }
            }

            builder.Append('\"');
        }

        void SerializeOther(object value)
        {
            // NOTE: decimals lose precision during serialization.
            // They always have, I'm just letting you know.
            // Previously floats and doubles lost precision too.
            if (value is float)
            {
                builder.Append(((float)value).ToString("R"));
            }
            else if (value is int
              || value is uint
              || value is long
              || value is sbyte
              || value is byte
              || value is short
              || value is ushort
              || value is ulong)
            {
                builder.Append(value);
            }
            else if (value is double
              || value is decimal)
            {
                builder.Append(Convert.ToDouble(value).ToString("R"));
            }
            else
            {
                SerializeString(value.ToString());
            }
        }
    }
#else 

    public static void setPushReceiver(string campaignId, string pushID) { }
    public static void setPushClick(string pushId, string campaignId, string pushTitle, string pushBody, long expireTime) { }
    public static void setDeepLink(string url) { }
    public static void setPushToken(string pushToken) { }
    public static void setUser(User user) { }
    public static void setUserLogout() { }
    
    public static void onStartPage() { }
    public static void onStopPage() { } 

    public static void logScreen(Dictionary<string, object> dictionary) { }
    public static void logPurchase(Dictionary<string, object> dictionary) { }
    public static void logEvent(Dictionary<string, object> dictionary) { }
    public static void logClick(Dictionary<string, object> dictionary) { } 

#endif

}
