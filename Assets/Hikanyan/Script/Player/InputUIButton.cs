using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Hikanyan.Gameplay
{
    public class InputUIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private int _blocknum;

        public void OnPointerDown(PointerEventData eventData)
        {
            Player.Instance.BlockPress(_blocknum);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Player.Instance.BlockRelease(_blocknum);
        }
    }

}