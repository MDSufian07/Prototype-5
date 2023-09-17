using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Target: MonoBehaviour
{
    private Rigidbody TargetRb;
    private float maxTorque = 10;
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float xRange = 4;
    private float spawnPos = -6;

    public int PointValue;
    public ParticleSystem explosionParticle;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        TargetRb = GetComponent<Rigidbody>();

        TargetRb.AddForce(RandomForce(),ForceMode.Impulse);
        TargetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manger").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.scoreUpdate(PointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.gameOver();
            }
        }
    }
   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
      
 
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), spawnPos);
    }

}
