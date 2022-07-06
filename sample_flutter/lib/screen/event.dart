import 'package:flutter/material.dart';
import 'showDialogFunc.dart';


// 이벤트  화면 
class EventScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title : Text("Event Screen")
      ),

      body : Center (                
                child : Column(        
                              children: <Widget>[          
                                Container(               
                                  height : 100,     
                                  margin : const EdgeInsets.fromLTRB(0,120,0,0),   
                                  child : Text("이벤트 화면을 보고 있습니다.")
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
