using System.Collections;
using UnityEngine;
using DG.Tweening;

public class DOTweenEasing : MonoBehaviour
{
    RectTransform uiTransform;
    [SerializeField] Vector3 location = new Vector3(0f, 0f, 0f);
    [SerializeField] float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Coroutine1");
    }

    IEnumerator Coroutine1()
    {
        yield return new WaitForSeconds(0.5f);
        uiTransform = GetComponent<RectTransform>();
        uiTransform.DOAnchorPos(location, time).SetEase(Ease.OutBounce);
    }
}
