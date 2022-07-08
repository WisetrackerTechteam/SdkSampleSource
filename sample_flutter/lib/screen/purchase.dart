import 'package:flutter/material.dart';
import 'package:dot_flutter/dot_flutter.dart';


// 구매 완료  화면 
class PurchaseScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {

    // 구매 완료 페이지 스크린 아이디 설정. 
    Map pageMap = {};
    pageMap['page_id'] = 'purchaseScreen'; 
    DOT.logScreen(pageMap);
 

/**
    구매 데이터는 현재 화면이 사용자에게 노출될때, 전송됩니다. 
    따라서, StatefullWidget 에 의해서 아래의 부분이 반복해서 호출될 수 있으므로, 
    실제 구현된 상황에 따라, 구매 데이터가 1회만 전송될 수 있도록 하는 추가 구현을 하시기 바랍니다.  
   **/
    Map product = {};
    product["product_id"] = "2007291158";
    product["product_name"] = "Leia Pleats Bag Black";
    product["quantity"] = 1;
    product["revenue"] = 20000; 


    Map purchaseMap = {};
    purchaseMap["transaction_id"] = "TR2020111129420";
    purchaseMap["currency"] = "KRW";
    purchaseMap["product"] = product;
    
    DOT.logPurchase(purchaseMap);



    return Scaffold(
      appBar: AppBar(
        title : Text("Purchase Screen")
      ),
      
      body : Center (                
          child : Column(        
                        children: <Widget>[          
                          Container(               
                            height : 100,     
                            margin : const EdgeInsets.fromLTRB(0,120,0,0),   
                            child : Text("구매 완료 데이터가 서버로 전송되었습니다.")
                          ),     
                          
                          new RaisedButton(
                            onPressed: (){
                                Navigator.pop(context);
                            },
                            child: new Text('메인으로 돌아가기'),
                          ),                                 
                        ]      
                      ), 
        ), 

    );
  }
}