using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine.UI
{
    public class MyPanelEventListener
    {
        PanelBase _event;
        IUIEvent _eventBase;
        public void OnInit(PanelBase panel,IUIEvent eventBase) {
            _event = panel;
            _eventBase = eventBase;

            _eventBase.EventOnClick += OnClickEvent;
            _eventBase.EventOnDrag += OnDragEvent;
        }

        void OnClickEvent(MonoBehaviour behaviour ) {

            _event.OnClick(behaviour);
        }

        void OnDragEvent(MyDragData myDragData)
        {
            _event.OnDrag(myDragData);
        }

    }




}
