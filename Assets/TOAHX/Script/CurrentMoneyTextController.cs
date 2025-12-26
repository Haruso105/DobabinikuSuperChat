using UnityEngine;
using TMPro;

public class CurrentMoneyTextController : MonoBehaviour
{
    [SerializeField] SupachaController supachaControllerScript;             //スパチャコントローラスクリプト
    [SerializeField] TextMeshProUGUI currentMoneyText;                      //テキスト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMoneyText.text = "所持金\t :\u00A5" + supachaControllerScript.CurrentMoney();
    }
}
