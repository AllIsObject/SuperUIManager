using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChildDemo : MonoBehaviour {
    public string toId = "Cube (1)/Cube (3)/Cube (5)";
    public Transform toTransform;

    private void OnGUI()
    {
        if (GUILayout.Button("查找对象")) {
            GameObject go=toTransform.gameObject.FindChild(toId);
            go.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }




}
/// <summary>
/// 查找元素孩子的工具
/// </summary>
public  static class FindChildUtil{

    /// <summary>
    /// 递归搜索第一个匹配
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    static public T FindInChild<T>(this GameObject go,string name="") where T:Component
    {
        if (go == null) return null;
        T comp = null;
        if (!string.IsNullOrEmpty(name) && !go.name.Contains(name))
        {
            comp = null;
        }
        else
            comp = go.GetComponent<T>();
        if (comp == null)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                comp = FindInChild<T>(go.transform.GetChild(i).gameObject,name);
                if (comp)
                    return comp;
            }
        }

        return comp;
    }

    static public T AddChild<T>(this GameObject parent) where T : Component
    {
        GameObject go = parent.AddChild();
        go.name = "My" + typeof(T).Name;
        return go.AddComponent<T>();
    }


    static public GameObject AddChild(this GameObject parent) 
    {
        GameObject go = new GameObject();
        if (parent != null)
        {
            var t = go.transform;
            t.SetParent(parent.transform);
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            go.layer = parent.layer;
        }
        return go;
    }
    /// <summary>
    /// GameObject扩展方法
    /// </summary>
    /// <param name="go"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static GameObject FindChild(this GameObject go, string id)
    {
        if (go==null) {
            Debug.LogError("FindChild,go is null");
            return null;
        }
        var t = FindChild(go.transform, id);


        return t !=null ?t.gameObject:null;
    }
    /// <summary>
    /// 根据id查找
    /// </summary>
    /// <param name="t"></param>
    /// <param name="id"></param>
    /// <returns></returns>
     static Transform FindChild(Transform t, string id) {
        if (id == ".") return t;//查找自己
        //用/分割路径
        if (id.IndexOf("/")>=0) {
            var arr = id.Split('/');
            foreach ( var a in arr) {
                //t = FindChildDirectByQueue(t,a);
                t = FindChildDirectByRecursive(t, a);
                if (t==null) {
                    Debug.LogError("FindChild failed ,id:"+id);
                    break;
                }
            }
            return t;
        }
        //直接查找
        //t = FindChildDirectByQueue(t, id);
        t = FindChildDirectByRecursive(t, id);
        if (t == null)
        {
            Debug.LogError("FindChild failed ,id:" + id);
        }
        return t;
    }
    /// <summary>
    /// 直接查找
    /// </summary>
    /// <param name="t"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    static Transform FindChildDirectByQueue(Transform t,string id) {
        var queue = s_findchild_stack;
        queue.Enqueue(t);//进入队列，放到队列的最后

        while (queue.Count >0) {
            t = queue.Dequeue();//取出队列第一个元素
            var t2 = t.Find(id);
            if (t2 != null) {
                queue.Clear();
                return t2;
            }
            for (int i=0,count = t.childCount;i<count; i++ ) {
                t2 = t.GetChild(i);
                queue.Enqueue(t2);
            }


        }
        return null;
    }
    static Queue<Transform> s_findchild_stack = new Queue<Transform>();

    /// <summary>
    /// 递归查找
    /// </summary>
    /// <param name="t"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    static Transform FindChildDirectByRecursive(Transform t, string id) {
        var t2= t.Find(id);
        if (t2!=null) {
            return t2;
        }
        for (int i=0;i< t.childCount;i++) {
            t2= FindChildDirectByRecursive(t.GetChild(i), id);
            if (t2 != null)
            {
                return t2;//要将每次调用的结果都返回去
            }
        }
        return null;
    }

    public static RectTransform GetRectTransform(this GameObject obj)
    {
        if (!obj)
            return null;
        return obj.transform as RectTransform;
    }
}