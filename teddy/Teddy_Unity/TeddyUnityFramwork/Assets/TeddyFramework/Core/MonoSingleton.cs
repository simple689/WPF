using UnityEngine;

namespace Teddy {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> { // 需要使用Unity生命周期的单例模式
        protected static T _instance = null;

        public static T instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length > 1) {
                        Log.instance.print("More than 1!", LogLevel.Error);
                        return _instance;
                    }
                    if (_instance == null) {
                        string instanceName = typeof(T).Name;
                        Log.instance.print("Instance Name: " + instanceName);
                        GameObject instanceGameObject = GameObject.Find(instanceName);
                        if (instanceGameObject == null) {
                            instanceGameObject = new GameObject(instanceName);
                        }
                        _instance = instanceGameObject.AddComponent<T>();
						DontDestroyOnLoad (instanceGameObject);
                        Log.instance.print("Add New Singleton " + _instance.name + " in Game!");
                    } else {
                        Log.instance.print("Already exist: " + _instance.name, LogLevel.Warning);
                    }
                }
                return _instance;
            }
        }

        protected virtual void destroy() {
            _instance = null;
        }
    }
}