import 'package:flutter/material.dart';
import 'showDialogFunc.dart';
import 'dart:developer';



// 메인 화면 
class MainScreen extends StatelessWidget {

 

  @override
  Widget build(BuildContext context) { 
    return Scaffold(
      appBar: AppBar(
        title : Text("Main Screen")
      ),
      body : Center (                
                child : Column(        
                              children: <Widget>[          
                                Container(               
                                  height : 100,     
                                  margin : const EdgeInsets.fromLTRB(0,120,0,0),   
                                  child : Text("메인 화면을 보고 있습니다.")
                                ),   
                                new RaisedButton(
                                  onPressed: (){
                                     ShowDialogUtil.alert(context, '확인','회원가입 이벤트가 서버로 전송되었습니다'); 
                                  },
                                  child: new Text('회원가입 이벤트'),
                                ),
                                new RaisedButton(
                                  onPressed: () { 
                                      ShowDialogUtil.alert(context, '확인','로그인 이벤트가 서버로 전송되었습니다'); 
                                  },
                                  child: new Text('로그인 이벤트'),
                                ),
                                new RaisedButton(
                                  onPressed: () {
                                      Navigator.pushNamed(
                                        context,
                                        '/productDetail',
                                      );
                                  },
                                  child: new Text('상품 상세 페이지 이동'),
                                ),
                                new RaisedButton(
                                  onPressed: () {
                                      Navigator.pushNamed(
                                        context,
                                        '/purchase',
                                      );
                                  },
                                  child: new Text('결제 완료 페이지 이동'),
                                ),
                                new RaisedButton(
                                  onPressed: () {
                                      Navigator.pushNamed(
                                        context,
                                        '/event',
                                      );
                                  },
                                  child: new Text('이벤트 페이지 이동'),
                                ) 
                              ]      
                            ), 
              ), 

    );
  }
}