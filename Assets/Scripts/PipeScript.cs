using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 1;
    public float deadzone = -50;

    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < deadzone){
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
            
        }

        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }
}
