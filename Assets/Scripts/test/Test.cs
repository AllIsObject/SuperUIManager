using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;
using UnityEngine;

class Test  :MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("Json测试"))
        {
            WWW www = new WWW(Application.streamingAssetsPath+"/json.txt");
            while (true)
            {
                if (!string.IsNullOrEmpty(www.error))
                    throw new Exception("配置文件读取异常");
                if (www.isDone)
                    break;
            }
            SimpleObject value = www.text.FromJson<SimpleObject>();
            Debug.Log($"{value.H.B.A}");
        }
    }
    class SimpleObject
    {
        public int A;
        public float B;
        public string C { get; set; }
        public List<int> D { get; set; }
        public Dictionary<string, SimpleObject2> E;
        public int[] F=new int[10];
        public bool G;
        public SimpleObject2 H;
    }

    class SimpleObject2
    {
        public int A;
        public SimpleObject3 B;
    }

    class SimpleObject3
    {
        public int A;
    }
}
