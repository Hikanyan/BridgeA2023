using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// �m�[�c�̓���
    /// </summary>
    public class Notes : MonoBehaviour
    {
        public bool Visible => _visible;
        private bool _visible;

        /// <summary>
        /// �����Ă�m�[�c��\������
        /// </summary>
        /// <param name="visible"></param>
        public void SetVisible(bool visible)

        {
            if (visible)
            {
                gameObject.SetActive(true);
                _visible = true;
            }
            else
            {
                gameObject.SetActive(false);
                _visible = false;
            }
        }
        /// <summary>
        /// �m�[�c�𓮂���
        /// </summary>
        /// <param name="pos">x���W</param>
        public void SetNotesPos(float pos)
        {
            transform.position = new Vector3(pos, 0, 0);
        }
    }
}