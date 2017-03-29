using UnityEngine;
using Teddy;

public class testMsg : MonoBehaviour, IMsgReceiver, IMsgSender {
    public const string RECEIVE_MSG_FROM_OTHER_OBJECT = "ReceiveMsgFromOtherObject";

	void Start () {
	}
	
	void Update () {
	}

    void Awake() {
        Log.instance.print("Test");

        MsgDispatcher.instance.registerMsgGlobal(this, RECEIVE_MSG_FROM_OTHER_OBJECT, delegate (object[] paramList) { // 接收消息，需要实现IMsgReceiver接口
            Log.instance.print("ReceiveMsg");
            foreach (object msgContentItem in paramList) {
                Debug.Log(msgContentItem);
            }
        });

        MsgDispatcher.instance.registerMsgByChannel(this, MsgChannel.UI, RECEIVE_MSG_FROM_OTHER_OBJECT, delegate (object[] paramList) {
            Log.instance.print("这里接收不到消息,因为通道不一样");
        });
    }

    /// <summary>
    /// 发送消息
    /// 需要实现IMsgSender接口
    /// </summary>
    void OnGUI() {
        if (GUI.Button(new Rect(200, 200, 200, 100), "Send Msg")) {
            MsgDispatcher.instance.sendMsgGlobal(this, RECEIVE_MSG_FROM_OTHER_OBJECT, new object[] { "1", "2", 123 });
        }
    }


    void OnDestroy() {
        MsgDispatcher.instance.unRegisterMsgGlobal(this, RECEIVE_MSG_FROM_OTHER_OBJECT);
        MsgDispatcher.instance.unRegisterMsgByChannel(this, MsgChannel.UI, RECEIVE_MSG_FROM_OTHER_OBJECT);
    }
}
