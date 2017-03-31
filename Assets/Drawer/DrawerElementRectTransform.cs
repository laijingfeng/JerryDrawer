using UnityEngine;
using System.Collections;

namespace Jerry
{
    public class DrawerElementRectTransform : DrawerElementBase
    {
        public Transform _target;

        private Vector3[] _fourCorners = new Vector3[4];

        public DrawerElementRectTransform()
            : base()
        {
            _target = null;
        }

        #region 对外接口

        public virtual DrawerElementRectTransform SetTarget(Transform target)
        {
            _target = target;
            return this;
        }

        public virtual new DrawerElementRectTransform SetID(string id)
        {
            return base.SetID(id) as DrawerElementRectTransform;
        }

        public virtual new DrawerElementRectTransform SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementRectTransform;
        }

        public virtual new DrawerElementRectTransform SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementRectTransform;
        }

        public virtual new DrawerElementRectTransform SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementRectTransform;
        }

        public virtual new DrawerElementRectTransform SetOnlyDrawSelected(bool onlyDrawSelected)
        {
            return base.SetExecuteInEditMode(onlyDrawSelected) as DrawerElementRectTransform;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            Gizmos.color = _color;

            RectTransform rect = null;
            if (_target != null)
            {
                rect = _target as RectTransform;
            }
            else
            {
                rect = this.transform as RectTransform;
            }

            if (rect == null)
            {
                return false;
            }

            rect.GetWorldCorners(_fourCorners);
            for (int i = 0; i < 4; i++)
            {
                Gizmos.DrawLine(_fourCorners[i], _fourCorners[(i + 1) % 4]);
            }

            Gizmos.color = Color.white;

            return true;
        }
    }
}