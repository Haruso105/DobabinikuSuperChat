using UnityEngine;
using TMPro;

public class FadeManager : MonoBehaviour
{
    [SerializeField]float Speed = 0.005f;
    float red, green, blue;
    float alfa;
    
    public bool Out = false;
    public bool In = false;

    TMP_Text fadeText;

    void Awake()
    {
        fadeText = GetComponent<TMP_Text>();


        red = fadeText.color.r;
        blue = fadeText.color.b;
        green = fadeText.color.g;
        alfa = 0;

        Alpha();
    }

    // Update is called once per frame
    void Update()
    {
        if(In) FadeIn();

        if(Out) FadeOut();
    }

    void FadeIn()
    {
        fadeText.enabled = true;
        alfa += Speed;
        Alpha();
        if(alfa >= 1)
        {
            In = false;
        }
    }

    void FadeOut()
    {
        alfa -= Speed;
        Alpha();
        if(alfa <= 0)
        {
            Out = false;
            fadeText.enabled = false;
        }
    }

    void Alpha()
    {
        fadeText.color = new Color(red, green, blue, alfa);
    }
}
