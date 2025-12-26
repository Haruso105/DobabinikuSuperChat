using UnityEngine;

public class PlayerStand : MonoBehaviour
{
    public bool standing;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "level")
        {
            standing = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        standing = false;
    }
}
