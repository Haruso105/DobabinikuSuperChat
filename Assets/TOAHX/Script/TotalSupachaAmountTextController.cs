using UnityEngine;
using TMPro;

public class TotalSupachaAmountTextController : MonoBehaviour
{
    [SerializeField] SupachaController supachaControllerScript;             //スパチャコントローラスクリプト
    [SerializeField] TextMeshProUGUI totalSupachaAmountText;                //テキスト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalSupachaAmountText.text = "スパチヤ額:\u00A5" + supachaControllerScript.TotalSupachaAmount();
    }
}
