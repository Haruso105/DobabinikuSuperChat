using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RemarkController : MonoBehaviour
{
    int supachaId = 0;
    int remarkId = 2;
    [SerializeField] RectTransform rectTransform;       //rectTransform
    Vector2 thisPos;                                    //初期位置
    [SerializeField] TextMeshProUGUI remarkText;        //remarkのテキスト
    private float refreshTime = 5.0f;                   //セリフを更新してテキストが消える時間
    private float refreshTimer = 0;                     //セリフを更新してテキストが消える時間のタイマー
    //[SerializeField] GameObject frameAObj;              //フレームオブジェクト
    [SerializeField] RectTransform framAObjRectTransform;       //フレームAオブジェクトのrectTransform
    [SerializeField] RectTransform framBObjRectTransform;       //フレームAオブジェクトのrectTransform

    [SerializeField] SEController seControllerScript;           //効果音スクリプト

    [SerializeField] MainCameraController mainCameraControllerScript;   //メインカメラのスクリプト

    [SerializeField] PlayerMove playerMoveScript;               //PlayerMoveスクリプト

    [SerializeField] BabinikuController babinikuControllerScript;   //BabinikuControllerスクリプト

    [SerializeField] BGMChanger bGMChangerScript;                   //BGMChangerスクリプト

    // Start is called before the first frame update
    void Start()
    {
        thisPos = rectTransform.anchoredPosition;       //初期位置の記憶
        //StartCoroutine(QWE());
        RefreshRemark(0, "");
    }

    // Update is called once per frame
    void Update()
    {
        if (refreshTimer >= 0)
        {
            refreshTimer -= Time.deltaTime;
        }
        else if (remarkText.text.Length != 0)
        {
            ResetText();
        }
    }

    IEnumerator QWE()
    {
        for (int i = 0; i < 100; i++)
        {
            RefreshRemark(i % 3 + 1, "");
            for (int j = 0; j < 120; j++)
            {
                yield return null;
            }
            if (i % 5 == 0)
            {
                for (int j = 0; j < 600; j++)
                {
                    yield return null;
                }
            }
        }
        yield break;
    }

    //新しい発言
    public void RefreshRemark(int reamrkIdNum, string textContent)
    {
        refreshTimer = refreshTime;
        remarkId = reamrkIdNum;
        ResetText();
        if (remarkId < 0)
        {
            //rectTransform.localScale *= 2.0f;
            //remarkText.color = new Color32(255, 0, 0, 255);
            remarkText.text = textContent;
            if (remarkId == -100)
            {
                //残機+1
                playerMoveScript.GiveBuff(1, 1);
                seControllerScript.Voice1();
            }
            else if (remarkId == -101)
            {
                //移動最大
                playerMoveScript.GiveBuff(2, 3);
                seControllerScript.Voice2();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -102)
            {
                seControllerScript.Voice3();
            }
            else if (remarkId == -103)
            {
                seControllerScript.Voice4();
            }
            else if (remarkId == -104)
            {
                //ジャンプ最大
                playerMoveScript.GiveBuff(3, 3);
                seControllerScript.Voice5();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -105)
            {
                //即死
                playerMoveScript.GiveBuff(1, -99);
                seControllerScript.Voice6();
            }
            else if (remarkId == -106)
            {
                seControllerScript.Voice7();
            }
            else if (remarkId == -107)
            {
                seControllerScript.Voice8();
            }
            else if (remarkId == -108)
            {
                seControllerScript.Voice9();
            }
            else if (remarkId == -109)
            {
                seControllerScript.Voice10();
            }
            else if (remarkId == -110)
            {
                seControllerScript.Voice11();
            }
            else if (remarkId == -111)
            {
                seControllerScript.Voice12();
            }
            else if (remarkId == -112)
            {
                seControllerScript.Voice13();
            }
            else if (remarkId == -213)
            {
                //残機+2
                playerMoveScript.GiveBuff(1, 2);
                seControllerScript.Voice14();
            }
            else if (remarkId == -214)
            {
                //移動小
                playerMoveScript.GiveBuff(2, 2);
                seControllerScript.Voice15();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -215)
            {
                //ジャンプ小
                playerMoveScript.GiveBuff(3, 2);
                seControllerScript.Voice16();
            }
            else if (remarkId == -216)
            {
                seControllerScript.Voice17();
            }
            else if (remarkId == -217)
            {
                seControllerScript.Voice18();
                Debug.Log(remarkId);
            }
            else if (remarkId == -218)
            {
                seControllerScript.Voice19();
                Debug.Log(remarkId);
            }
            else if (remarkId == -219)
            {
                seControllerScript.Voice20();
                Debug.Log(remarkId);
            }
            else if (remarkId == -320)
            {
                //残機+3
                playerMoveScript.GiveBuff(1, 3);
                seControllerScript.Voice21();
            }
            else if (remarkId == -321)
            {
                //移動中
                playerMoveScript.GiveBuff(2, 2);
                seControllerScript.Voice22();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -322)
            {
                //ジャンプ中
                playerMoveScript.GiveBuff(3, 2);
                seControllerScript.Voice23();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -323)
            {
                //コンテ
                playerMoveScript.GiveBuff(6, 0);
                seControllerScript.Voice24();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -324)
            {
                //無敵
                playerMoveScript.GiveBuff(4, 0);
                seControllerScript.Voice25();
                StartCoroutine(BGMChange());
            }
            else if (remarkId == -325)
            {
                //近くの敵を倒す
                playerMoveScript.GiveBuff(5, 0);
                seControllerScript.Voice26();
            }
            else if (remarkId == -326)
            {
                seControllerScript.Voice27();
            }
        }
        else if (remarkId == 0)
        {
            remarkText.fontSize = 100;
            remarkText.text = "こんドバ美～！今日も配信がんばるぞっ！";
            seControllerScript.Voice28();
        }
        else if (remarkId == 1)
        {
            remarkText.color = new Color32(255, 0, 0, 255);
            rectTransform.localEulerAngles = new Vector3(0, 0, -20);
            remarkText.fontSize = 120;
            rectTransform.anchoredPosition = new Vector2(0, 0);
            rectTransform.localScale = new Vector2(1.5f, 1.5f);
            rectTransform.DOShakePosition(2f, 20f, 30, 1, false, false);
            remarkText.text = "ああああああああああああああああああああああああああああ";
            seControllerScript.Voice30();
        }
        else if (remarkId == 2)
        {
            remarkText.color = new Color32(255, 150, 150, 255);
            remarkText.fontSize = 140;
            remarkText.text = "今日はもうおしまい～";
            seControllerScript.Voice31();
        }
        else if (remarkId == 3)
        {
            //台パン
            //mainCameraControllerScript.ShakeCamera(0.25f, new Vector2(0.5f, 0.5f), 90, 15, false, true);
            //transform.DOShakePosition(0.25, new Vector3(0.5f, 0.5f, 1.0f), 90, 15, false, true);
            // 下向き振動
            framAObjRectTransform.DOShakePosition(0.5f, new Vector3(0, -200, 0), 30, 90, false, true);
            // 上向き振動
            framBObjRectTransform.DOShakePosition(0.5f, new Vector3(0, 50, 0), 30, 90, false, true);

            rectTransform.localScale *= 2.0f;
            remarkText.color = new Color32(255, 0, 0, 255);
            remarkText.text = "ふざけんなし！絶対〇す！";
            seControllerScript.Voice29();
        }
        else if (remarkId == 4)
        {
            rectTransform.localScale *= 2.0f;
            remarkText.color = new Color32(255, 0, 0, 255);
            remarkText.text = "お前ら肉塊にするからな？";
            seControllerScript.Voice32();
        }
    }

    //発言テキストの初期化
    public void ResetText()
    {
        transform.DOComplete();
        rectTransform.anchoredPosition = thisPos;
        rectTransform.localEulerAngles = Vector3.zero;
        rectTransform.localScale = new Vector2(1.0f, 1.0f);
        remarkText.text = "";
        remarkText.color = new Color32(255, 255, 255, 255);
        remarkText.fontSize = 75;
    }

    //被ダメージ時
    public void BabinikuReceive()
    {
        RefreshRemark(1, "");
        BabinikuDestroy();
    }

    //死亡時
    public void BabinikuDeath()
    {
        RefreshRemark(3, "");
        BabinikuDestroy();
    }

    //台パンモード移行
    public void BabinikuDestroy()
    {
        babinikuControllerScript.BabinikuDestroy();
    } 

    //BGMチェンジ
    IEnumerator BGMChange() 
    {
        bGMChangerScript.PlayDrop();
        float timer = 5f;
        while (timer >= 0)  
        {
            timer-=Time.deltaTime;
            yield return null;
        }
        bGMChangerScript.PlayNormal();
        yield break;
    }
}