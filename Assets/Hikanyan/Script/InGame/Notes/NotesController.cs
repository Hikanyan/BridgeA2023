using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    public class NotesController : SingletonBehaviour<NotesController>
    {
        [SerializeField, Tooltip("ノーツスピード")]
        float _notesSpeed;

        void NotesMove()
        {
            for(int i = 0; i < 3; i++)
            {
                //[TODO]
            }
        }
    }
}