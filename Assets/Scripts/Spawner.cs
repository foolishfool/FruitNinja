using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// generate fruits and bomb
/// </summary>
public class Spawner : MonoBehaviour {

    [Header("Fruits")]
    public GameObject[] Fruits;
    [Header("Bomb")]
    public GameObject Bomb;
   
    //the interval time of generating fruits;
    float spawnerTime = 3.0f;
    float currentTime = 0.0f;
  
    //whether is playing the gamea
    bool isPlaying = true;
    //z position of fruit
    float tempZ = 0.0f;

    // Update is called once per frame
    void Update () {

        //only time at the start
        if (!isPlaying)
        {
            return;
        }
        currentTime += Time.deltaTime;
        if (currentTime >= spawnerTime)
        {
            // the count of fruit generated
            int fruitCount = Random.Range(1, 5);
            //generate Fruits
            for (int i = 0; i < fruitCount; i++)
            {
                onSpawner(true);
            }

            int bombNum = Random.Range(0, 100);
            // the percentage of generaging bomb
            if (bombNum > 70)
            {
                onSpawner(false);
            }
 
            currentTime = 0.0f;
        }
    }

    /// <summary>
    /// generate fruits and bomb
    /// </summary>
    void onSpawner(bool isFruit)
    {
        //range of x axis 8.2 ~ -8.2
        //range of y transform.pos.y

        float x = Random.Range(-8.2f, 8.2f);
        float y = transform.position.y;
        float z = tempZ;

        tempZ -= 2.0f;
        // make sure fruit is not in the same layer of Z position to collide with each other
        //tempZ cannot not be less than camera positionZ, must be seen by camera
        if (tempZ <= -10)
        {
            tempZ = 0.0f;
        }
        int fruitsInex = Random.Range(0, Fruits.Length);

        //game object generated (fruit or bomb)
        GameObject go;

        if (isFruit)
        {
             go = Instantiate<GameObject>(Fruits[fruitsInex], new Vector3(x, y, z), Random.rotation);
        }
        else
        {
             go = Instantiate<GameObject>(Bomb, new Vector3(x, y, z), Random.rotation);
        }   
        //the velocity of fruits
        Vector3 velocity = new Vector3(-x * Random.Range(0.2f, 0.6f), -Physics.gravity.y * Random.Range(1.0f, 1.2f), 0);
        Rigidbody fruitRigidBody = go.GetComponent<Rigidbody>();
        fruitRigidBody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
