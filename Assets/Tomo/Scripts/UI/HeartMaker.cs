using UnityEngine;

public class HeartMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("heart");
        int i = 0;
        while(i<0)
        {
            GameObject instance = (GameObject)Instantiate(obj);
            heartMove hm = instance.GetComponent<heartMove>();
            hm.heartID = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
