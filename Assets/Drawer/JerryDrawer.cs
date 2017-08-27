using System.Collections.Generic;
using UnityEngine;

namespace Jerry
{
    public class JerryDrawer : SingletonMono<JerryDrawer>
    {
        private static List<DrawerElementBase> _drawerList = new List<DrawerElementBase>();
        private List<DrawerElementBase> _listToDelete = new List<DrawerElementBase>();

        protected override void Awake()
        {
            base.Awake();
            _drawerList.Clear();
            _listToDelete.Clear();
        }

        void OnDrawGizmos()
        {
            _listToDelete.Clear();
            for (int i = 0, imax = _drawerList.Count; i < imax; i++)
            {
                if (_drawerList[i] == null)
                {
                    _listToDelete.Add(_drawerList[i]);
                }
                else if (_drawerList[i].Live() == false)
                {
                    _listToDelete.Add(_drawerList[i]);
                }
            }
            for (int i = 0, imax = _listToDelete.Count; i < imax; i++)
            {
                if (_listToDelete[i] != null
                    && _listToDelete[i].gameObject != null)
                {
                    GameObject.DestroyObject(_listToDelete[i].gameObject);
                }
                Remove(_listToDelete[i]);
            }
        }

        #region 对外接口

        public static T Draw<T>(string id = "") where T : DrawerElementBase
        {
            T ret = null;
            if (!string.IsNullOrEmpty(id))
            {
                ret = GetElement<T>(id);
            }

            if (ret == null)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                go.transform.SetParent(Inst.transform);
                ret = go.AddComponent<T>();
                ret.SetID(id);
                go.transform.position = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;
                go.transform.localScale = Vector3.one;
                _drawerList.Add(ret);
            }
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
    }
}