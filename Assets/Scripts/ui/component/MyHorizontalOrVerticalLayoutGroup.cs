using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace UnityEngine.UI
{
    public class MyHorizontalOrVerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        public override void CalculateLayoutInputVertical()
        {
            throw new NotImplementedException();
        }

        public override void SetLayoutHorizontal()
        {
            throw new NotImplementedException();
        }

        public override void SetLayoutVertical()
        {
            throw new NotImplementedException();
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
        }
    }
}
