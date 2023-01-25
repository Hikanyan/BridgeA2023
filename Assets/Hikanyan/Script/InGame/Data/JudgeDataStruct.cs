using UnityEngine;

namespace Hikanyan.Core
{
    public enum Judges
    {
        PurePerfect,
        Perfect,
        Great,
        Good,
        Bad,
        Miss,
        Auto,
        None
    }
    public enum ResultRank
    {
        AP,
        EX,
        S,
        A,
        B,
        C,
        D,
        Auto,
        None
    }
    public struct JudgeScores
    {
        public int PurePerfect;
        public int Perfect;
        public int Great;
        public int Good;
        public int Bad;
        public int Miss;
        public int Auto;
    }
    public struct JudgeTime
    {
        //‚±‚±‚Ì”’l‚ğ•ÏX‚µ‚Ä“ïˆÕ“x‚ğ’²®
        #region JudgeTimes
        private const float purePerfectTime = 0.01f;
        private const float perfectTime = 0.05f;
        private const float greatTime = 0.1f;
        private const float goodTime = 0.15f;
        public const float badTime = 0.20f;
        #endregion

        public static Judges JudgeNotes(float time)
        {
            time = Mathf.Abs(time);
            if (time <= purePerfectTime)
            {
                return Judges.PurePerfect;
            }
            else if (time <= perfectTime)
            {
                return Judges.Perfect;
            }
            else if (time <= greatTime)
            {
                return Judges.Great;
            }
            else if (time <= goodTime)
            {
                return Judges.Good;
            }
            else if (time <= badTime)
            {
                return Judges.Bad;
            }
            return Judges.None;
        }
    }
}
