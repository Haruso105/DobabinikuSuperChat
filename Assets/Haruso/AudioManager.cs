using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip aClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(aClip);
        //StartCoroutine("PlayAudio");
    }

    /*IEnumerator PlayAudio()
    {
        audioSource.PlayOneShot(aClip, 0.5f);
        yield return new WaitForSeconds(1.3f);
        audioSource.Stop();
        audioSource.PlayOneShot(aClip, 0.5f);
    }*/
}
