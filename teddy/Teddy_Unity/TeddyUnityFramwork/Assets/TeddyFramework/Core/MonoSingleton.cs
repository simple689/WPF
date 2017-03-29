using UnityEngine;

namespace Teddy {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> { // 需要使用Unity生命周期的单例模式
        protected static T _instance = null;

        public static T instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length > 1) {
                        Debug.LogError("More than 1!");
                        return _instance;
                    }
                    if (_instance == null) {
                        string instanceName = typeof(T).Name;
                        Debug.Log("Instance Name: " + instanceName);
                        GameObject instanceGameObject = GameObject.Find(instanceName);
                        if (instanceGameObject == null) {
                            instanceGameObject = new GameObject(instanceName);
                        }
                        _instance = instanceGameObject.AddComponent<T>();
						DontDestroyOnLoad (instanceGameObject);
                        Debug.Log("Add New Singleton " + _instance.name + " in Game!");
                    } else {
                        Debug.LogWarning("Already exist: " + _instance.name);
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