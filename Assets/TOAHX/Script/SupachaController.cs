using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class SupachaController : MonoBehaviour
{
    [SerializeField] GameObject supachaButton1;                 //スパチャボタン1
    [SerializeField] Image supachaButton1Image;                 //スパチャボタン1イメージ
    [SerializeField] TextMeshProUGUI supachaButton1Text;        //スパチャボタン1テキスト
    [SerializeField] GameObject supachaButton2;                 //スパチャボタン2
    [SerializeField] Image supachaButton2Image;                 //スパチャボタン2イメージ
    [SerializeField] TextMeshProUGUI supachaButton2Text;        //スパチャボタン2テキスト
    [SerializeField] GameObject supachaButton3;                 //スパチャボタン3
    [SerializeField] Image supachaButton3Image;                 //スパチャボタン3イメージ
    [SerializeField] TextMeshProUGUI supachaButton3Text;        //スパチャボタン3テキスト

    private Vector2 supachaButton1Scale;                        //スパチャボタン1scale
    private Vector2 supachaButton2Scale;                        //スパチャボタン2scale
    private Vector2 supachaButton3Scale;                        //スパチャボタン3sacle

    [SerializeField] CommentSpawnerController commentSpawnerControllerScript;       //コメント生成スクリプト

    private int spachaId = 0;                                   //スパチャID

    private int supachaType1Count = 13;                         //スパチャ1の種類数
    private int supachaType2Count = 7;                          //スパチャ2の種類数
    private int supachaType3Count = 7;                          //スパチャ3の種類数

    private int supacha1SupachaId = 0;                          //スパチャ1のスパチャID
    private int supacha2SupachaId = 0;                          //スパチャ2のスパチャID
    private int supacha3SupachaId = 0;                          //スパチャ3のスパチャID

    private float spachaCoolTime = 5.0f;                        //スパチャのクールタイム
    private float spachaTimer = 0;                              //スパチャのタイマー

    private byte supachaRank = 1;                               //スパチャランク

    [SerializeField] int totalSupachaAmount = 0;                //総スパチャ額

    [SerializeField] int currentMoney = 0;                      //所持金
    [SerializeField] float currentMoneyTimer = 0;               //所持金の計算用のタイマー

    [SerializeField] RemarkController remarkControllerScript;   //RemarkControllerスクリプト

    [SerializeField] float attentionGaugeValue = 0;             //注目度ゲージ

    private string supacha1Response;                            //スパチャ1の返答
    private string supacha2Response;                            //スパチャ2の返答
    private string supacha3Response;                            //スパチャ3の返答

    [SerializeField] BabinikuController babinikuControllerScript;   //ばびにくImageのスクリプト

    // Start is called before the first frame update
    void Start()
    {
        supachaButton1Scale = supachaButton1.transform.localScale;
        supachaButton2Scale = supachaButton2.transform.localScale;
        supachaButton3Scale = supachaButton3.transform.localScale;

        ResetSupacha();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            OnClickSupachaButton1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnClickSupachaButton2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnClickSupachaButton3();
        }

        spachaTimer -= Time.deltaTime;

        if (totalSupachaAmount < 1000) 
        {
            supachaButton2Image.color = new Color32(150, 150, 150, 200);
            supachaButton2Text.color = new Color32(150, 150, 150, 200);
        }
        else 
        {
            supachaButton2Image.color = new Color32(255, 255, 255, 255);
            supachaButton2Text.color = new Color32(255, 255, 255, 255);
            if (supachaRank == 1) 
            {
                supachaRank = 2;
                babinikuControllerScript.UpdateBabinikuLevel(2);
            }
        }
        if (totalSupachaAmount < 10000)
        {
            supachaButton3Image.color = new Color32(150, 150, 150, 200);
            supachaButton3Text.color = new Color32(150, 150, 150, 200);
        }
        else
        {
            supachaButton3Image.color = new Color32(255, 255, 255, 255);
            supachaButton3Text.color = new Color32(255, 255, 255, 255);
            if (supachaRank == 2)
            {
                supachaRank = 3;
                babinikuControllerScript.UpdateBabinikuLevel(3);
            }
        }

        currentMoneyTimer += Time.deltaTime * 100;
        if (currentMoneyTimer >= 1) 
        {
            currentMoney += (int)(currentMoneyTimer - currentMoneyTimer % 1);
            currentMoneyTimer = (currentMoneyTimer % 1);
        }
    }

    public void OnClickSupachaButton1()
    {
        if (spachaTimer < 0) 
        {
            //ボタンサイズ変更UI
            supachaButton1.transform.DOScale(supachaButton1Scale * 0.8f, 0.1f)
            .OnComplete(() => supachaButton1.transform.DOScale(supachaButton1Scale, 0.1f));

            commentSpawnerControllerScript.SpawnComment(1, supachaButton1Text.text);
            totalSupachaAmount += 100;
            currentMoney -= 100;
            attentionGaugeValue += 20;

            if (supachaButton1Text.text == "お前の配信つまんな") 
            {
                commentSpawnerControllerScript.CommentAmountStandard(0.75f);
                commentSpawnerControllerScript.Enzyou(2.5f);
            }
            else if (supachaButton1Text.text == "このゲーム、分岐エンディングありますよ～")
            {
                commentSpawnerControllerScript.CommentAmountStandard(0.20f);
                commentSpawnerControllerScript.Enzyou(1.25f);
            }
            else if (supachaButton1Text.text == "ふとんがふっとんだ。ﾅﾝﾁｬｯﾃ")
            {
                commentSpawnerControllerScript.CommentAmountStandard(-1.0f);
            }
            else if (supachaButton1Text.text == "おはよ、おじさんもこのゲーム昨日買ったんだよね！ちゃんもよく遊ぶのカナ？今度おじさんと遊ぼうヨ！ﾅﾝﾁｬｯﾃあせあせ\r\n            ")
            {
                commentSpawnerControllerScript.CommentAmountStandard(-3.0f);
            }
            else if (supachaButton1Text.text == "PS低くない？")
            {
                commentSpawnerControllerScript.CommentAmountStandard(0.75f);
                commentSpawnerControllerScript.Enzyou(0.3f);
            }
            else if (supachaButton1Text.text == "つまんな")
            {
                commentSpawnerControllerScript.CommentAmountStandard(0.75f);
                commentSpawnerControllerScript.Enzyou(0.3f);
            }

            if (attentionGaugeValue >= 100) 
            {
                StartCoroutine(Timer1());
                spachaTimer = spachaCoolTime;
            }
        }
    }

    public void OnClickSupachaButton2()
    {
        if (spachaTimer < 0)
        {
            if (totalSupachaAmount >= 1000) 
            {
                //ボタンサイズ変更UI
                supachaButton2.transform.DOScale(supachaButton2Scale * 0.8f, 0.1f)
                .OnComplete(() => supachaButton2.transform.DOScale(supachaButton2Scale, 0.1f));

                commentSpawnerControllerScript.SpawnComment(2, supachaButton2Text.text);
                totalSupachaAmount += 1000;
                currentMoney -= 1000;
                attentionGaugeValue += 40;

                if (supachaButton2Text.text == "ポーク冷めちゃった…")
                {
                    commentSpawnerControllerScript.CommentAmountStandard(0.30f);
                    commentSpawnerControllerScript.Enzyou(0.5f);
                }
                else if (supachaButton2Text.text == "下手www")
                {
                    commentSpawnerControllerScript.CommentAmountStandard(0.20f);
                    commentSpawnerControllerScript.Enzyou(0.1f);
                }

                if (attentionGaugeValue >= 100) 
                {
                    StartCoroutine(Timer2());
                    spachaTimer = spachaCoolTime;
                }
            }
        }
    }

    public void OnClickSupachaButton3()
    {
        if (spachaTimer < 0)
        {
            if (totalSupachaAmount >= 10000)
            {
                //ボタンサイズ変更UI
                supachaButton3.transform.DOScale(supachaButton3Scale * 0.8f, 0.1f)
                .OnComplete(() => supachaButton3.transform.DOScale(supachaButton3Scale, 0.1f));

                commentSpawnerControllerScript.SpawnComment(3, supachaButton3Text.text);
                totalSupachaAmount += 10000;
                currentMoney -= 10000;
                attentionGaugeValue += 100;

                if (supachaButton3Text.text == "これで美味しいもの食べてくれ")
                {
                    commentSpawnerControllerScript.CommentAmountStandard(0.30f);
                    commentSpawnerControllerScript.Enzyou(-3.0f);
                }
                else if (supachaButton3Text.text == "下手www")
                {
                    commentSpawnerControllerScript.CommentAmountStandard(0.20f);
                    commentSpawnerControllerScript.Enzyou(0.1f);
                }

                if (attentionGaugeValue >= 100) 
                {
                    StartCoroutine(Timer3());
                    spachaTimer = spachaCoolTime;
                    
                }
            }
        }
    }

    IEnumerator Timer1()
    {
        float timer = 2.0f;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            yield return timer;
        }
        remarkControllerScript.RefreshRemark(-(100 + supacha1SupachaId), supacha1Response);
        Debug.Log(-(100 + supacha1SupachaId));
        attentionGaugeValue = 0;
        ResetSupacha();
        yield break;
    }
    IEnumerator Timer2()
    {
        float timer = 2.0f;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            yield return timer;
        }
        remarkControllerScript.RefreshRemark(-(200 + supacha2SupachaId), supacha2Response);
        Debug.Log(-(200 + supacha2SupachaId));
        attentionGaugeValue = 0;
        ResetSupacha();
        yield break;
    }
    IEnumerator Timer3() 
    {
        float timer = 2.0f;
        while (timer >= 0) 
        {
            timer -= Time.deltaTime;
            yield return timer;
        }
        remarkControllerScript.RefreshRemark(-(300 + supacha3SupachaId), supacha3Response);
        Debug.Log(-(300 + supacha3SupachaId));
        attentionGaugeValue = 0;
        ResetSupacha();
        yield break;
    }

    //スパチャの候補をリセット
    public void ResetSupacha()
    {
        supachaButton1.transform.DOComplete();
        supachaButton2.transform.DOComplete();
        supachaButton3.transform.DOComplete();
        supachaButton1.transform.DORotate(new Vector3(0, -360, 0), 0.2f, RotateMode.WorldAxisAdd);
        supachaButton2.transform.DORotate(new Vector3(0, -360, 0), 0.2f, RotateMode.WorldAxisAdd);
        supachaButton3.transform.DORotate(new Vector3(0, -360, 0), 0.2f, RotateMode.WorldAxisAdd);

        int randomNum1 = Random.Range(0, supachaType1Count);
        supacha1SupachaId = randomNum1;
        if (randomNum1 == 0)
        {
            //残機+1
            supachaButton1Text.text = "PS低くない？";
            supacha1Response = "じゃあHP増やすよ～もう！";
            
        }
        else if (randomNum1 == 1)
        {
            //移動速度バフ3
            supachaButton1Text.text = "つまんな";
            supacha1Response = "じゃあ早く終わらせて次のゲームするね";
        }
        else if (randomNum1 == 2)
        {
            //コメ減少1
            supachaButton1Text.text = "ふとんがふっとんだ。ﾅﾝﾁｬｯﾃ";
            supacha1Response = "え…え…？あ、そう…";
        }
        else if (randomNum1 == 3)
        {
            //炎上
            supachaButton1Text.text = "お前の配信つまんな";
            supacha1Response = "うるさい！";
        }
        else if (randomNum1 == 4)
        {
            //ジャンプ力3
            supachaButton1Text.text = "ウサギとか好きですか？";
            supacha1Response = "ウサギの肉なら食べたことあるよ！こんくらい飛べるし！";
        }
        else if (randomNum1 == 5)
        {
            //残機-3(即死)
            supachaButton1Text.text = "チート使ってください";
            supacha1Response = "え、使っちゃう？あ、ミスったミスったミスった！！！！！！";
        }
        else if (randomNum1 == 6)
        {
            //効果なし
            supachaButton1Text.text = "残機増やして";
            supacha1Response = "えーやだwww";
        }
        else if (randomNum1 == 7)
        {
            //効果なし
            supachaButton1Text.text = "昨日の夕飯なに食べましたか？";
            supacha1Response = "え、なんだったけ？あ、鹿肉！";
        }
        else if (randomNum1 == 8)
        {
            //効果なし
            supachaButton1Text.text = "配信いつも楽しみにしてます！";
            supacha1Response = "ありがと～";
        }
        else if (randomNum1 == 9)
        {
            //炎上
            supachaButton1Text.text = "このゲーム、分岐エンディングありますよ～";
            supacha1Response = "あのさ…そういうネタバレ、やめな？";
        }
        else if (randomNum1 == 10)
        {
            //効果なし
            supachaButton1Text.text = "好きな肉は？";
            supacha1Response = "えー、みんな？www";
        }
        else if (randomNum1 == 11)
        {
            supachaButton1Text.text = "24時間耐久配信待ってます^^";
            supacha1Response = "ド畜生め！！！";
        }
        else if (randomNum1 == 12)
        {
            //コメント量の減少
            supachaButton1Text.text = "おはよ、おじさんもこのゲーム昨日買ったんだよね！ちゃんもよく遊ぶのカナ？今度おじさんと遊ぼうヨ！ﾅﾝﾁｬｯﾃあせあせ";
            supacha1Response = "そういえば昨日のフェスにみんな参加してくれてありがと～";
        }
        int randomNum2 = Random.Range(supachaType1Count, supachaType1Count + supachaType2Count);
        supacha2SupachaId = randomNum2;
        if (randomNum2 == supachaType1Count + 0)
        {
            //残機+2
            supachaButton2Text.text = "残機減ってるよ(あせあせ";
            supacha2Response = "はいはい、回復ね～回復～";
        }
        else if (randomNum2 == supachaType1Count + 1)
        {
            //移動速度バフ1
            supachaButton2Text.text = "もっと速く歩いて！";
            supacha2Response = "しょうがないな～スピードアップ！";
        }
        else if (randomNum2 == supachaType1Count + 2)
        {
            //ジャンプ力1
            supachaButton2Text.text = "心がぴょんぴょんするんじゃ～";
            supacha2Response = "私もぴょんぴょんしちゃお～";
        }
        else if (randomNum2 == supachaType1Count + 3)
        {
            //効果なし
            supachaButton2Text.text = "ハタってなんですか？";
            supacha2Response = "ハタって魚でしょ？肉食で長生きするらしいよ～";
        }
        else if (randomNum2 == supachaType1Count + 4)
        {
            //炎上
            supachaButton2Text.text = "下手www";
            supacha2Response = "お前も肉塊になりたいか？";
        }
        else if (randomNum2 == supachaType1Count + 5)
        {
            //効果なし
            supachaButton2Text.text = "草";
            supacha2Response = "WWW";
        }
        else if (randomNum2 == supachaType1Count + 6)
        {
            //炎上
            supachaButton2Text.text = "ポーク冷めちゃった…";
            supacha2Response = "他の配信者さんのネタは出さないでね～";
        }
        int randomNum3 = Random.Range(supachaType1Count + supachaType2Count, supachaType1Count + supachaType2Count + supachaType3Count);
        supacha3SupachaId = randomNum3;
        if (randomNum3 == supachaType1Count + supachaType2Count + 0)
        {
            //残機+3
            supachaButton3Text.text = "回復はやくはやく";
            supacha3Response = "反転術式！全回復！！！";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 1)
        {
            //移動速度バフ2
            supachaButton3Text.text = "すごくはやい！爽快感あるな～";
            supacha3Response = "もっと速く移動しちゃおっかな～";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 2)
        {
            //ジャンプ力2
            supachaButton3Text.text = "もっと飛んで！";
            supacha3Response = "ジャンプの出力上げちゃうよ！";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 3)
        {
            //死亡時に使用するとコンティニュー
            supachaButton3Text.text = "まだ舞えるって！";
            supacha3Response = "ガチで復活しちゃった☆";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 4)
        {
            //無敵
            supachaButton3Text.text = "無敵化はよ";
            supacha3Response = "バリア～！今だけ無敵ね？";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 5)
        {
            //敵を倒す
            supachaButton3Text.text = "敵うざすぎwww";
            supacha3Response = "こいつら消そっか？";
        }
        else if (randomNum3 == supachaType1Count + supachaType2Count + 6) 
        {
            //効果なし
            supachaButton3Text.text = "これで美味しいもの食べてくれ";
            supacha3Response = "ありがと～";
        }
    }

    //総スパチャ額受け渡し
    public int TotalSupachaAmount() 
    {
        return totalSupachaAmount;
    }

    //所持金受け渡し
    public int CurrentMoney()
    {
        return currentMoney;
    }
    //所持金受け渡し
    public float AttentionGaugeValue()
    {
        return attentionGaugeValue;
    }
}
