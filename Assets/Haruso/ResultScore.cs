using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class ResultScore : MonoBehaviour
{

    float clearTime = 0f;
    float superchat = 1111f;
    float finalAmount = 10000f;

    [SerializeField]int gameResult = 0; //0クリア、1ゲームオーバー、2タイムオーバー
    
    ScoreTransfer scoreTransfer;
    [SerializeField] GameObject ClearTimeText;
    [SerializeField] GameObject SuperChatAmountText;
    [SerializeField] GameObject FinalAmountText;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject ButtonObjects;
    [SerializeField] GameObject RatioTexts;
    [SerializeField] GameObject ShinkaRatioText;
    TMP_Text timeText;
    TMP_Text superchatText;
    TMP_Text amountText;
    TMP_Text scText;
    TMP_Text shinkaRatioText;
    [SerializeField]TMP_Text timeRatioText;
    [SerializeField]TMP_Text amountRatioText;

    GameObject stageScoreScript;

    //int shinkaScore;
    float score, timeScore; 
    int amountScore,superchatScore = 0;

    void Awake()
    {
        scoreTransfer = GameObject.Find("ScoreTransfer").GetComponent<ScoreTransfer>();
        timeText = ClearTimeText.GetComponent<TMP_Text>();
        superchatText = SuperChatAmountText.GetComponent<TMP_Text>();
        amountText = FinalAmountText.GetComponent<TMP_Text>();
        scText = ScoreText.GetComponent<TMP_Text>();
        shinkaRatioText = ShinkaRatioText.GetComponent<TMP_Text>();

        ClearTimeText.SetActive(false);
        SuperChatAmountText.SetActive(false);
        FinalAmountText.SetActive(false);
        ScoreText.SetActive(false);
        ButtonObjects.SetActive(false);
        RatioTexts.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(scoreTransfer != null)
        {
            clearTime = scoreTransfer.ReturnResultTime();
            gameResult = scoreTransfer.ReturnGameResult();
            superchat = scoreTransfer.ReturnTotalAmount();
            finalAmount = scoreTransfer.ReturnHoldAmount();
        }


        //if(superchat >= 1000) shinkaScore = 1000;
        //if(superchat >= 10000) shinkaScore = 10000;

        //スコア =  クリアタイム*1000 + 残金
        if(gameResult != 0) clearTime = 0f;
        
        timeScore = clearTime * 500;
        amountScore = (int)(finalAmount/100);
        superchatScore = (int)(superchat/10);

        //score = (clearTime)*10000 + finalAmount + shinkaScore;
        score = timeScore + amountScore + superchatScore;


        //clearTime = 180 - clearTime;
        
        StartCoroutine("ShowResult");
    }

    IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(0.7f);
        if(gameResult == 0) timeText.text = "クリアタイム :" + Mathf.Round(clearTime) + "秒";
        else if(gameResult == 1) timeText.text = "ゲームオーバー";
        else if(gameResult == 2) timeText.text = "タイムオーバー";
        ClearTimeText.SetActive(true);
        Debug.Log("Show Clear Time");

        yield return new WaitForSeconds(0.7f);
        superchatText.text = "スパチャ額 : " + superchat + "円";
        SuperChatAmountText.SetActive(true);
        Debug.Log("Show Superchat Amount");

        yield return new WaitForSeconds(0.7f);
        amountText.text = "所持金 : " + finalAmount + "円";
        FinalAmountText.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        scText.text = "スコア : " + Math.Round(score) + "点";
        ScoreText.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        ButtonObjects.SetActive(true);
        if(gameResult != 0) timeRatioText.text = " ";
        else timeRatioText.text = "+ " + Math.Round(timeScore);
        shinkaRatioText.text = "+ " + superchatScore;
        amountRatioText.text = "+ " + amountScore;
        RatioTexts.SetActive(true);

        yield break;
    }
}
