using System.Collections;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] GameObject manualPanel;
    [SerializeField] GameObject creditsPanel;

    public bool hidePanel = true;
    // Start is called before the first frame update
    
    void Awake()
    {
        manualPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hidePanel)
        {
            if(Input.anyKey)
            {
                Debug.Log("A key or mouse click has been detected");
                manualPanel.SetActive(false);
                creditsPanel.SetActive(false);
                hidePanel = true;
            }
        }
    }

    public void ShowManual()
    {
        manualPanel.SetActive(true);
        hidePanel = false;
        //StartCoroutine("InputAnyKey");
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        hidePanel = false;
        //StartCoroutine("InputAnyKey");
    }

    IEnumerator InputAnyKey()
    {
        yield return new WaitForSeconds(0.5f);
        hidePanel = false;
    }
}
