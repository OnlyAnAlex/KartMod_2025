using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI targetText;
    public Color hoverColor = Color.red;
    private Color originalColor;

    void Start()
    {
        if (targetText != null)
        {
            originalColor = targetText.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetText != null)
        {
            targetText.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetText != null)
        {
            targetText.color = originalColor;
        }
    }
}
