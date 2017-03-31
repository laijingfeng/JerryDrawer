using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Jerry
{
    /// <summary>
    /// 注意：该组件DLL无效
    /// </summary>
    public class DrawerElementLabel : DrawerElementBase
    {
        public Transform _tfPos;
        public Vector3 _pos;
        public string _text;
        /// <summary>
        /// 点使用Vector而不是Transform
        /// </summary>
        private bool _useVectorPoint;

        public DrawerElementLabel()
            : base()
        {
            _pos = Vector3.zero;
            _text = string.Empty;
            _useVectorPoint = true;
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

        /// <summary>
        /// 注意：该组件DLL无效
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual DrawerElementLabel SetText(string text)
        {
            _text = text;
            return this;
        }

        public virtual new DrawerElementLabel SetID(string id)
        {
            return base.SetID(id) as DrawerElementLabel;
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
            if (_useVectorPoint == false && _tfPos != null)
            {
                Handles.Label(_tfPos.position, _text);
            }
            else
            {
                Handles.Label(_pos, _text);
            }
#endif
            GUI.color = Color.white;

            return true;
        }
    }
}