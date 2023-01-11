using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// ノーツの動き
    /// </summary>
    public class Notes : MonoBehaviour
    {
        public bool Visible => _visible;
        private bool _visible;

        /// <summary>
        /// 見えてるノーツを表示する
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
        /// ノーツを動かす
        /// </summary>
        /// <param name="pos">x座標</param>
        public void SetNotesPos(float pos)
        {
            transform.position = new Vector3(pos, 0, 0);
        }
    }
}