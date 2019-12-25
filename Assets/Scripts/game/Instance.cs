using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LogicMM.FireOnAppInit();
        InvokeRepeating("SetData", 1, 1);
        
    }
    int i=0;
    void SetData() {
       // LogicMM.testControl.b2C_GET = new TestControl.B2C_GET() { key =(i++).ToString() };
    }
    // Update is called once per frame
    void Update()
    {

    }
}
