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
            if (_blocknum == 4) Player.instance.AllBlockPress();
            else Player.instance.BlockPress(_blocknum);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Player.instance.BlockRelease(_blocknum);
        }
    }

}