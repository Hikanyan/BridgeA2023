using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// 基本的なイベント機能を提供する基本クラス。
    /// </summary>

    public abstract class AbstractGameEvent : ScriptableObject
    {
        readonly List<IGameEventListener> _eventListeners = new();
        /// <summary>
        /// 現在のイベントのインスタンスをトリガーにし、
        /// サブスクライバーに通知します。
        /// </summary>
        public void Raise()
        {
            for(int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised();
            }
            Reset();
        }
        /// <summary>
        /// このイベントのオブザーバーのリストにクラスを追加します。
        /// </summary>
        /// <param name="listener">このイベントを監視したいクラス</param>
        public void AddListener(IGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }
        /// <summary>
        /// このイベントのオブザーバーのリストからクラスを削除します
        /// </summary>
        /// <param name="listener">このイベントを削除したいクラス</param>
        public void RemoveListener(IGameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
        public abstract void Reset();
    }
}