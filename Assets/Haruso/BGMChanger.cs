using System.Collections;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;   //ノーマルBGM
    [SerializeField] AudioSource audioSource2;  //ドロップ

    bool changeToDrop = false;
    bool changeToNormal = false;
    bool dropBGM = false;

    // Start is called before the first frame update
    void Start()
    {
        ScoreTransfer scoreTransfer =  GameObject.Find("ScoreTransfer").GetComponent<ScoreTransfer>();
        if(scoreTransfer != null) scoreTransfer.FindSupachaController();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(changeToDrop)
        {
            audioSource.pitch += Time.deltaTime/2;
            audioSource.volume -= Time.deltaTime/1.75f;

            audioSource2.pitch += Time.deltaTime/3.5f;
            audioSource2.volume += Time.deltaTime/2.5f;
        }
        if(changeToNormal)
        {
            audioSource.pitch -= Time.deltaTime/2;
            audioSource.volume += Time.deltaTime/2.5f;

            audioSource2.pitch -= Time.deltaTime;
            audioSource2.volume -= Time.deltaTime/2;
        }
    }

    public void PlayDrop()
    {
        if(!dropBGM)
        {
            StopCoroutine("ChangeNormal");
            dropBGM = true;

            changeToNormal = false;
            changeToDrop = true;
            audioSource2.volume = 0f;
            audioSource2.pitch = 0.5f;
            audioSource2.Play();
            StartCoroutine("ChangeDrop");
        }
    }

    public void PlayNormal()
    {
        if(dropBGM)
        {
            StopCoroutine("ChangeDrop");
            dropBGM = false;
            changeToDrop = false;

            changeToNormal = true;
            audioSource.volume = 0f;
            audioSource.pitch = 2.0f;
            audioSource.time -= 5.0f;
            audioSource.Play();
            StartCoroutine("ChangeNormal");
        }
    }

    IEnumerator ChangeDrop()
    {
        if(changeToNormal) yield break;
        yield return new WaitForSeconds(2.0f);
        audioSource.volume = 0f;
        changeToDrop = false;
        audioSource.Pause();
        audioSource2.volume = 0.4f;
        audioSource2.time = 60.5f;
        audioSource2.pitch = 1f;
    }
    IEnumerator ChangeNormal()
    {
        if(changeToDrop) yield break;
        yield return new WaitForSeconds(2.0f);
        audioSource2.volume = 0f;
        changeToNormal = false;

        audioSource2.Stop();
        audioSource.volume = 0.4f;
        audioSource.pitch = 1f;
    }
}
