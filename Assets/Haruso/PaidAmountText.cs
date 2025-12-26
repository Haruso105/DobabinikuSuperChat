using UnityEngine;
using DG.Tweening;
using TMPro;

public class PaidAmountText : MonoBehaviour
{
    TMP_Text paidText;
    float Speed = 0.005f;
    float red,green,blue,alfa;
    RectTransform textPosition;
    [SerializeField] Vector2 v2 = new Vector2(0f, 0f);

    [Header("消えるまでの時間")]
    [SerializeField] float time = 1.0f;
    [Header("y軸の上昇量")]
    [SerializeField] float yLocation = 20f;

    // Start is called before the first frame update
    void Start()
    {
        paidText = GetComponent<TMP_Text>();
        red = paidText.color.r;
        blue = paidText.color.b;
        green = paidText.color.g;
        alfa = paidText.color.a;

        textPosition = this.GetComponent<RectTransform>();
        v2= new Vector2(textPosition.anchoredPosition.x, textPosition.anchoredPosition.y + yLocation);
        textPosition.DOAnchorPos(v2, time).SetEase(Ease.InQuad);
    }

    void Update()
    {
        FadeOut();
    }

    void FadeOut()
    {
        alfa -= Speed;
        Alpha();
        if(alfa <= 0)
        {
            this.textPosition.DOKill();
            Destroy (this.gameObject);
        }
    }

    void Alpha()
    {
        paidText.color = new Color(red, green, blue, alfa);
    }
}
