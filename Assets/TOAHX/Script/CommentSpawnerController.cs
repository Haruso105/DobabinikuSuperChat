using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommentSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject normalCommentBoxObj;        //コメント収納オブジェクト
    [SerializeField] GameObject supachaBoxObj;          //スパチャ収納オブジェクト
    [SerializeField] GameObject commentObj;                 //コメントオブジェクト

    [SerializeField] List<string> normalCommentList = new List<string>();       //庶民コメのリスト
    [SerializeField] List<string> normalCommentFireList = new List<string>();   //庶民コメのリスト(炎上) 

    [SerializeField] float commentAmount = 0.05f;                               //コメント量
    [SerializeField] float commentAmountStandard = 0.05f;                       //コメント量の基準

    [SerializeField] float enzyouRate = 0;                                      //炎上率


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //コメント量の標準は0.05
        
        //コメント量、コメント標準に移行
        if (commentAmount < commentAmountStandard)
        {
            commentAmount += Time.deltaTime * (Mathf.Abs(commentAmountStandard - 0) / 0.1f);
        }
        else 
        {
            commentAmount -= Time.deltaTime * (Mathf.Abs(commentAmountStandard) / 0.1f);
        }
        //コメント標準、0.05に移行
        if (commentAmountStandard < 0.05) 
        {
            commentAmountStandard += Time.deltaTime * (Mathf.Abs(commentAmountStandard - 0.05f) / 2);
        }
        else
        {
            commentAmountStandard -= Time.deltaTime * (Mathf.Abs(commentAmountStandard) / 2);
        }
        //上限ストッパー
        if (commentAmountStandard <= -1)
        {
            commentAmountStandard = 0;
        }
        if (commentAmountStandard >= 3)
        {
            commentAmountStandard = 3;
        }
        if (commentAmount <= -1)
        {
            commentAmount = 0;
        }
        else if (commentAmount >= 3)
        {
            commentAmount = 3;
        }

        float value = commentAmount;
        while (value > 0) 
        {
            if (value >= 1) 
            {
                //通常
                if ((enzyouRate % 1) < Random.Range(0.0f, 1.0f)) 
                {
                    SpawnComment(0, normalCommentList[Random.Range(0, normalCommentList.Count)]);
                }
                //炎上
                else 
                {
                    SpawnComment(-1, normalCommentFireList[Random.Range(0, normalCommentFireList.Count)]);
                }
            }
            else if ((value % 1) > Random.Range(0.0f, 1.0f)) 
            {
                //通常
                if ((enzyouRate % 1) < Random.Range(0.0f, 1.0f))
                {
                    SpawnComment(0, normalCommentList[Random.Range(0, normalCommentList.Count)]);
                }
                //炎上
                else
                {
                    SpawnComment(-1, normalCommentFireList[Random.Range(0, normalCommentFireList.Count)]);
                }
            }
            value -= 1;
        }

        //炎上率は1秒で10%減少(炎上率は最大100%)
        enzyouRate -= ((Time.deltaTime) / 10);
        if (enzyouRate > 5) 
        {
            enzyouRate = 5;
        }
        else if (enzyouRate < 0)
        {
            enzyouRate = 0;
        }
    }

    //炎上
    public void Enzyou(float rate) 
    {
        enzyouRate += rate;
    }

    //コメント量の標準の変更
    public void CommentAmountStandard(float value)
    {
        commentAmountStandard += value;
    }

    //コメント生成(スパチャ込)
    public void SpawnComment(int commentType,string commentContent)
    {
        //コメントタイプ0=背景のコメント、1=無料コメスパチャ()、2=中級スパチャ、3=高級スパチャ
        GameObject commentObjs = Instantiate(commentObj, normalCommentBoxObj.transform);
        if (commentType > 0)
        {
            commentObjs.transform.SetParent(supachaBoxObj.transform);
        }
        TextMeshProUGUI commentObjsText = commentObjs.GetComponent<TextMeshProUGUI>();
        CommentController commentControllerScript = commentObjs.GetComponent<CommentController>();
        commentControllerScript.CommentLength(commentContent.Length);
        commentObjsText.text = commentContent;
        
        if (commentType == 0)
        {
            commentObjsText.color = new Color32(255, 255, 255, 150);
            commentObjsText.fontSize = 48;
        }
        else if (commentType == -1)
        {
            commentObjsText.color = new Color32(255, 200, 200, 150);
            commentObjsText.fontSize = 48;
        }
        else if (commentType == 1)
        {
            commentObjsText.color = new Color32(20, 100, 250, 255);
            commentObjsText.fontSize = 64;
            commentObjsText.outlineWidth = 0.1f;
        }
        else if (commentType == 2)
        {
            commentObjsText.color = new Color32(250, 200, 20, 255);
            commentObjsText.fontSize = 64;
            commentObjsText.outlineWidth = 0.1f;
        }
        else if (commentType == 3) 
        {
            commentObjsText.color = new Color32(250, 20, 20, 255);
            commentObjsText.fontSize = 64;
            commentObjsText.outlineWidth = 0.1f;
        }
    }
}
