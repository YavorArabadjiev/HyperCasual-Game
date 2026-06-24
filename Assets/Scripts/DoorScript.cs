using UnityEngine;

public class DoorScript : MonoBehaviour
{
         [SerializeField] GameObject ally;
         int allycount = 1;

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")
        {
            for(int i = 0; i <= 10; i++)
            {
                Instantiate(ally, new Vector3(gameObject.transform.position.x - Random.Range(0.7f, 2f), gameObject.transform.position.y, Random.Range(-1.6f, 1.6f)), Quaternion.Euler(0f, 90f, 0f));
                allycount++;
                Debug.Log("spawned");
                
            }
        }
    }
}
