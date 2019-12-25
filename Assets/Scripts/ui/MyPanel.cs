using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MyPanel :PanelBase
{
    public override bool IsVisible => gameObject && gameObject.activeSelf;

    public override void Display(bool b)
    {
        if (b)
        {
            _show();

        }
        else {
            _hide();

        }

    }
    protected string _panelResName;
    private void _hide()
    {
        if (!IsVisible) return;
        if (gameObject)
            gameObject.SetActive(false);
        //销毁
    }

    private void _show()
    {
        if (!gameObject) {
            BuildPanel();
            //可以提前添加协议绑定

        }
        gameObject.SetActive(true);
    }
    void BuildPanel() {
        //从res中获取预制体
        _gameObject= GameObject.Instantiate(Resources.Load<GameObject>(_panelResName));
        if (!_gameObject) Debug.Log($"{_panelResName},Resources中找不到");
        MyGUIManager.GetInstance().AddPanelObject(this);
    }
    //填充数据 2.0 组件和协议之间建立多对多的关系
    public void FillData(object obj) {
        if (!IsVisible) return;
        var  components= gameObject.GetComponentsInChildren<MyComponent>();
        foreach (var component in components) {
            if (string.IsNullOrEmpty(component.SuperText)) continue;
            //在obj的公共字段中查找并赋值
            var type=obj.GetType();
            foreach (var f in type.GetFields()) {
                if (f.Name == component.SuperText)
                {
                    component.SetData(f.GetValue(obj) as string);
                }
            }
        }
    }
}
