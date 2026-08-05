using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorScript : MonoBehaviour
{
         [SerializeField] GameObject ally;
         int allycount = 1;
         float clampedPos;
         public List<GameObject> allies = new List<GameObject>();
         AudioSource collectSound;
        public static DoorScript doorScript;
        AudioSource badSound;
        [HideInInspector] public GameObject player;
         PlayerMovement playerMovement;
         DoorScript playerDoorScript;
         

    void Start()
    {
        if(gameObject.tag != "Player")
        playerDoorScript.allies.Add(gameObject);
        PlayerMovement.instance.xSpeed = playerMovement.xSpeed;
    }

    void Awake()
    {
        doorScript = this;
        badSound = GameObject.Find("Bad Sound").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerDoorScript = player.GetComponent<DoorScript>();
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
            playerDoorScript.allycount = playerDoorScript.allycount * 2;
            //PlayerMovement.instance.xSpeed += 6;
            for(int i = 0; i < playerDoorScript.allycount - 1; i++)
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
            if(!badSound.isPlaying)
            badSound.Play();


            if(playerDoorScript.allycount > 1)
            {
                playerDoorScript.allycount = playerDoorScript.allycount / 2;

              for(int i = 0; i < playerDoorScript.allycount; i++)
              {
                  GameObject allyToDestroy = playerDoorScript.allies[i];
                  playerDoorScript.allies.RemoveAt(i);
                  Destroy(allyToDestroy);
              }
            }
            Destroy(other.gameObject);
            
        }
    }
}
