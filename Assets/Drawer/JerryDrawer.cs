using UnityEngine;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Jerry
{
    [ExecuteInEditMode]
    public class JerryDrawer : SingletonMono<JerryDrawer>
    {
        private static List<DrawerElementBase> _drawerList = new List<DrawerElementBase>();
        private List<DrawerElementBase> _listToDelete = new List<DrawerElementBase>();

        #region 对外接口

        public static T Draw<T>() where T : DrawerElementBase
        {
            T ret = (T)Activator.CreateInstance(typeof(T), true);
            Add(ret);
            return ret;
        }

        public static T GetElement<T>(string id) where T : DrawerElementBase
        {
            T ele = _drawerList.Find((x) => id.Equals(x.ID)) as T;
            return ele;
        }

        public static void Remove(DrawerElementBase ele)
        {
            if (_drawerList.Contains(ele))
            {
                _drawerList.Remove(ele);
            }
        }

        public static void RemoveByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            DrawerElementBase ele = _drawerList.Find((x) => id.Equals(x.ID));
            if (ele != null)
            {
                _drawerList.Remove(ele);
            }
        }

        public static void RemoveAll()
        {
            _drawerList.Clear();
        }

        #endregion 对外接口

        private static void Add(DrawerElementBase ele)
        {
            if (ele == null)
            {
                return;
            }

            //只是为了创建一下
            Inst.GetComponent<Transform>();
            
            Remove(ele);
            _drawerList.Add(ele);
        }

        void OnDrawGizmos()
        {
            _listToDelete.Clear();
            for (int i = 0, imax = _drawerList.Count; i < imax; i++)
            {
                if(_drawerList[i].IsExecuteInEditMode == false
                    && Application.isPlaying == false)
                {
                    continue;
                }

                if (_drawerList[i].Draw() == false)
                {
                    _listToDelete.Add(_drawerList[i]);
                }
            }
            for (int i = 0, imax = _listToDelete.Count; i < imax; i++)
            {
                Remove(_listToDelete[i]);
            }
        }
    }

    public class DrawerElementPath : DrawerElementBase
    {
        protected Vector3[] _points;
        protected Transform[] _tfPoints;
        
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

    public class DrawerElementCube : DrawerElementBase
    {
        protected Transform _tfPos;
        protected Vector3 _pos;
        protected Vector3 _size;
        protected float _sizeFactor;
        protected bool _wire;

        public DrawerElementCube()
            : base()
        {
            _tfPos = null;
            _pos = Vector3.zero;
            _sizeFactor = 1f;
            _wire = false;
            _size = Vector3.one;
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

    public class DrawerElementLabel : DrawerElementBase
    {
        protected Transform _tfPos;
        protected Vector3 _pos;
        protected string _text;

        public DrawerElementLabel()
            : base()
        {
            _pos = Vector3.zero;
            _text = string.Empty;
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

    public abstract class DrawerElementBase
    {
        /// <summary>
        /// id
        /// </summary>
        protected string _id;

        /// <summary>
        /// 生命周期，小于等于0表示无穷，单位秒
        /// </summary>
        protected float _life;

        /// <summary>
        /// 颜色
        /// </summary>
        protected Color _color;

        /// <summary>
        /// 创建时间
        /// </summary>
        protected float _createTime;

        protected bool _executeInEditMode;

        /// <summary>
        /// 点使用Vector而不是Transform
        /// </summary>
        protected bool _useVectorPoint;

        public DrawerElementBase()
        {
            _id = string.Empty;
            _life = 0f;
            _color = Color.white;
            _createTime = Time.realtimeSinceStartup;
            _executeInEditMode = false;
            _useVectorPoint = true;
        }

        #region 对外接口

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public bool IsExecuteInEditMode
        {
            get
            {
                return _executeInEditMode;
            }
        }

        /// <summary>
        /// 编辑器模式可用
        /// </summary>
        /// <param name="executeInEditMode"></param>
        /// <returns></returns>
        public virtual DrawerElementBase SetExecuteInEditMode(bool executeInEditMode)
        {
            _executeInEditMode = executeInEditMode;
            return this;
        }

        public virtual DrawerElementBase SetID(string id)
        {
            _id = id;
            return this;
        }

        public virtual DrawerElementBase SetLife(float time)
        {
            _createTime = Time.realtimeSinceStartup;
            _life = time;
            return this;
        }

        public virtual DrawerElementBase SetColor(Color col)
        {
            _color = col;
            return this;
        }

        #endregion 对外接口

        /// <summary>
        /// 绘制
        /// </summary>
        /// <returns>是否还有效</returns>
        public virtual bool Draw()
        {
            if (_life > 0 && Time.realtimeSinceStartup - _createTime > _life)
            {
                return false;
            }
            return true;
        }
    }
}