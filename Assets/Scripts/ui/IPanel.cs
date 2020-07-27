using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public interface IPanel {
    void Display(bool b);
    bool IsVisible { get; }
    void InitPanel();
}
public class PanelBase : IPanel
{
    protected GameObject _gameObject;

    public virtual bool IsVisible {
        get {
            return false;
        }
    }

    public GameObject gameObject { get => _gameObject;  }

    public virtual void Display(bool b)
    {
        throw new NotImplementedException();
    }

    public virtual void InitPanel()
    {

    }

    public virtual void OnClick(MonoBehaviour behaviour) {

    }

    public virtual void OnDrag(MyDragData  myDragData)
    {

    }
}