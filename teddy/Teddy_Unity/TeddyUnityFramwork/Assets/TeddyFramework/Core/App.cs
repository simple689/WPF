using UnityEngine;
using System.Collections;

namespace Teddy {
    public class App : MonoSingleton<App> { // 全局唯一继承于MonoBehaviour的单例类，保证其他公共模块都以App的生命周期为准
        public enum AppMode {
            Developing, // 开发版本,为了快速快发,而写的测试入口。
            QA, // QualityAssurance出包/真机阶段
            Release // 发布版本,跑整个游戏
        }
        public AppMode _appMode = AppMode.Developing;

        public delegate void LifeCircleCallback(); // 全局生命周期回调
        public LifeCircleCallback _onUpdate = delegate { };
        public LifeCircleCallback _onFixedUpdate = delegate { };
        public LifeCircleCallback _onLatedUpdate = delegate { };
        public LifeCircleCallback _onGUI = delegate { };
        public LifeCircleCallback _onDestroy = delegate { };
        public LifeCircleCallback _onApplicationQuit = delegate { };

        private App() {
        }

        IEnumerator Start() {
            //var log = Log.instance;

            yield return Framework.Init();

            switch (App.instance._appMode) {
                case AppMode.Developing: {
                    //yield return GetComponent<ITestEntry>().Launch();
                    break;
                }
                case AppMode.Release: {
                    //yield return GameManager.Instance.Launch();
                    break;
                }
            }
        }

        void Update() {
            if (_onUpdate != null) {
                _onUpdate();
            }
        }

        void FixedUpdate() {
            if (_onFixedUpdate != null) {
                _onFixedUpdate();
            }
        }

        void LatedUpdate() {
            if (_onLatedUpdate != null) {
                _onLatedUpdate();
            }
        }

        void OnGUI() {
            if (_onGUI != null) {
                _onGUI();
            }
        }

        protected void OnDestroy() {
            if (_onDestroy != null) {
                _onDestroy();
            }
        }

        void OnApplicationQuit() {
            if (_onApplicationQuit != null) {
                _onApplicationQuit();
            }
        }

        void Awake() {
            DontDestroyOnLoad(gameObject); // 确保不被销毁
            Application.targetFrameRate = 60; // 进入欢迎界面
        }
    }
}