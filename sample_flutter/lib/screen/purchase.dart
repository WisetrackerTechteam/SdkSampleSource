import 'package:flutter/material.dart';


// 구매 완료  화면 
class PurchaseScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
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