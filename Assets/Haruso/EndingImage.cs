using UnityEngine;
using UnityEngine.UI;

public class EndingImage : MonoBehaviour
{
    [SerializeField] Image resultImage;
    [SerializeField] Sprite trueEnd;
    [SerializeField] Sprite deadEnd;
    [SerializeField] Sprite timeOverEnd;
    [SerializeField] AudioClip clearSE;
    [SerializeField] AudioClip gameoverSE;
    [SerializeField] AudioClip timeoverSE;
    AudioSource audioSource;

    
    int gameResult = 0; //0 = クリア、1 = ゲームオーバー、2 = タイムオーバー


    // Start is called before the first frame update
    void Start()
    {
        ScoreTransfer scoreTransfer = GameObject.Find("ScoreTransfer").GetComponent<ScoreTransfer>();
        gameResult = scoreTransfer.ReturnGameResult();

        resultImage = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();

        if(gameResult == 0) 
        {
            resultImage.sprite = trueEnd;
            audioSource.clip = clearSE;
        }
        else if(gameResult == 1)
        {
            resultImage.sprite = deadEnd;
            audioSource.clip = gameoverSE;
        }
        else
        {
            resultImage.sprite = timeOverEnd;
            audioSource.clip = gameoverSE;
        }

        audioSource.Play();
    }
}
