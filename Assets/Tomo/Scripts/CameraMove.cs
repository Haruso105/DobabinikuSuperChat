using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMove pmove;
    // Start is called before the first frame update
    void Start()
    {
        pmove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0f, 1f, -10f);
    }
}
