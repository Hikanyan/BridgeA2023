namespace Hikanyan.Core
{
    /// <summary>
    /// �C�x���g���T�u�X�N���C�u���邷�ׂẴN���X�́A
    /// ���̃C���^�[�t�F�[�X����������K�v������܂�
    /// </summary>
    public interface IGameEventListener
    {
        /// <summary>
        /// �T�u�X�N���C�u���ꂽ�C�x���g���g���K�[���ꂽ�Ƃ���
        /// �Ăяo�����C�x���g�n���h���[
        /// </summary>
        void OnEventRaised();
    }
}