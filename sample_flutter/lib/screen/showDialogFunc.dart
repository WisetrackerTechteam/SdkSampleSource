import 'package:flutter/material.dart';

class ShowDialogUtil {
  static void alert(BuildContext context ,   String title ,   String body ) { 
      showDialog(
        context: context,
        builder: (BuildContext context) {
          // return object of type Dialog
          return AlertDialog(
            title: new Text(title),
            content: new Text(body),
            actions: <Widget>[ 
              new FlatButton(
                child: new Text("닫기"),
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
            ],
          );
        },
      );
    }
}



