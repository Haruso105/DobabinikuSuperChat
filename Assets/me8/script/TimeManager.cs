using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //TextGameObjectを入れる変数
    public GameObject countText;

    //制限時間を入れる変数
    public float limitTime = 180.0f;

    private void Start()
    {
        //ゲーム起動時に制限時間を表示する処理
        countText.GetComponent<TextMeshProUGUI>().text = (int)limitTime + "s";
    }

    private void Update()
    {
        //limitTimeが0以上ならカウントダウンを実行する処理
        if (limitTime >= 0f)
        {
            countText.GetComponent<TextMeshProUGUI>().text = (int)limitTime + "s";

            limitTime -= Time.deltaTime;
            // limitTime = limitTime - Time.deltaTime; ←これと同じ意味
        }
    }
}