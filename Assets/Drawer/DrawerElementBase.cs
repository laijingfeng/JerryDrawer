using UnityEngine;

namespace Jerry
{
    public abstract class DrawerElementBase : MonoBehaviour
    {
        /// <summary>
        /// id
        /// </summary>
        protected string _id;

        /// <summary>
        /// 创建时间
        /// </summary>
        protected float _createTime;

        /// <summary>
        /// 生命周期，小于等于0表示无穷，单位秒
        /// </summary>
        public float _life;

        /// <summary>
        /// 颜色
        /// </summary>
        public Color _color;

        /// <summary>
        /// 是否支持编辑器运行
        /// </summary>
        public bool _executeInEditMode;

        /// <summary>
        /// 点使用Vector而不是Transform
        /// </summary>
        public bool _useVectorPoint;

        public DrawerElementBase()
        {
            _id = string.Empty;
            _life = 0f;
            _color = Color.white;
            _executeInEditMode = false;
            _useVectorPoint = true;
        }

        void Awake()
        {
            _createTime = Time.realtimeSinceStartup;
        }

        /// <summary>
        /// 为了脚本可以在Inspector开关
        /// </summary>
        void Start()
        {
        }

        void OnDrawGizmos()
        {
            if (Live())
            {
                Draw();
            }
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
        /// 是否存活
        /// </summary>
        /// <returns></returns>
        public virtual bool Live()
        {
            if (_life > 0 && Time.realtimeSinceStartup - _createTime > _life)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <returns>是否继续往子类传递</returns>
        public virtual bool Draw()
        {
            if (Live() == false)
            {
                return false;
            }
            if (IsExecuteInEditMode == false
                && Application.isPlaying == false)
            {
                return false;
            }
            return true;
        }
    }
}