using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// [TODO]
    /// ノーツの動き
    /// ノーツのタイプ
    /// ノーツのレーン
    /// </summary>
    public enum NotesType
    {
        NormalNotes,
        HeelNotes,
        DamageNotes,
    } 

    public class Notes : MonoBehaviour
    {
        public bool Visible;
        public NotesType NotesType; 

        /// <summary>
        /// 見えてるノーツを表示する
        /// </summary>
        /// <param name="visible"></param>
        public void SetVisible(bool visible)

        {
            if (visible)
            {
                gameObject.SetActive(true);
                Visible = true;
            }
            else
            {
                gameObject.SetActive(false);
                Visible = false;
                transform.position = new(0, 0, -10);
            }
        }
        /// <summary>
        /// ノーツを動かす
        /// </summary>
        /// <param name="pos">x座標</param>
        public void SetNotesPos(float pos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pos);
        }
    }
}