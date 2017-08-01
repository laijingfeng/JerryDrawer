using System.Collections.Generic;
using UnityEngine;

namespace Jerry
{
    public class DrawerElementBoxCollider : DrawerElementBase
    {
        public BoxCollider _target;
        public DrawType _drawType;

        public enum DrawType
        {
            None = 0,
            Edge,
            Surf,
            All,
        }

        public DrawerElementBoxCollider()
            : base()
        {
            _target = null;
            _drawType = DrawType.Edge;
        }

        #region 对外接口

        public virtual DrawerElementBoxCollider SetTarget(BoxCollider target)
        {
            _target = target;
            return this;
        }

        public virtual DrawerElementBoxCollider SetDrawType(DrawType drawType)
        {
            _drawType = drawType;
            return this;
        }

        public virtual new DrawerElementBoxCollider SetID(string id)
        {
            return base.SetID(id) as DrawerElementBoxCollider;
        }

        public virtual new DrawerElementBoxCollider SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementBoxCollider;
        }

        public virtual new DrawerElementBoxCollider SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementBoxCollider;
        }

        public virtual new DrawerElementBoxCollider SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementBoxCollider;
        }

        public virtual new DrawerElementBoxCollider SetOnlyDrawSelected(bool onlyDrawSelected)
        {
            return base.SetExecuteInEditMode(onlyDrawSelected) as DrawerElementBoxCollider;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            Gizmos.color = _color;
            DoDraw();
            Gizmos.color = Color.white;

            return true;
        }

        private void DoDraw()
        {
            if (_target == null
                || _target.transform == null)
            {
                return;
            }

            Vector3 s = _target.transform.lossyScale;
            s.x *= _target.size.x;
            s.y *= _target.size.y;
            s.z *= _target.size.z;
            Vector3 p = _target.transform.position + _target.center;

            List<Vector3> posOnBox = new List<Vector3>();
            Vector3 one = Vector3.zero;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        one = p
                            + _target.transform.up.normalized * s.y * 0.5f * (1 - 2 * i)
                            + _target.transform.right.normalized * s.x * 0.5f * (1 - 2 * j)
                            + _target.transform.forward.normalized * s.z * 0.5f * (1 - 2 * k);
                        posOnBox.Add(one);
                    }
                }
            }

            for (int i = 0, imax = posOnBox.Count; i < imax; i++)
            {
                for (int j = 0; j < imax; j++)
                {
                    if (i != j
                        && NeedDraw(posOnBox[i], posOnBox[j]))
                    {
                        Gizmos.DrawLine(posOnBox[i], posOnBox[j]);
                    }
                }
            }
        }

        private bool NeedDraw(Vector3 a, Vector3 b)
        {
            if (_drawType == DrawType.All)
            {
                return true;
            }
            else if (_drawType == DrawType.None)
            {
                return false;
            }

            int cnt = 0;
            if (Mathf.Approximately(a.x, b.x))
            {
                cnt++;
            }
            if (Mathf.Approximately(a.y, b.y))
            {
                cnt++;
            }
            if (Mathf.Approximately(a.z, b.z))
            {
                cnt++;
            }
            if (_drawType == DrawType.Edge)
            {
                if (cnt == 2)
                {
                    return true;
                }
            }
            else if (_drawType == DrawType.Surf)
            {
                if (cnt >= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}