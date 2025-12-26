using UnityEngine;

public class AttentionGauge : MonoBehaviour
{
    private float maxValue;                                         //最大値
    private float currentValue;                                     //現在値

    private float gaugeLength;                                      //ゲージの長さ(基本的に数値は1)

    [SerializeField] RectTransform rectTransform;                   //Imageの情報取得
    [SerializeField] SupachaController supachaControllerScript;     //スパチャコントローラスクリプト
    
    // Start is called before the first frame update
    void Start()
    {
        //基本は1
        gaugeLength = rectTransform.localScale.y;

        maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = supachaControllerScript.AttentionGaugeValue();
        //現在地が最大値を超えた際にはみ出さないようにする処理
        if ((float)((float)currentValue / (float)maxValue) > 1)
        {
            currentValue = maxValue;
        }

        if (maxValue != 0)
        {
            //ゲージ長の反映
            rectTransform.localScale = new Vector3(1, gaugeLength * currentValue / maxValue, 1);
            rectTransform.localPosition = new Vector3(0, ((gaugeLength * currentValue / maxValue) * 0.5f - 0.5f) * rectTransform.sizeDelta.y, 0);
        }
    }
}
