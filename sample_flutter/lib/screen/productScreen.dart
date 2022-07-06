import 'package:flutter/material.dart';
import 'showDialogFunc.dart';


// 상품 상세 화면 
class ProductDetailScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title : Text("Product Screen")
      ),
      
      body : Center (                
                child : Column(        
                              children: <Widget>[          
                                Container(               
                                  height : 100,     
                                  margin : const EdgeInsets.fromLTRB(0,120,0,0),   
                                  child : Text("상품 상세 화면을 보고 있습니다.")
                                ),   
                                
                                new RaisedButton(
                                  onPressed: (){
                                     ShowDialogUtil.alert(context, '확인','장바구니 담기 이벤트가 서버로 전송되었습니다'); 
                                  },
                                  child: new Text('장바구니 담기 이벤트'),
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
