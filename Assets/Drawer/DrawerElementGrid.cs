using UnityEngine;

namespace Jerry
{
    /// <summary>
    /// 平面网格
    /// </summary>
    public class DrawerElementGrid : DrawerElementBase
    {
        /// <summary>
        /// 左下角位置，只有Global的时候有效
        /// </summary>
        public Vector3 _minPos;

        /// <summary>
        /// 尺寸大小，几个格子大小，整数
        /// </summary>
        public Vector2 _size;

        /// <summary>
        /// 格子大小
        /// </summary>
        public Vector2 _gridSize;

        public PlaneType _plane;
        public CoordinateType _coordinate;

        public enum CoordinateType
        {
            Global = 0,
            Local,
        }

        /// <summary>
        /// 平面类型
        /// </summary>
        public enum PlaneType
        {
            XY = 0,
            XZ,
            ZY,
        }

        public DrawerElementGrid()
            : base()
        {
            _minPos = Vector3.zero;
            _gridSize = Vector3.zero;
            _size = Vector3.zero;
            _plane = PlaneType.XY;
            _coordinate = CoordinateType.Global;
        }

        #region 对外接口

        public DrawerElementGrid SetMinPos(Vector3 pos)
        {
            _minPos = pos;
            return this;
        }

        public DrawerElementGrid SetSize(Vector2 size)
        {
            _size = size;
            return this;
        }

        public DrawerElementGrid SetGridSize(Vector2 gridSize)
        {
            _gridSize = gridSize;
            return this;
        }

        public DrawerElementGrid SetPlaneType(PlaneType plane)
        {
            _plane = plane;
            return this;
        }

        public DrawerElementGrid SetCoordinateType(CoordinateType coordinate)
        {
            _coordinate = coordinate;
            return this;
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

            for (int i = 0; i <= _size.x; i++)
            {
                //竖线
                Gizmos.DrawLine(XY2PlaneXYZ(new Vector2(i * _gridSize.x, 0)),
                    XY2PlaneXYZ(new Vector2(i * _gridSize.x, _size.y * _gridSize.y)));
            }

            for (int i = 0; i <= _size.y; i++)
            {
                //横线
                Gizmos.DrawLine(XY2PlaneXYZ(new Vector2(0, i * _gridSize.y)),
                    XY2PlaneXYZ(new Vector2(_size.x * _gridSize.x, i * _gridSize.y)));
            }

            Gizmos.color = Color.white;
            return true;
        }

        private Vector3 XY2PlaneXYZ(Vector3 pos)
        {
            switch (_plane)
            {
                case PlaneType.XY:
                    {
                        //no change
                    }
                    break;
                case PlaneType.XZ:
                    {
                        pos.z = pos.y;
                        pos.y = 0;
                    }
                    break;
                case PlaneType.ZY:
                    {
                        pos.z = pos.x;
                        pos.x = 0;
                    }
                    break;
            }
            if (_coordinate == CoordinateType.Local)
            {
                return this.transform.position
                    + this.transform.right * pos.x
                    + this.transform.up * pos.y
                    + this.transform.forward * pos.z;
            }
            return _minPos + pos;
        }
    }
}