using UnityEngine;
using UnityEngine.UI;

public class heartMove : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    Image image;
    [SerializeField] Sprite image0, image1;
    RectTransform reTra;
    public int heartID;
    // Start is called before the first frame update
    void Start()
    {
        reTra = GetComponent<RectTransform>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        image = GetComponent<Image>();
        reTra.localPosition = new Vector3(-830+160*heartID,385, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(heartID < playerMove.LIFE)
        {
            image.sprite = image1; 
        }else{image.sprite = image0;}
    }
}
