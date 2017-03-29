using UnityEngine;
//using UnityEngine.EventSystems;

namespace Teddy {
    public class VoidDelegate { // 返回空类型的回调定义
        public delegate void withVoid();
        public delegate void withBool(bool value);
        public delegate void withGo(GameObject go);
        public delegate void withObj(Object obj);
        public delegate void withParams(params object[] paramList);
        //public delegate void withEvent(BaseEventData data);
    }
}