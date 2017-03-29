using UnityEngine;

namespace Teddy {
    public class MsgReceiver : MonoBehaviour, IMsgReceiver { // 1.接收者需要实现IMsgReceiver接口。2.使用this.RegisterLogicMsg注册消息和回调函数。
        void Awake() {
            //registerLogicMsg("Receiver Show Sth", ReceiverMsg);

        }

        void receiverMsg(params object[] paramList) {
            foreach (var sth in paramList) {
                Log.instance.print(sth.ToString(), LogLevel.Warning);
            }
        }
    }
}