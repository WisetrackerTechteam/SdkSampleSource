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

    public static void initialization()
    {
        Debug.Log("init");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("initialization");
        }
    }

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

    public static void onPlayStart()
    {
        onPlayStart(0);
    }

    public static void onPlayStart(int period)
    {
        if (unityHelperInstance != null)
        {
            Debug.Log("set play start");
            unityHelperInstance.Call("onPlayStart", period);
        }
    }

    public static void onPlayStop()
    {
        if (unityHelperInstance != null)
        {
            Debug.Log("set play stop");
            unityHelperInstance.Call("onPlayStop");
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

    /*
    public static void setPage(Page page)
    {
        Debug.Log("set page data");
        if (unityHelperInstance != null)
        {
            unityHelperInstance.Call("onStartPage", context);
            string pageString = pageObjectToDictionary(page);
            unityHelperInstance.Call("setPage", pageString);
        }
    }
    */

    /*
    public static string pageObjectToDictionary(Page page)
    {
        //if (page == null)
        //{
        //    return null;
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("customValue", getCustomValue(page.getCustomValue()));
        dictionary.Add("cp", page.getContentPath() ?? string.Empty);
        dictionary.Add("sresult", page.getSearchResultCount().ToString() ?? string.Empty);
        dictionary.Add("scart", page.getKeywordCategory() ?? string.Empty);
        dictionary.Add("skwd", page.getKeyword() ?? string.Empty);
        dictionary.Add("pi", page.getIdentity() ?? string.Empty);

        List<Product> productList = new List<Product>();
        productList.Add(page.getProduct());
        dictionary.Add("productList", getProductList(productList));

        string json = Serializer.Serialize(dictionary);
        Debug.Log("page json string : " + json);
        return json;
    }
    */

    /*
    public static void setConversion(Conversion conversion)
    {
        Debug.Log("set conversion data");
        if (unityHelperInstance != null)
        {
            string conversionString = conversionObjectToDictionary(conversion);
            unityHelperInstance.Call("setConversion", conversionString);
        }
    }
    */

    /*
    public static string conversionObjectToDictionary(Conversion conversion)
    {
        //if (conversion == null)
        //{
        //    return null;
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("customValue", getCustomValue(conversion.getCustomValue()));
        dictionary.Add("scart", conversion.getKeywordCategory() ?? string.Empty);
        dictionary.Add("skwd", conversion.getKeyword() ?? string.Empty);
        dictionary.Add("g1", conversion.getMicroConversion1().ToString() ?? string.Empty);
        dictionary.Add("g2", conversion.getMicroConversion2().ToString() ?? string.Empty);
        dictionary.Add("g3", conversion.getMicroConversion3().ToString() ?? string.Empty);
        dictionary.Add("g4", conversion.getMicroConversion4().ToString() ?? string.Empty);
        dictionary.Add("g5", conversion.getMicroConversion5().ToString() ?? string.Empty);
        dictionary.Add("g6", conversion.getMicroConversion6().ToString() ?? string.Empty);
        dictionary.Add("g7", conversion.getMicroConversion7().ToString() ?? string.Empty);
        dictionary.Add("g8", conversion.getMicroConversion8().ToString() ?? string.Empty);
        dictionary.Add("g9", conversion.getMicroConversion9().ToString() ?? string.Empty);
        dictionary.Add("g10", conversion.getMicroConversion10().ToString() ?? string.Empty);
        dictionary.Add("g11", conversion.getMicroConversion11().ToString() ?? string.Empty);
        dictionary.Add("g12", conversion.getMicroConversion12().ToString() ?? string.Empty);
        dictionary.Add("g13", conversion.getMicroConversion13().ToString() ?? string.Empty);
        dictionary.Add("g14", conversion.getMicroConversion14().ToString() ?? string.Empty);
        dictionary.Add("g15", conversion.getMicroConversion15().ToString() ?? string.Empty);
        dictionary.Add("g16", conversion.getMicroConversion16().ToString() ?? string.Empty);
        dictionary.Add("g17", conversion.getMicroConversion17().ToString() ?? string.Empty);
        dictionary.Add("g18", conversion.getMicroConversion18().ToString() ?? string.Empty);
        dictionary.Add("g19", conversion.getMicroConversion19().ToString() ?? string.Empty);
        dictionary.Add("g20", conversion.getMicroConversion20().ToString() ?? string.Empty);
        dictionary.Add("g21", conversion.getMicroConversion21().ToString() ?? string.Empty);
        dictionary.Add("g22", conversion.getMicroConversion22().ToString() ?? string.Empty);
        dictionary.Add("g23", conversion.getMicroConversion23().ToString() ?? string.Empty);
        dictionary.Add("g24", conversion.getMicroConversion24().ToString() ?? string.Empty);
        dictionary.Add("g25", conversion.getMicroConversion25().ToString() ?? string.Empty);
        dictionary.Add("g26", conversion.getMicroConversion26().ToString() ?? string.Empty);
        dictionary.Add("g27", conversion.getMicroConversion27().ToString() ?? string.Empty);
        dictionary.Add("g28", conversion.getMicroConversion28().ToString() ?? string.Empty);
        dictionary.Add("g29", conversion.getMicroConversion29().ToString() ?? string.Empty);
        dictionary.Add("g30", conversion.getMicroConversion30().ToString() ?? string.Empty);
        dictionary.Add("g31", conversion.getMicroConversion31().ToString() ?? string.Empty);
        dictionary.Add("g32", conversion.getMicroConversion32().ToString() ?? string.Empty);
        dictionary.Add("g33", conversion.getMicroConversion33().ToString() ?? string.Empty);
        dictionary.Add("g34", conversion.getMicroConversion34().ToString() ?? string.Empty);
        dictionary.Add("g35", conversion.getMicroConversion35().ToString() ?? string.Empty);
        dictionary.Add("g36", conversion.getMicroConversion36().ToString() ?? string.Empty);
        dictionary.Add("g37", conversion.getMicroConversion37().ToString() ?? string.Empty);
        dictionary.Add("g38", conversion.getMicroConversion38().ToString() ?? string.Empty);
        dictionary.Add("g39", conversion.getMicroConversion39().ToString() ?? string.Empty);
        dictionary.Add("g40", conversion.getMicroConversion40().ToString() ?? string.Empty);
        dictionary.Add("g41", conversion.getMicroConversion41().ToString() ?? string.Empty);
        dictionary.Add("g42", conversion.getMicroConversion42().ToString() ?? string.Empty);
        dictionary.Add("g43", conversion.getMicroConversion43().ToString() ?? string.Empty);
        dictionary.Add("g44", conversion.getMicroConversion44().ToString() ?? string.Empty);
        dictionary.Add("g45", conversion.getMicroConversion45().ToString() ?? string.Empty);
        dictionary.Add("g46", conversion.getMicroConversion46().ToString() ?? string.Empty);
        dictionary.Add("g47", conversion.getMicroConversion47().ToString() ?? string.Empty);
        dictionary.Add("g48", conversion.getMicroConversion48().ToString() ?? string.Empty);
        dictionary.Add("g49", conversion.getMicroConversion49().ToString() ?? string.Empty);
        dictionary.Add("g50", conversion.getMicroConversion50().ToString() ?? string.Empty);
        dictionary.Add("g51", conversion.getMicroConversion51().ToString() ?? string.Empty);
        dictionary.Add("g52", conversion.getMicroConversion52().ToString() ?? string.Empty);
        dictionary.Add("g53", conversion.getMicroConversion53().ToString() ?? string.Empty);
        dictionary.Add("g54", conversion.getMicroConversion54().ToString() ?? string.Empty);
        dictionary.Add("g55", conversion.getMicroConversion55().ToString() ?? string.Empty);
        dictionary.Add("g56", conversion.getMicroConversion56().ToString() ?? string.Empty);
        dictionary.Add("g57", conversion.getMicroConversion57().ToString() ?? string.Empty);
        dictionary.Add("g58", conversion.getMicroConversion58().ToString() ?? string.Empty);
        dictionary.Add("g59", conversion.getMicroConversion59().ToString() ?? string.Empty);
        dictionary.Add("g60", conversion.getMicroConversion60().ToString() ?? string.Empty);
        dictionary.Add("g61", conversion.getMicroConversion61().ToString() ?? string.Empty);
        dictionary.Add("g62", conversion.getMicroConversion62().ToString() ?? string.Empty);
        dictionary.Add("g63", conversion.getMicroConversion63().ToString() ?? string.Empty);
        dictionary.Add("g64", conversion.getMicroConversion64().ToString() ?? string.Empty);
        dictionary.Add("g65", conversion.getMicroConversion65().ToString() ?? string.Empty);
        dictionary.Add("g66", conversion.getMicroConversion66().ToString() ?? string.Empty);
        dictionary.Add("g67", conversion.getMicroConversion67().ToString() ?? string.Empty);
        dictionary.Add("g68", conversion.getMicroConversion68().ToString() ?? string.Empty);
        dictionary.Add("g69", conversion.getMicroConversion69().ToString() ?? string.Empty);
        dictionary.Add("g70", conversion.getMicroConversion70().ToString() ?? string.Empty);
        dictionary.Add("g71", conversion.getMicroConversion71().ToString() ?? string.Empty);
        dictionary.Add("g72", conversion.getMicroConversion72().ToString() ?? string.Empty);
        dictionary.Add("g73", conversion.getMicroConversion73().ToString() ?? string.Empty);
        dictionary.Add("g74", conversion.getMicroConversion74().ToString() ?? string.Empty);
        dictionary.Add("g75", conversion.getMicroConversion75().ToString() ?? string.Empty);
        dictionary.Add("g76", conversion.getMicroConversion76().ToString() ?? string.Empty);
        dictionary.Add("g77", conversion.getMicroConversion77().ToString() ?? string.Empty);
        dictionary.Add("g78", conversion.getMicroConversion78().ToString() ?? string.Empty);
        dictionary.Add("g79", conversion.getMicroConversion79().ToString() ?? string.Empty);
        dictionary.Add("g80", conversion.getMicroConversion80().ToString() ?? string.Empty);
        dictionary.Add("acptPush", conversion.getPushAgreement().ToString() ?? string.Empty);

        List<Product> productList = new List<Product>();
        productList.Add(conversion.getProduct());
        dictionary.Add("product", getProductList(productList));

        string json = Serializer.Serialize(dictionary);
        Debug.Log("conversion json string : " + json);
        return json;
    }
    */

    /*
    public static void setClick(Click click)
    {
        Debug.Log("set click data");
        if (unityHelperInstance != null)
        {
            string clickString = clickObjectToDictionary(click);
            unityHelperInstance.Call("setClick", clickString);
        }
    }
    */

    /*
    public static string clickObjectToDictionary(Click click)
    {
        //if (click == null)
        //{
        //    return null;
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("customValue", getCustomValue(click.getCustomValue()));
        dictionary.Add("ckTp", click.getClickType() ?? string.Empty);
        dictionary.Add("ckData", click.getClickData() ?? string.Empty);
        dictionary.Add("product", getProductList(click.getProductList()));
        string json = Serializer.Serialize(dictionary);
        Debug.Log("click json string : " + json);
        return json;
    }
    */

    /*
    public static void setPurchase(Purchase purchase)
    {
        Debug.Log("set purchase data");
        if (unityHelperInstance != null)
        {
            string purchaseString = purchaseObjectToDictionary(purchase);
            unityHelperInstance.Call("setPurchase", purchaseString);
        }
    }
    */

    /*
    public static string purchaseObjectToDictionary(Purchase purchase)
    {
        //if (purchase == null)
        //{
        //    return null;
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("ordNo", purchase.getOrderNo() ?? string.Empty);
        dictionary.Add("curcy", purchase.getCurrency() ?? string.Empty);
        dictionary.Add("scart", purchase.getKeywordCategory() ?? string.Empty);
        dictionary.Add("skwd", purchase.getKeyword()?? string.Empty);
        dictionary.Add("useLatestIkwd", purchase.getUseLatestSearchKeyword().ToString() ?? string.Empty);
        dictionary.Add("useLatesMvt1", purchase.getUseLatestCustomValue1().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt2", purchase.getUseLatestCustomValue2().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt3", purchase.getUseLatestCustomValue3().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt4", purchase.getUseLatestCustomValue4().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt5", purchase.getUseLatestCustomValue5().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt6", purchase.getUseLatestCustomValue6().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt7", purchase.getUseLatestCustomValue7().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt8", purchase.getUseLatestCustomValue8().ToString()?? string.Empty);
        dictionary.Add("useLatesMvt9", purchase.getUseLatestCustomValue9().ToString() ?? string.Empty);
        dictionary.Add("useLatesMvt10", purchase.getUseLatestCustomValue10().ToString() ?? string.Empty);
        dictionary.Add("customValue", getCustomValue(purchase.getCustomValue()));
        dictionary.Add("product", getProductList(purchase.getProductList()));
        string json = Serializer.Serialize(dictionary);
        Debug.Log("purchase json string : " + json);
        return json;
    }
    */

    /*
    public static string getProductList(List<Product> productList)
    {

        if (productList == null || productList.Count < 1)
        {
            return "[{}]";
        }

        string jsonArray = "[";

        for (int i = 0; i < productList.Count; i++)
        {

            Product product = productList[i];
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string jsonString = "null";

            dictionary.Add("pg1", product.getFirstCategory());
            dictionary.Add("pg2", product.getSecondCategory());
            dictionary.Add("pg3", product.getThirdCategory());
            dictionary.Add("pg4", product.getDetailCategory());
            dictionary.Add("pnc", product.getProductCode());
            dictionary.Add("pnAtr1", product.getAttr1());
            dictionary.Add("pnAtr2", product.getAttr2());
            dictionary.Add("pnAtr3", product.getAttr3());
            dictionary.Add("pnAtr4", product.getAttr4());
            dictionary.Add("pnAtr5", product.getAttr5());
            dictionary.Add("pnAtr6", product.getAttr6());
            dictionary.Add("pnAtr7", product.getAttr7());
            dictionary.Add("pnAtr8", product.getAttr8());
            dictionary.Add("pnAtr9", product.getAttr9());
            dictionary.Add("pnAtr10", product.getAttr10());
            dictionary.Add("ordPno", product.getProductOrderNo());
            dictionary.Add("amt", product.getOrderAmount());
            dictionary.Add("eq", product.getOrderQuantity());
            dictionary.Add("rfnd", product.getRefundAmount());
            dictionary.Add("rfea", product.getRefundQuantity());
            dictionary.Add("optAmt", product.getOptionalAmount());

            jsonString = Serializer.Serialize(dictionary);

            if (i == (productList.Count - 1))
            {
                jsonArray = jsonArray + jsonString + "]";
            }
            else
            {
                jsonArray = jsonArray + jsonString + ",";
            }

        }

        Debug.Log("json array : " + jsonArray);
        return jsonArray;

    }
    */

    /*
    public static string getCustomValue(CustomValue customValue)
    {
        //if(customValue == null)
        //{
        //    return "";
        //}
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("mvt1", customValue.getValue1() ?? string.Empty);
        dictionary.Add("mvt2", customValue.getValue2() ?? string.Empty);
        dictionary.Add("mvt3", customValue.getValue3() ?? string.Empty);
        dictionary.Add("mvt4", customValue.getValue4() ?? string.Empty);
        dictionary.Add("mvt5", customValue.getValue5() ?? string.Empty);
        dictionary.Add("mvt6", customValue.getValue6() ?? string.Empty);
        dictionary.Add("mvt7", customValue.getValue7() ?? string.Empty);
        dictionary.Add("mvt8", customValue.getValue8() ?? string.Empty);
        dictionary.Add("mvt9", customValue.getValue9() ?? string.Empty);
        dictionary.Add("mvt10",customValue.getValue10() ?? string.Empty);
        string jsonString = Serializer.Serialize(dictionary);
        Debug.Log("custom value string : " + jsonString);
        return jsonString;
    }
    */

    /*
    public static AndroidJavaObject clickObjectToDictionary(Click click)
    {

        if(click == null)
        {
            return null;
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("ckTp", click.getClickType());
        dictionary.Add("ckData", click.getClickData());
        dictionary.Add("mvt1", click.getCustomValue().getValue1() ?? string.Empty);
        dictionary.Add("mvt2", click.getCustomValue().getValue2() ?? string.Empty);
        dictionary.Add("mvt3", click.getCustomValue().getValue3() ?? string.Empty);
        dictionary.Add("mvt4", click.getCustomValue().getValue4() ?? string.Empty);
        dictionary.Add("mvt5", click.getCustomValue().getValue5() ?? string.Empty);
        dictionary.Add("mvt6", click.getCustomValue().getValue6() ?? string.Empty);
        dictionary.Add("mvt7", click.getCustomValue().getValue7() ?? string.Empty);
        dictionary.Add("mvt8", click.getCustomValue().getValue8() ?? string.Empty);
        dictionary.Add("mvt9", click.getCustomValue().getValue9() ?? string.Empty);
        dictionary.Add("mvt10", click.getCustomValue().getValue10() ?? string.Empty);
        return toHahMap(dictionary);
    }*/

    /*
    public static AndroidJavaObject conversionObjectToDictionary(Conversion conversion)
    {
        if (conversion == null)
        {
            return null;
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("mvt1", conversion.getCustomValue().getValue1() ?? string.Empty);
        dictionary.Add("mvt2", conversion.getCustomValue().getValue2() ?? string.Empty);
        dictionary.Add("mvt3", conversion.getCustomValue().getValue3() ?? string.Empty);
        dictionary.Add("mvt4", conversion.getCustomValue().getValue4() ?? string.Empty);
        dictionary.Add("mvt5", conversion.getCustomValue().getValue5() ?? string.Empty);
        dictionary.Add("mvt6", conversion.getCustomValue().getValue6() ?? string.Empty);
        dictionary.Add("mvt7", conversion.getCustomValue().getValue7() ?? string.Empty);
        dictionary.Add("mvt8", conversion.getCustomValue().getValue8() ?? string.Empty);
        dictionary.Add("mvt9", conversion.getCustomValue().getValue9() ?? string.Empty);
        dictionary.Add("mvt10", conversion.getCustomValue().getValue10() ?? string.Empty);
        dictionary.Add("g1", conversion.getMicroConversion1().ToString() ?? string.Empty);
        dictionary.Add("g2", conversion.getMicroConversion2().ToString() ?? string.Empty);
        dictionary.Add("g3", conversion.getMicroConversion3().ToString() ?? string.Empty);
        dictionary.Add("g4", conversion.getMicroConversion4().ToString() ?? string.Empty);
        dictionary.Add("g5", conversion.getMicroConversion5().ToString() ?? string.Empty);
        dictionary.Add("g6", conversion.getMicroConversion6().ToString() ?? string.Empty);
        dictionary.Add("g7", conversion.getMicroConversion7().ToString() ?? string.Empty);
        dictionary.Add("g8", conversion.getMicroConversion8().ToString() ?? string.Empty);
        dictionary.Add("g9", conversion.getMicroConversion9().ToString() ?? string.Empty);
        dictionary.Add("g10", conversion.getMicroConversion10().ToString() ?? string.Empty);
        dictionary.Add("g11", conversion.getMicroConversion11().ToString() ?? string.Empty);
        dictionary.Add("g12", conversion.getMicroConversion12().ToString() ?? string.Empty);
        dictionary.Add("g13", conversion.getMicroConversion13().ToString() ?? string.Empty);
        dictionary.Add("g14", conversion.getMicroConversion14().ToString() ?? string.Empty);
        dictionary.Add("g15", conversion.getMicroConversion15().ToString() ?? string.Empty);
        dictionary.Add("g16", conversion.getMicroConversion16().ToString() ?? string.Empty);
        dictionary.Add("g17", conversion.getMicroConversion17().ToString() ?? string.Empty);
        dictionary.Add("g18", conversion.getMicroConversion18().ToString() ?? string.Empty);
        dictionary.Add("g19", conversion.getMicroConversion19().ToString() ?? string.Empty);
        dictionary.Add("g20", conversion.getMicroConversion20().ToString() ?? string.Empty);
        dictionary.Add("g21", conversion.getMicroConversion21().ToString() ?? string.Empty);
        dictionary.Add("g22", conversion.getMicroConversion22().ToString() ?? string.Empty);
        dictionary.Add("g23", conversion.getMicroConversion23().ToString() ?? string.Empty);
        dictionary.Add("g24", conversion.getMicroConversion24().ToString() ?? string.Empty);
        dictionary.Add("g25", conversion.getMicroConversion25().ToString() ?? string.Empty);
        dictionary.Add("g26", conversion.getMicroConversion26().ToString() ?? string.Empty);
        dictionary.Add("g27", conversion.getMicroConversion27().ToString() ?? string.Empty);
        dictionary.Add("g28", conversion.getMicroConversion28().ToString() ?? string.Empty);
        dictionary.Add("g29", conversion.getMicroConversion29().ToString() ?? string.Empty);
        dictionary.Add("g30", conversion.getMicroConversion30().ToString() ?? string.Empty);
        dictionary.Add("g31", conversion.getMicroConversion31().ToString() ?? string.Empty);
        dictionary.Add("g32", conversion.getMicroConversion32().ToString() ?? string.Empty);
        dictionary.Add("g33", conversion.getMicroConversion33().ToString() ?? string.Empty);
        dictionary.Add("g34", conversion.getMicroConversion34().ToString() ?? string.Empty);
        dictionary.Add("g35", conversion.getMicroConversion35().ToString() ?? string.Empty);
        dictionary.Add("g36", conversion.getMicroConversion36().ToString() ?? string.Empty);
        dictionary.Add("g37", conversion.getMicroConversion37().ToString() ?? string.Empty);
        dictionary.Add("g38", conversion.getMicroConversion38().ToString() ?? string.Empty);
        dictionary.Add("g39", conversion.getMicroConversion39().ToString() ?? string.Empty);
        dictionary.Add("g40", conversion.getMicroConversion40().ToString() ?? string.Empty);
        dictionary.Add("g41", conversion.getMicroConversion41().ToString() ?? string.Empty);
        dictionary.Add("g42", conversion.getMicroConversion42().ToString() ?? string.Empty);
        dictionary.Add("g43", conversion.getMicroConversion43().ToString() ?? string.Empty);
        dictionary.Add("g44", conversion.getMicroConversion44().ToString() ?? string.Empty);
        dictionary.Add("g45", conversion.getMicroConversion45().ToString() ?? string.Empty);
        dictionary.Add("g46", conversion.getMicroConversion46().ToString() ?? string.Empty);
        dictionary.Add("g47", conversion.getMicroConversion47().ToString() ?? string.Empty);
        dictionary.Add("g48", conversion.getMicroConversion48().ToString() ?? string.Empty);
        dictionary.Add("g49", conversion.getMicroConversion49().ToString() ?? string.Empty);
        dictionary.Add("g50", conversion.getMicroConversion50().ToString() ?? string.Empty);
        dictionary.Add("g51", conversion.getMicroConversion51().ToString() ?? string.Empty);
        dictionary.Add("g52", conversion.getMicroConversion52().ToString() ?? string.Empty);
        dictionary.Add("g53", conversion.getMicroConversion53().ToString() ?? string.Empty);
        dictionary.Add("g54", conversion.getMicroConversion54().ToString() ?? string.Empty);
        dictionary.Add("g55", conversion.getMicroConversion55().ToString() ?? string.Empty);
        dictionary.Add("g56", conversion.getMicroConversion56().ToString() ?? string.Empty);
        dictionary.Add("g57", conversion.getMicroConversion57().ToString() ?? string.Empty);
        dictionary.Add("g58", conversion.getMicroConversion58().ToString() ?? string.Empty);
        dictionary.Add("g59", conversion.getMicroConversion59().ToString() ?? string.Empty);
        dictionary.Add("g60", conversion.getMicroConversion60().ToString() ?? string.Empty);
        dictionary.Add("g61", conversion.getMicroConversion61().ToString() ?? string.Empty);
        dictionary.Add("g62", conversion.getMicroConversion62().ToString() ?? string.Empty);
        dictionary.Add("g63", conversion.getMicroConversion63().ToString() ?? string.Empty);
        dictionary.Add("g64", conversion.getMicroConversion64().ToString() ?? string.Empty);
        dictionary.Add("g65", conversion.getMicroConversion65().ToString() ?? string.Empty);
        dictionary.Add("g66", conversion.getMicroConversion66().ToString() ?? string.Empty);
        dictionary.Add("g67", conversion.getMicroConversion67().ToString() ?? string.Empty);
        dictionary.Add("g68", conversion.getMicroConversion68().ToString() ?? string.Empty);
        dictionary.Add("g69", conversion.getMicroConversion69().ToString() ?? string.Empty);
        dictionary.Add("g70", conversion.getMicroConversion70().ToString() ?? string.Empty);
        dictionary.Add("g71", conversion.getMicroConversion71().ToString() ?? string.Empty);
        dictionary.Add("g72", conversion.getMicroConversion72().ToString() ?? string.Empty);
        dictionary.Add("g73", conversion.getMicroConversion73().ToString() ?? string.Empty);
        dictionary.Add("g74", conversion.getMicroConversion74().ToString() ?? string.Empty);
        dictionary.Add("g75", conversion.getMicroConversion75().ToString() ?? string.Empty);
        dictionary.Add("g76", conversion.getMicroConversion76().ToString() ?? string.Empty);
        dictionary.Add("g77", conversion.getMicroConversion77().ToString() ?? string.Empty);
        dictionary.Add("g78", conversion.getMicroConversion78().ToString() ?? string.Empty);
        dictionary.Add("g79", conversion.getMicroConversion79().ToString() ?? string.Empty);
        dictionary.Add("g80", conversion.getMicroConversion80().ToString() ?? string.Empty);
        dictionary.Add("skwd", conversion.getKeyword() ?? string.Empty);
        dictionary.Add("scart", conversion.getKeywordCategory() ?? string.Empty);
        dictionary.Add("acptPush", conversion.getPushAgreement().ToString() ?? string.Empty);

        if (conversion.getProduct() != null) { 
            dictionary.Add("pg1", conversion.getProduct().getFirstCategory() ?? string.Empty);
            dictionary.Add("pg2", conversion.getProduct().getSecondCategory() ?? string.Empty);
            dictionary.Add("pg3", conversion.getProduct().getThirdCategory() ?? string.Empty);
            dictionary.Add("pg4", conversion.getProduct().getDetailCategory() ?? string.Empty);
            dictionary.Add("pnc", conversion.getProduct().getProductCode() ?? string.Empty);
            dictionary.Add("pnAtr1", conversion.getProduct().getAttribute1() ?? string.Empty);
            dictionary.Add("pnAtr2", conversion.getProduct().getAttribute2() ?? string.Empty);
            dictionary.Add("pnAtr3", conversion.getProduct().getAttribute3() ?? string.Empty);
            dictionary.Add("pnAtr4", conversion.getProduct().getAttribute4() ?? string.Empty);
            dictionary.Add("pnAtr5", conversion.getProduct().getAttribute5() ?? string.Empty);
            dictionary.Add("pnAtr6", conversion.getProduct().getAttribute6() ?? string.Empty);
            dictionary.Add("pnAtr7", conversion.getProduct().getAttribute7() ?? string.Empty);
            dictionary.Add("pnAtr8", conversion.getProduct().getAttribute8() ?? string.Empty);
            dictionary.Add("pnAtr9", conversion.getProduct().getAttribute9() ?? string.Empty);
            dictionary.Add("pnAtr10", conversion.getProduct().getAttribute10() ?? string.Empty);
            dictionary.Add("ordPno", conversion.getProduct().getProductOrderNumber() ?? string.Empty);
            dictionary.Add("amt", conversion.getProduct().getOrderAmount().ToString() ?? string.Empty);
            dictionary.Add("ea", conversion.getProduct().getOrderQuantity().ToString() ?? string.Empty);
            dictionary.Add("rfnd", conversion.getProduct().getRefundAmount().ToString() ?? string.Empty);
            dictionary.Add("rfea", conversion.getProduct().getRefundQuantity().ToString() ?? string.Empty);
            Debug.Log("set until rfea");
        }

        return toHahMap(dictionary);
               
    }*/

    /*
    private static AndroidJavaObject toHahMap(Dictionary<string, string> dictionary)
    {

        if (dictionary == null)
        {
            return null;
        }

        AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap");
        if(hashMap == null)
        {
            Debug.Log("hash map is null");
            return null;
        }
        IntPtr put = AndroidJNIHelper.GetMethodID(hashMap.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
        Debug.Log("intptr put : " + put);

        object[] args = new object[2];
        foreach (KeyValuePair<string, string> kvp in dictionary)
        {
            using (AndroidJavaObject key = new AndroidJavaObject("java.lang.String", kvp.Key))
            {
                using (AndroidJavaObject value = new AndroidJavaObject("java.lang.String", kvp.Value))
                {
                    Debug.Log("key : " + kvp.Key);
                    Debug.Log("value : " + kvp.Value);
                    args[0] = key;
                    args[1] = value;
                    AndroidJNI.CallObjectMethod(hashMap.GetRawObject(), put, AndroidJNIHelper.CreateJNIArgArray(args));
                }
            }
        }
        Debug.Log("hashmap data : " + hashMap.ToString());
        return hashMap;
    }*/

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
    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallInitialization();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetClick(ClickIos Click);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetConversion(ConversionIos Conversion);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetPage(PageIos Page);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetPurchase(PurchaseIos purchase);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void MakeProductList(ProductIos product, string[] optionalAmountKeys, double[] optionalAmountValues, int optAmtCount);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void MakeProduct(ProductIos product, string[] optionalAmountKeys, double[] optionalAmountValues, int optAmtCount);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void MakeProductListInClick(ProductIos product);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void MakeProductInClick(ProductIos product);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallStartPage();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallStopPage();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallSetUser(UserIos user);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogScreen(string screenStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogClick(string clickStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogEvent(string eventStr);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static public void CallLogPurchase(string purchaseStr);

    public static void initialization()
    {
        CallInitialization();
    }

    public static void startPage()
    {
        CallStartPage();
    }

    public static void stopPage()
    {
        CallStopPage();
    }

    public static void setUser(User user)
    {
        UserIos userIos = new UserIos(user);

        CallSetUser(userIos);
    }

    public static void setPage(Page page)
    {
        PageIos pageIos = new PageIos(page);

        CallSetPage(pageIos);
    }

    public static void setConversion(Conversion conversion)
    {
        // Convert Conversion to C-marshallable struct conversionIos
        ConversionIos conversionIos = new ConversionIos(conversion);

        CallSetConversion(conversionIos);
    }

    public static void setPurchase(Purchase purchase)
    {

        int productCount = null == purchase.getProductList() ? 0 : purchase.getProductList().Count;
        PurchaseIos purchaseIos = new PurchaseIos(purchase);

        if (productCount > 0)
        {

            ProductIos[] productList = new ProductIos[productCount];

            string[] optAmtKeys;
            double[] optAmtValues;


            for (int i = 0; i < productCount; i++)
            {
                productList[i] = new ProductIos((purchase.getProductList())[i]);
                optAmtKeys = new string[(purchase.getProductList())[i].optionalAmount.Count];
                optAmtValues = new double[(purchase.getProductList())[i].optionalAmount.Count];
   
                for (int j = 0; j < (purchase.getProductList())[i].optionalAmount.Count; j++)
                {
                    var pair = (purchase.getProductList())[i].optionalAmount.ElementAt(j);
                    optAmtKeys[j] = pair.Key;
                    optAmtValues[j] = pair.Value;
                }
                ProductIos productIos = new ProductIos((purchase.getProductList())[i]);
                MakeProductList(productIos, optAmtKeys, optAmtValues, optAmtKeys.Length);
            }
        }
        else if (productCount == 0)
        {
            ProductIos productIos = new ProductIos(purchase.getProduct());

            string[] optAmtKeys = new string[purchase.getProduct().optionalAmount.Count];
            double[] optAmtValues = new double[purchase.getProduct().optionalAmount.Count];

            for (int j = 0; j < purchase.getProduct().optionalAmount.Count; j++)
            {
                var pair = purchase.getProduct().optionalAmount.ElementAt(j);
                optAmtKeys[j] = pair.Key;
                optAmtValues[j] = pair.Value;
            }
            MakeProduct(productIos, optAmtKeys, optAmtValues, optAmtKeys.Length);
        }
        CallSetPurchase(purchaseIos);
    }

    public static void setClick(Click click)
    {

        int productCount = null == click.getProductList() ? 0 : click.getProductList().Count;
        ClickIos clickIos = new ClickIos(click);

        if (productCount > 0)
        {

            ProductIos[] productList = new ProductIos[productCount];


            for (int i = 0; i < productCount; i++)
            {
                productList[i] = new ProductIos((click.getProductList())[i]);


                ProductIos productIos = new ProductIos((click.getProductList())[i]);
                MakeProductListInClick(productIos);
            }
        }
        else if (productCount == 0)
        {
            ProductIos productIos = new ProductIos(click.getProduct());


            MakeProductInClick(productIos);
        }
        CallSetClick(clickIos);
    }

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
    public static void initialization() { }
    public static void setPushReceiver(string campaignId, string pushID) { }
    public static void setPushClick(string pushId, string campaignId, string pushTitle, string pushBody, long expireTime) { }
    public static void setDeepLink(string url) { }
    public static void setPushToken(string pushToken) { }
    public static void setUser(User user) { }
    public static void setUserLogout() { }
    public static void logScreen(Dictionary<string, object> dictionary) { }
    public static void onStartPage() { }
    public static void onStopPage() { }
    public static void onPlayStart() { }
    public static void onPlayStart(int period) { }
    public static void onPlayStop() { }
    public static void logPurchase(Dictionary<string, object> dictionary) { }
    public static void logEvent(Dictionary<string, object> dictionary) { }
    public static void logClick(Dictionary<string, object> dictionary) { }
    //public static void setPage(Page page) { }
    //public static void setClick(Click click) { }
    //public static void setConversion(Conversion conversion) { }
    //public static void setPurchase(Purchase purchase) { }

#endif

}
