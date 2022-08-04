using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DOT;

public class ButtonClick : MonoBehaviour
{
 
    /**
     * 회원가입 이벤트 함수 호출 
     * */
     public void fireSignupEvent()
     {
        Dictionary<string, object> eventData = new Dictionary<string, object>();
        eventData.Add("event", "w_signup_complete");
        eventData.Add("signupTp", "email");
        DOT.logEvent(eventData); 

        Debug.Log("w_signup_complete event finished. ");

     }

     /**
      * 로그인 이벤트 함수 호출 
      * */
      public void fireLoginEvent(){

         // user 정보 설정    
         DOT.setUser(
             new DOT_Model.User.Builder()
             .setGender("M")
             .setAge("A")
             .setAttr1("attr1")
             .build()
         );  

         // 로그인 완료 이벤트 전송    
         Dictionary<string, object> eventData = new Dictionary<string, object>();
         eventData.Add("event", "w_login_complete");
         eventData.Add("loginTp", "facebook"); 
         DOT.logEvent(eventData);

         Debug.Log("w_signup_complete event finished. ");
      }

      /**
       *  구매 완료 이벤트 함수 호출 
       **/
       public void firePurchaseEvent(){

         Dictionary<string, object> purchase = new Dictionary<string, object>();
         Dictionary<string, object> product = new Dictionary<string, object>();
         product.Add("pg1", "상품카테고리(대)");
         product.Add("pnc", "상품코드");
         product.Add("pnAtr1", "상품속성#1");
         product.Add("ea", 1);
         product.Add("amount", 10000);

         List<Dictionary<string, object>> productList = new List<Dictionary<string, object>>();
         productList.Add(product);
         purchase.Add("product", productList);
         DOT.logPurchase(purchase); 

       } 

       /**
        * 게임 화면 데이터 전송 ( 체류 시간 )
        **/
        public void fireSpentTimeEvent(){

            DOT.onStartPage();
            Dictionary<string, object> page = new Dictionary<string, object>();
            page.Add("pi", "gamePlay");
            DOT.logScreen(page); 

        } 
        
}
