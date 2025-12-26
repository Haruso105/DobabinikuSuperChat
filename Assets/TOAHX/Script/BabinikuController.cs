using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BabinikuController : MonoBehaviour
{
    [SerializeField] Sprite Babiniku1N;                         //1段階通常形態
    [SerializeField] Sprite Babiniku1D;                         //1段階台パン形態
    [SerializeField] Sprite Babiniku2N;                         //2段階通常形態
    [SerializeField] Sprite Babiniku2D;                         //2段階台パン形態
    [SerializeField] Sprite Babiniku3N;                         //3段階通常形態
    [SerializeField] Sprite Babiniku3D;                         //3段階台パン形態

    [SerializeField] Image thisImage;                           //ばびにくのImage

    private int babinikuLevel = 1;                              //ばびにくの形態
    private bool isBabinikuDestroy = false;                     //ばびにく台パンモードか

    private Coroutine babinikuDestroyExe;                       //ばびにく台パンコルーチン

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ばびにく段階の変更
    public void UpdateBabinikuLevel(int level)
    {
        babinikuLevel = level;
        ChangeImage();
        //ポン！というかんじ
        transform.DOComplete();
        transform.localScale = Vector3.one * 0.5f;
        transform.DOScale(1.2f, 0.15f)
            .OnComplete(() => transform.DOScale(1.0f, 0.15f));
    }

    //ばびにく台パン
    public void BabinikuDestroy()
    {
        if (babinikuDestroyExe != null) 
        {
            StopCoroutine(babinikuDestroyExe);
        }
        babinikuDestroyExe = StartCoroutine(BabinikuDestroyExe());
    }

    //ばびにく台パンコルーチン実行
    IEnumerator BabinikuDestroyExe() 
    {
        isBabinikuDestroy = true;
        ChangeImage();
        float timer = 10f;
        while (timer >= 0) 
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        isBabinikuDestroy = false;
        ChangeImage();
        yield break;
    }

    //画像変更
    public void ChangeImage() 
    {
        if (isBabinikuDestroy == false) 
        {
            if (babinikuLevel == 1)
            {
                thisImage.sprite = Babiniku1N;
            }
            if (babinikuLevel == 2)
            {
                thisImage.sprite = Babiniku2N;
            }
            if (babinikuLevel == 3)
            {
                thisImage.sprite = Babiniku3N;
            }
        }
        else 
        {
            if (babinikuLevel == 1)
            {
                thisImage.sprite = Babiniku1D;
            }
            if (babinikuLevel == 2)
            {
                thisImage.sprite = Babiniku2D;
            }
            if (babinikuLevel == 3)
            {
                thisImage.sprite = Babiniku3D;
            }
        }
    }
}
