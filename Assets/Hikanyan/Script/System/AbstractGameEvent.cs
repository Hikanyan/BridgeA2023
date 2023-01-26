using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// ��{�I�ȃC�x���g�@�\��񋟂����{�N���X�B
    /// </summary>

    public abstract class AbstractGameEvent : ScriptableObject
    {
        readonly List<IGameEventListener> _eventListeners = new();
        /// <summary>
        /// ���݂̃C�x���g�̃C���X�^���X���g���K�[�ɂ��A
        /// �T�u�X�N���C�o�[�ɒʒm���܂��B
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
        /// ���̃C�x���g�̃I�u�U�[�o�[�̃��X�g�ɃN���X��ǉ����܂��B
        /// </summary>
        /// <param name="listener">���̃C�x���g���Ď��������N���X</param>
        public void AddListener(IGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }
        /// <summary>
        /// ���̃C�x���g�̃I�u�U�[�o�[�̃��X�g����N���X���폜���܂�
        /// </summary>
        /// <param name="listener">���̃C�x���g���폜�������N���X</param>
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