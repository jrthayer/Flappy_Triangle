using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{   
    private bool cleared = false;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GetComponentInParent<PipeScript>().logic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (cleared == false)
        {
            if (collision.gameObject.layer == 7)
            {
                logic.addScore(1);
                cleared = true;
            }
        }
    }    
}
