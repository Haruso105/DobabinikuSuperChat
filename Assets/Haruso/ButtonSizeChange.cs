using UnityEngine;
using DG.Tweening;

public class ButtonSizeChange : MonoBehaviour
{
    [SerializeField] float sizeRatio = 1.2f;
    RectTransform buttonSize;
    void Awake()
    {
        buttonSize = GetComponent<RectTransform>();
    }

    public void OnPointerEnter()
    {
        buttonSize.DOScale(new Vector3(sizeRatio, sizeRatio, 0), 0.3f).SetEase(Ease.OutCirc);
    }

    public void OnPointerExit()
    {
        buttonSize.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCirc);
    }
    
}
