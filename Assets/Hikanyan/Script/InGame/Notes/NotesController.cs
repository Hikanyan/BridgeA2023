using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    public class NotesController : SingletonBehaviour<NotesController>
    {
        private float _blockHeight;
        private float _notesSpeed;

        public void SetData(float blockHeight, float notesSpeed)
        {
            _blockHeight = blockHeight;
            _notesSpeed = notesSpeed;
        }

        void Update()
        {
            if (GameTimer.Instance.IsRunning)
            {
                MoveNotes();
                CheckNotesIsNothing();
            }
        }

        List<int> _removeNotesByLaneIndex = new();

        void MoveNotes()
        {
            int i = 0;
            for (int blocki = 0; i < 4; blocki++)
            {
                foreach (Notes notes in NotesManager.Instance.BlockNotes[blocki])
                {

                    NotesControl(i, notes);
                }
                i++;
            }
            if (_removeNotesByLaneIndex.Count > 0)
            {
                foreach (int temp in _removeNotesByLaneIndex)
                {
                    if (NotesManager.Instance.BlockNotes[temp].Count <= 0) break;
                    NotesManager.Instance.BlockNotes[temp].RemoveAt(0);
                }
                _removeNotesByLaneIndex.Clear();
            }
        }
        void NotesControl(int i, Notes notes)
        {
            float judgeTime = GameTimer.Instance.RealTime - notes.Time;

            float pos = _blockHeight - judgeTime / _blockHeight * _blockHeight * _notesSpeed - _blockHeight;

            if (!notes.Visible && pos <= _blockHeight)//•\Ž¦”ÍˆÍ‚É“ü‚Á‚½‚Æ‚«ƒm[ƒc‚ðŒ©‚¦‚é‚æ‚¤‚É‚·‚é
            {
                notes.SetVisible(true);
            }
        }
        void CheckNotesIsNothing()
        {
            foreach (var lane in NotesManager.Instance.BlockNotes)
            {
                if (lane.Count > 0) return;
            }
            GameManager.Instance.GameEnd();
        }
    }
}