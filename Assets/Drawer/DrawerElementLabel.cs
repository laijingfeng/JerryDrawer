using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Jerry
{
    public class DrawerElementLabel : DrawerElementBase
    {
        public Transform _tfPos;
        public Vector3 _pos;
        public string _text;
        /// <summary>
        /// 点使用Vector而不是Transform
        /// </summary>
        public bool _useVectorPoint;

        public DrawerElementLabel()
            : base()
        {
            _pos = Vector3.zero;
            _text = string.Empty;
            _useVectorPoint = false;
        }

        #region 对外接口

        public virtual DrawerElementLabel SetPos(Transform tfPos)
        {
            _tfPos = tfPos;
            _useVectorPoint = false;
            return this;
        }

        public virtual DrawerElementLabel SetPos(Vector3 pos)
        {
            _pos = pos;
            _useVectorPoint = true;
            return this;
        }

        public virtual DrawerElementLabel SetText(string text)
        {
            _text = text;
            return this;
        }

        public virtual new DrawerElementLabel SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementLabel;
        }

        public virtual new DrawerElementLabel SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementLabel;
        }

        public virtual new DrawerElementLabel SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementLabel;
        }

        public virtual new DrawerElementLabel SetOnlyDrawSelected(bool onlyDrawSelected)
        {
            return base.SetExecuteInEditMode(onlyDrawSelected) as DrawerElementLabel;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            GUI.color = _color;
#if UNITY_EDITOR
            string realText = _text;
            if (string.IsNullOrEmpty(_text))
            {
                realText = this.transform.name;
            }
            if (_useVectorPoint == false && _tfPos != null)
            {
                Handles.Label(_tfPos.position, realText);
            }
            else
            {
                Handles.Label(_pos, realText);
            }
#endif
            GUI.color = Color.white;

            return true;
        }
    }
}