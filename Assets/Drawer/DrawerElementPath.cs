using UnityEngine;
using System.Collections.Generic;

namespace Jerry
{
    public class DrawerElementPath : DrawerElementBase
    {
        public Vector3[] _points;
        public Transform[] _tfPoints;

        public DrawerElementPath()
            : base()
        {
            _points = null;
            _tfPoints = null;
        }

        #region 对外接口

        public virtual DrawerElementPath SetPoints(params Transform[] tfPoints)
        {
            _tfPoints = tfPoints;
            _useVectorPoint = false;
            return this;
        }

        public virtual DrawerElementPath SetPoints(params Vector3[] points)
        {
            _points = points;
            _useVectorPoint = true;
            return this;
        }

        public virtual DrawerElementPath SetAddPoints(params Vector3[] points)
        {
            if (_points == null)
            {
                _points = points;
            }
            else
            {
                List<Vector3> tmp = new List<Vector3>();
                tmp.AddRange(_points);
                tmp.AddRange(points);
                _points = tmp.ToArray();
            }
            _useVectorPoint = true;
            return this;
        }

        public virtual new DrawerElementPath SetID(string id)
        {
            return base.SetID(id) as DrawerElementPath;
        }

        public virtual new DrawerElementPath SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementPath;
        }

        public virtual new DrawerElementPath SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementPath;
        }

        public virtual new DrawerElementPath SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementPath;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            Gizmos.color = _color;
            if (_useVectorPoint)
            {
                if (_points != null)
                {
                    for (int i = 1, imax = _points.Length; i < imax; i++)
                    {
                        Gizmos.DrawLine(_points[i - 1], _points[i]);
                    }
                }
            }
            else
            {
                if (_tfPoints != null)
                {
                    for (int i = 1, imax = _tfPoints.Length; i < imax; i++)
                    {
                        if (_tfPoints[i - 1] != null && _tfPoints[i] != null)
                        {
                            Gizmos.DrawLine(_tfPoints[i - 1].position, _tfPoints[i].position);
                        }
                    }
                }
            }
            Gizmos.color = Color.white;
            return true;
        }
    }
}