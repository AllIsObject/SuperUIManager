using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityEngine.UI {
  
    public class MyText : Text, MyComponent
    {
        string superText = "";
        protected override void OnEnable()
        {
            base.OnEnable();
            superText = this.text;
        }

        public void SetData(string text)
        {
            this.text = text;
        }

        string MyComponent.SuperText {
            get {
                return superText;
            }
        }
    }
}

