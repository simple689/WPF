using UnityEngine;
using System.Collections.Generic;
using System;

namespace Teddy {
    public enum MsgChannel {
        Global, // 全局
        UI,
        Logic,
    }

    public static class MsgDispatcher { // 消息分发器。C# this扩展 需要静态类
        static Dictionary<MsgChannel, Dictionary<string, List<MsgHandler>>> _msgHandlerDict = new Dictionary<MsgChannel, Dictionary<string, List<MsgHandler>>>(); // 每个消息名字维护一组消息捕捉器。

        public static void RegisterGlobalMsg(this IMsgReceiver self, string msgName, VoidDelegate.withParams callback) {// 注册消息,注意第一个参数,使用了C# this的扩展,所以只有实现IMsgReceiver的对象才能调用此方法
            if (string.IsNullOrEmpty(msgName)) {
                Debug.LogError("RegisterMsg:" + msgName + " is Null or Empty");
                return;
            }

            // 略过
            if (null == callback) {
                Debug.LogError("RegisterMsg:" + msgName + " callback is Null");
                return;
            }

            // 添加消息通道
            if (!_msgHandlerDict.ContainsKey(MsgChannel.Global)) {
                _msgHandlerDict[MsgChannel.Global] = new Dictionary<string, List<MsgHandler>>();
            }

            // 略过
            if (!_msgHandlerDict[MsgChannel.Global].ContainsKey(msgName)) {
                _msgHandlerDict[MsgChannel.Global][msgName] = new List<MsgHandler>();
            }

            // 看下这里
            var handlers = _msgHandlerDict[MsgChannel.Global][msgName];

            // 略过
            // 防止重复注册
            foreach (var handler in handlers) {
                if (handler._receiver == self && handler._callback == callback) {
                    Debug.LogWarning("RegisterMsg:" + msgName + " ayready Register");
                    return;
                }
            }

            // 再看下这里
            handlers.Add(new MsgHandler(self, callback));
        }

        /// <summary>
        /// 注册消息,
        /// 注意第一个参数,使用了C# this的扩展,
        /// 所以只有实现IMsgReceiver的对象才能调用此方法
        /// </summary>
        public static void RegisterMsgByChannel(this IMsgReceiver self, MsgChannel channel, string msgName, VoidDelegate.withParams callback) {
            // 略过
            if (string.IsNullOrEmpty(msgName)) {
                Debug.LogError("RegisterMsg:" + msgName + " is Null or Empty");
                return;
            }

            // 略过
            if (null == callback) {
                Debug.LogError("RegisterMsg:" + msgName + " callback is Null");
                return;
            }

            // 添加消息通道
            if (!_msgHandlerDict.ContainsKey(channel)) {
                _msgHandlerDict[channel] = new Dictionary<string, List<MsgHandler>>();
            }

            // 略过
            if (!_msgHandlerDict[channel].ContainsKey(msgName)) {
                _msgHandlerDict[channel][msgName] = new List<MsgHandler>();
            }

            // 看下这里
            var handlers = _msgHandlerDict[channel][msgName];

            // 略过
            // 防止重复注册
            foreach (var handler in handlers) {
                if (handler._receiver == self && handler._callback == callback) {
                    Debug.LogWarning("RegisterMsg:" + msgName + " ayready Register");
                    return;
                }
            }

            // 再看下这里
            handlers.Add(new MsgHandler(self, callback));
        }


        /// <summary>
        /// 其实注销消息只需要Object和Go就足够了 不需要callback
        /// </summary>
        public static void UnRegisterGlobalMsg(this IMsgReceiver self, string msgName) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(MsgChannel.Global)) {
                Debug.LogError("Channel:" + MsgChannel.Global.ToString() + " doesn't exist");
                return;
            }

            var handlers = _msgHandlerDict[MsgChannel.Global][msgName];

            int handlerCount = handlers.Count;

