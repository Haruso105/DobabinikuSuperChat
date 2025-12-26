using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerTomo : MonoBehaviour
{
    //バー
    [SerializeField] private Image uiFill;
    //テキスト
    [SerializeField] private TextMeshProUGUI uiText;
    //設定秒数
    [SerializeField] private float CountTime;
    public float timer;
    private void Start(){timer=CountTime;}
    private void Update()
    {   
        //残り秒数をtimerで定義
        timer -= Time.deltaTime;
        //0秒になると処理を停止
        if (timer < 0)
        {
            timer=0;
        }
        //バーの増加量をcounterで定義
        float counter= CountTime -timer;
        //秒数を分と秒で分ける
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        //バーの変化
        uiFill.fillAmount = Mathf.InverseLerp(0, CountTime, counter);
        //00:00で表示
        uiText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}