using UnityEngine;

namespace Teddy {
    public class MsgSender : MonoBehaviour, IMsgSender { // 1.发送者需要,实现IMsgSender接口。2.调用this.SendLogicMsg发送Receiver Show Sth消息,并传入两个参数
        void Update() {
            //sendLogicMsg("Receiver Show Sth", "你好", "世界");
        }
    }
}