            // 删除List需要从后向前遍历
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];
                if (handler._receiver == self) {
                    handlers.Remove(handler);
                    break;
                }
            }
        }

        /// <summary>
        /// 其实注销消息只需要Object和Go就足够了 不需要callback
        /// </summary>
        public static void UnRegisterMsgByChannel(this IMsgReceiver self, MsgChannel channel, string msgName) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(channel)) {
                Debug.LogError("Channel:" + channel.ToString() + " doesn't exist");
                return;
            }

            var handlers = _msgHandlerDict[channel][msgName];

            int handlerCount = handlers.Count;

            // 删除List需要从后向前遍历
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];
                if (handler._receiver == self) {
                    handlers.Remove(handler);
                    break;
                }
            }
        }


        static bool CheckStrNullOrEmpty(string str) {
            if (string.IsNullOrEmpty(str)) {
                Debug.LogWarning("str is Null or Empty");
                return true;
            }
            return false;
        }

        static bool CheckDelegateNull(VoidDelegate.withParams callback) {
            if (null == callback) {
                Debug.LogWarning("callback is Null");

                return true;
            }
            return false;
        }

        /// <summary>
        /// 发送消息
        /// 注意第一个参数
        /// </summary>
        public static void SendGlobalMsg(this IMsgSender sender, string msgName, params object[] paramList) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(MsgChannel.Global)) {
                Debug.LogError("Channel:" + MsgChannel.Global.ToString() + " doesn't exist");
                return;
            }

            // 略过,不用看
            if (!_msgHandlerDict[MsgChannel.Global].ContainsKey(msgName)) {
                Debug.LogError(msgName + " UnRegistered");
                return;
            }

            // 开始看!!!!
            var handlers = _msgHandlerDict[MsgChannel.Global][msgName];

            var handlerCount = handlers.Count;

            // 之所以是从后向前遍历,是因为  从前向后遍历删除后索引值会不断变化
            // 参考文章,http://www.2cto.com/kf/201312/266723.html
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];

                if (handler._receiver != null) {
                    handler._callback(paramList);
                } else {
                    handlers.Remove(handler);
                }
            }
        }

        public static void SendMsgByChannel(this IMsgSender sender, MsgChannel channel, string msgName, params object[] paramList) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(channel)) {
                Debug.LogError("Channel:" + channel.ToString() + " doesn't exist");
                return;
            }

            // 略过,不用看
            if (!_msgHandlerDict[channel].ContainsKey(msgName)) {
                Debug.LogWarning("SendMsg is UnRegister");
                return;
            }

            // 开始看!!!!
            var handlers = _msgHandlerDict[channel][msgName];

            var handlerCount = handlers.Count;

            // 之所以是从后向前遍历,是因为  从前向后遍历删除后索引值会不断变化
            // 参考文章,http://www.2cto.com/kf/201312/266723.html
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];

                if (handler._receiver != null) {
                    Debug.Log("SendLogicMsg:" + msgName + " Succeed");
                    handler._callback(paramList);
                } else {
                    handlers.Remove(handler);
                }
            }
        }

        [Obsolete("RegisterLogicMsg已经弃用了,请使用RegisterGlobalMsg")]
        public static void RegisterLogicMsg(this IMsgReceiver self, string msgName, VoidDelegate.withParams callback, MsgChannel channel = MsgChannel.Global) {
            if (CheckStrNullOrEmpty(msgName) || CheckDelegateNull(callback)) {
                return;
            }

            // 添加消息通道
            if (!_msgHandlerDict.ContainsKey(channel)) {
                _msgHandlerDict[channel] = new Dictionary<string, List<MsgHandler>>();
            }

            // 略过
            if (!_msgHandlerDict[channel].ContainsKey(msgName)) {
                _msgHandlerDict[channel][msgName] = new List<MsgHandler>();
            }

            // 看下这里
            var handlers = _msgHandlerDict[channel][msgName];

            // 略过
            // 防止重复注册
            foreach (var handler in handlers) {
                if (handler._receiver == self && handler._callback == callback) {
                    Debug.LogWarning("RegisterMsg:" + msgName + " ayready Register");
                    return;
                }
            }

            // 再看下这里
            handlers.Add(new MsgHandler(self, callback));
        }


        [Obsolete("SendLogicMsg已经弃用了,请使用使用SendGlobalMsg或SendMsgByChannel")]
        public static void SendLogicMsg(this IMsgSender sender, string msgName, params object[] paramList) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(MsgChannel.Global)) {
                Debug.LogError("Channel:" + MsgChannel.Global.ToString() + " doesn't exist");
                return;
            }


            // 略过,不用看
            if (!_msgHandlerDict[MsgChannel.Global].ContainsKey(msgName)) {
                Debug.LogWarning("SendMsg is UnRegister");
                return;
            }

            // 开始看!!!!
            var handlers = _msgHandlerDict[MsgChannel.Global][msgName];

            var handlerCount = handlers.Count;

            // 之所以是从后向前遍历,是因为  从前向后遍历删除后索引值会不断变化
            // 参考文章,http://www.2cto.com/kf/201312/266723.html
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];

                if (handler._receiver != null) {
                    Debug.Log("SendLogicMsg:" + msgName + " Succeed");
                    handler._callback(paramList);
                } else {
                    handlers.Remove(handler);
                }
            }
        }

        [Obsolete("UnRegisterMsg已经弃用了,请使用UnRegisterMsg")]
        public static void UnRegisterMsg(this IMsgReceiver self, string msgName, VoidDelegate.withParams callback, MsgChannel channel = MsgChannel.Global) {
            if (CheckStrNullOrEmpty(msgName) || CheckDelegateNull(callback)) {
                return;
            }

            // 添加通道
            if (!_msgHandlerDict.ContainsKey(channel)) {
                Debug.LogError("Channel:" + channel.ToString() + " doesn't exist");
                return;
            }

            var handlers = _msgHandlerDict[channel][msgName];

            int handlerCount = handlers.Count;

            // 删除List需要从后向前遍历
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];
                if (handler._receiver == self && handler._callback == callback) {
                    handlers.Remove(handler);
                    break;
                }
            }
        }


        [Obsolete("UnRegisterMsg已经弃用了,请使用UnRegisterGlobalMsg")]
        public static void UnRegisterMsg(this IMsgReceiver self, string msgName) {
            if (CheckStrNullOrEmpty(msgName)) {
                return;
            }

            if (!_msgHandlerDict.ContainsKey(MsgChannel.Global)) {
                Debug.LogError("Channel:" + MsgChannel.Global.ToString() + " doesn't exist");
                return;
            }

            var handlers = _msgHandlerDict[MsgChannel.Global][msgName];

            int handlerCount = handlers.Count;

            // 删除List需要从后向前遍历
            for (int index = handlerCount - 1; index >= 0; index--) {
                var handler = handlers[index];
                if (handler._receiver == self) {
                    handlers.Remove(handler);
                    break;
                }
            }
        }
    }
}
