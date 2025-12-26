using UnityEngine;


public class LifeMove : MonoBehaviour
{
    public int LifeID;
    [SerializeField] PlayerMove playerMove;
    private RectTransform reTra;
    private UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        reTra = GetComponent<RectTransform>();
        reTra.localPosition = new Vector3(-830+140*LifeID,400, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeID < playerMove.LIFE)
        {
            image.color = new Color(1,1,1);
        }else{image.color = new Color(0,0,0);}

        /*if(LifeID <= 2)
        {
            if(LifeID < playerMove.LIFE)
            {
                image.color = new Color(1,1,1);
            }else{image.color = new Color(0,0,0);}
        }else
        {
            if(LifeID < playerMove.LIFE)
            {
                image.color = new Color(1,1,1,1);
            }else{image.color = new Color(0,0,0,0);}
        }*/

    }
}
