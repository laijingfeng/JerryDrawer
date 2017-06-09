using UnityEngine;
using System.Collections.Generic;

namespace Jerry
{
    /// <summary>
    /// 平面网格
    /// </summary>
    public class DrawerElementGrid : DrawerElementBase
    {
        /// <summary>
        /// 左下角位置
        /// </summary>
        public Vector3 _minPos;

        /// <summary>
        /// 大小
        /// </summary>
        public Vector3 _size;

        /// <summary>
        /// 格子大小
        /// </summary>
        public Vector3 _gridSize;

        public DrawerElementGrid()
            : base()
        {
            _minPos = Vector3.zero;
            _gridSize = Vector3.zero;
            _size = Vector3.zero;
        }

        #region 对外接口

        public DrawerElementGrid SetMinPos(Vector3 pos)
        {
            _minPos = pos;
            return this;
        }

        public DrawerElementGrid SetSize(Vector3 size)
        {
            _size = size;
            return this;
        }

        public DrawerElementGrid SetGridSize(Vector3 gridSize)
        {
            _gridSize = gridSize;
            return this;
        }

        public virtual new DrawerElementGrid SetID(string id)
        {
            return base.SetID(id) as DrawerElementGrid;
        }

        public virtual new DrawerElementGrid SetColor(Color col)
        {
            return base.SetColor(col) as DrawerElementGrid;
        }

        public virtual new DrawerElementGrid SetLife(float time)
        {
            return base.SetLife(time) as DrawerElementGrid;
        }

        public virtual new DrawerElementGrid SetExecuteInEditMode(bool executeInEditMode)
        {
            return base.SetExecuteInEditMode(executeInEditMode) as DrawerElementGrid;
        }

        public virtual new DrawerElementGrid SetOnlyDrawSelected(bool onlyDrawSelected)
        {
            return base.SetExecuteInEditMode(onlyDrawSelected) as DrawerElementGrid;
        }

        #endregion 对外接口

        public override bool Draw()
        {
            if (base.Draw() == false)
            {
                return false;
            }

            Gizmos.color = _color;

            if (_size.x > 0 && _size.y > 0)
            {
                for (int i = 0; i <= _size.x; i++)
                {
                    //竖线
                    Gizmos.DrawLine(_minPos + new Vector3(i * _gridSize.x, 0, 0),
                        _minPos + new Vector3(i * _gridSize.x, _size.y * _gridSize.y, 0));
                }

                for (int i = 0; i <= _size.y; i++)
                {
                    //横线
                    Gizmos.DrawLine(_minPos + new Vector3(0, i * _gridSize.y, 0),
                        _minPos + new Vector3(_size.x * _gridSize.x, i * _gridSize.y, 0));
                }
            }
            else if (_size.x > 0 && _size.z > 0)
            {
                for (int i = 0; i <= _size.x; i++)
                {
                    //竖线
                    Gizmos.DrawLine(_minPos + new Vector3(i * _gridSize.x, 0, 0),
                        _minPos + new Vector3(i * _gridSize.x, 0, _size.z * _gridSize.z));
                }

                for (int i = 0; i <= _size.z; i++)
                {
                    //横线
                    Gizmos.DrawLine(_minPos + new Vector3(0, 0, i * _gridSize.z),
                        _minPos + new Vector3(_size.x * _gridSize.x, 0, i * _gridSize.z));
                }
            }
            else if (_size.z > 0 && _size.y > 0)
            {
                for (int i = 0; i <= _size.z; i++)
                {
                    //竖线
                    Gizmos.DrawLine(_minPos + new Vector3(0, 0, i * _gridSize.z),
                        _minPos + new Vector3(0, _size.y * _gridSize.y, i * _gridSize.z));
                }

                for (int i = 0; i <= _size.y; i++)
                {
                    //横线
                    Gizmos.DrawLine(_minPos + new Vector3(0, i * _gridSize.y, 0),
                        _minPos + new Vector3(0, i * _gridSize.y, _size.z * _gridSize.z));
                }
            }
            
            Gizmos.color = Color.white;
            return true;
        }
    }
}