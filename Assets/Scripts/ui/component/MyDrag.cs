using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
namespace UnityEngine.UI
{
    //拖动组件，返回拖动的信息
    public class MyDrag : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDrag
    {
        bool isDrag = false;
        MyDragData myDragData = new MyDragData();
        Vector2 pos = Vector3.zero;
        public void OnDragChange()
        {
            if (isDrag)
            {
                myDragData.go = gameObject;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    gameObject.transform.parent as RectTransform,
                    new Vector2(Input.mousePosition.x,Input.mousePosition.y),
                    Camera.main,
                    out pos);
                myDragData.uiPos = pos;
                SendMessageUpwards("OnDragEvent", myDragData);

            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isDrag = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDrag = false;
        }
        private void Update()
        {
            OnDragChange();
            //Debug.Log(Input.mousePosition);
        }
    }

    public class MyDragData
    {
        public GameObject go;//被拖动的物体
        public Vector2 uiPos;//当前坐标

    }
    public interface IDrag
    {
        void OnDragChange();
    }
}
