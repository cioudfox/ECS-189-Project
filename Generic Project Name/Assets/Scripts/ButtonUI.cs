using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonUI : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;
    public UnityEvent onMiddleClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            onMiddleClick.Invoke();
        }
    }
}