using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject feedBack;
    private void Start()
    {
        feedBack.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        feedBack.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        feedBack.SetActive(false);
    }
}
