using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DOT;
public class AppStarter : MonoBehaviour
{
 
    void Awake()
    {
         

    }


    // Start is called before the first frame update
    void Start()
    {
        DOT.onStartPage();
        Dictionary<string, object> page = new Dictionary<string, object>();
        page.Add("pi", "gamePlay");
        DOT.logScreen(page); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
