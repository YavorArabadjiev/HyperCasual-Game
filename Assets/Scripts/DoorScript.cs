using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
         [SerializeField] GameObject ally;
         int allycount = 1;
         float clampedPos;
         public List<GameObject> allies = new List<GameObject>();
         AudioSource collectSound;

    void FixedUpdate()
    {
       
    }

    void Start()
    {
        allies.Add(gameObject);
    }

    void Awake()
    {
        collectSound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        clampedPos = Mathf.Clamp(gameObject.transform.position.z, -2f, 2f);
        clampedPos = gameObject.transform.position.z;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")
        {
            allycount = allycount * 2;
            PlayerMovement.instance.xSpeed += 6;
            for(int i = 0; i < allycount - 1; i++)
            {
                Instantiate(ally, new Vector3(gameObject.transform.position.x - Random.Range(0.7f, 2f), gameObject.transform.position.y, gameObject.transform.position.z - Random.Range(0.7f, 1f)), Quaternion.Euler(0f, 90f, 0f));
                Destroy(other.gameObject);
                //Debug.Log("spawned");
                
            }
            if(!collectSound.isPlaying)
            collectSound.Play();
        }

        if(other.tag == "Bad Door")
        {
            
            allycount = allycount / 2;
            //for(int i = 0; i < allycount; i++)
            //{
                //if(allycount != 1)
                //Destroy(GameObject.FindGameObjectsWithTag("Ally")[i]);
                //Destroy(other.gameObject);
            //}

            for(int i = 0; i < allycount; i++)
            {
                GameObject allyToDestroy = allies[i];
                allies.RemoveAt(i);
                Destroy(allyToDestroy);
            }
        }
    }
}
