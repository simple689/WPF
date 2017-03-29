using System.Collections;

namespace Teddy {
    public class Framework : BehaviourManager {
        protected override void SetupMgrId() {
            mMgrId = 0;
        }

        protected override void SetupMgr() {

        }

        public static IEnumerator Init() {
            yield return MsgCenter.instance.init();

            //-----------------初始化管理器-----------------------
            //var a = TimerMgr.Instance;
            //var b = SoundMgr.Instance;
            //var c = ResourceManager.Instance;
            //var f = GameManager.Instance;
        }
    }
}
