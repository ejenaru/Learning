using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxX = 7, minX = -7, maxY = 3, minY = -3;
    Vector2 destiny;
    float changeDirRate;
    float timeNow;
    float timeLastDir;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;

        if (Vector2.Distance(destiny, transform.position) > 1)
        {
            ChooseDestiny();
            transform.Translate(destiny * Time.deltaTime);
        }

        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "scenario")
        {
            ChooseDestiny();
        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void ChooseDestiny() // create new random vector
    {
        destiny = new Vector2(Random.Range(minX, maxX),
            Random.Range(minY, maxY));

    }
}
