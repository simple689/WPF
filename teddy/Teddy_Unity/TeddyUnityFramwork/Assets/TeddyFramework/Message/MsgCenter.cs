using UnityEngine;
using System.Collections;

namespace Teddy {
    public class MsgCenter : MonoSingleton<MsgCenter> {
        void awake() {
            DontDestroyOnLoad(this);
        }

        public IEnumerator init() {
            Log.instance.print("MsgCenter Init");
            yield return null;
        }

        public void sendToMsg(Msg tmpMsg) {
            forwardMsg(tmpMsg);
        }

        private void forwardMsg(Msg msg) { // 转发消息
            MgrID tmpId = msg.GetMgrID();
            switch (tmpId) {
                case MgrID.AB:
                break;
                case MgrID.Sound:
                break;
                case MgrID.CharactorManager:
                break;
                case MgrID.Game:
                break;
                case MgrID.NetManager:
                break;
                case MgrID.NPCManager:
                break;
                case MgrID.UI:
                break;
                default:
                break;
            }
        }
    }
}