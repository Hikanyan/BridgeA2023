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
            InputManager.Instance.BlockPress(_blocknum);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputManager.Instance.BlockRelease(_blocknum);
        }
    }

}