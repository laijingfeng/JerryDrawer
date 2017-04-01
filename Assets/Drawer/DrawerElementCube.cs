using UnityEngine;

namespace Jerry
{
    public class DrawerElementCube : DrawerElementBase
    {
        public Transform _tfPos;
        public Vector3 _pos;
        public Vector3 _size;
        public float _sizeFactor;
        public bool _wire;
        /// <summary>
        /// 点使用Vector而不是Transform
        /// </summary>
        public bool _useVectorPoint;

        public DrawerElementCube()
            : base()
        {
            _tfPos = null;
            _pos = Vector3.zero;
            _sizeFactor = 1f;
            _wire = false;
            _size = Vector3.one;
            _useVectorPoint = false;
        }

        #region 对外接口

        public virtual DrawerElementCube SetPos(Transform tfPos)
        {
            _tfPos = tfPos;
            _useVectorPoint = false;
            return this;
        }

        public virtual DrawerElementCube SetPos(Vector3 pos)
        {
            _pos = pos;
            _useVectorPoint = true;
            return this;
        }

        public virtual DrawerElementCube SetWire(bool wire)
        {
            _wire = wire;
            return this;
        }

        public virtual DrawerElementCube SetSize(Vector3 size)
        {
            _size = size;
            return this;
        }

        public virtual DrawerElementCube SetSizeFactor(float sizeFactor)
        {
            _sizeFactor = sizeFactor;
            return this;
        }

        public virtual new DrawerElementCube SetID(string id)
        {
            return base.SetID(id) as DrawerElementCube;
        }

        public virtual new DrawerElementCube SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementCube;
        }

        public virtual new DrawerElementCube SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementCube;
        }

        public virtual new DrawerElementCube SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementCube;
        }

        public virtual new DrawerElementCube SetOnlyDrawSelected(bool onlyDrawSelected)
        {
            return base.SetExecuteInEditMode(onlyDrawSelected) as DrawerElementCube;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            Gizmos.color = _color;

            if (_wire)
            {
                if (_useVectorPoint == false && _tfPos != null)
                {
                    Gizmos.DrawWireCube(_tfPos.position, _size * _sizeFactor);
                }
                else
                {
                    Gizmos.DrawWireCube(_pos, _size * _sizeFactor);
                }
            }
            else
            {
                if (_useVectorPoint == false && _tfPos != null)
                {
                    Gizmos.DrawCube(_tfPos.position, _size * _sizeFactor);
                }
                else
                {
                    Gizmos.DrawCube(_pos, _size * _sizeFactor);
                }
            }

            Gizmos.color = Color.white;

            return true;
        }
    }
}