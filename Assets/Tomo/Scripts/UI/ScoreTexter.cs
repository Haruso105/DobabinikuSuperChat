using TMPro;
using UnityEngine;

public class scoreTexter : MonoBehaviour
{
    private PlayerMove player;
    private TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        tmpro = GetComponent<TextMeshProUGUI>();
        tmpro.fontSize = 70;
        
    }

    // Update is called once per frame
    void Update()
    {
        string text = player.FLAG.ToString() + " / " + player.MaxFlag.ToString();
        tmpro.text = text;
    }
}
