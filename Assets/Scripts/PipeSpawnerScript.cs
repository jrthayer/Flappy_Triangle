using JetBrains.Annotations;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public int spawnRate;
    public float heightOffset = 9;

    private float timer = 0;

    public LogicScript logic;
    private GameObject newPipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {   
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            timer = 0;
            SpawnPipe();
        }
    }

    void SpawnPipe(){
        
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

    
        newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),transform.position.z), transform.rotation);
        var newPipeScript = newPipe.GetComponent<PipeScript>();
        newPipeScript.logic = logic;
    }
}
