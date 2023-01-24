namespace Hikanyan.Core
{
    /// <summary>
    /// イベントをサブスクライブするすべてのクラスは、
    /// このインターフェースを実装する必要があります
    /// </summary>
    public interface IGameEventListener
    {
        /// <summary>
        /// サブスクライブされたイベントがトリガーされたときに
        /// 呼び出されるイベントハンドラー
        /// </summary>
        void OnEventRaised();
    }
}