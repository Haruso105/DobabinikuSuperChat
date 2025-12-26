using UnityEngine;

public class CommentController : MonoBehaviour
{
    float baseCommentScrollSpeed = 2.0f;                //基礎コメント速度
    float commentScrollSpeedFactor = 0.5f;              //コメント速度係数
    int commentLength = 0;                              //文字数
    [SerializeField] RectTransform rectTransform;       //rectTransform
    //float commentPosY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();

        //流れる高さの設定
        float randomPosY = Random.Range(-200.0f, 1080 / 2 - 50f);
        rectTransform.anchoredPosition = new Vector2(1920, randomPosY);
    }

    // Update is called once per frame
    void Update()
    {
        //コメントが流れる
        Vector2 thisPos = rectTransform.anchoredPosition;
        thisPos.x -= baseCommentScrollSpeed + commentLength * commentScrollSpeedFactor;
        rectTransform.anchoredPosition = thisPos;

        //画面外に出たら消去
        if (rectTransform.anchoredPosition.x < -1920) 
        {
            Destroy(this.gameObject);
        }
    }

    //コメントの文字数の受け渡し
    public void CommentLength(int commentLengthNum) 
    {
        commentLength = commentLengthNum;
    }
}
