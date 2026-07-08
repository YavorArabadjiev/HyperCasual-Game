using System;
using TMPro;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    AudioSource breakSound;
   [SerializeField] int wallStrenght = 100;
   [SerializeField] TextMeshProUGUI wallText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        wallText.text = wallStrenght.ToString();

        if(wallStrenght <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ally")
        {
            wallStrenght--;
            Destroy(other.gameObject);
            if (!breakSound.isPlaying)
            {
                breakSound.Play();
            }
        }
    }
}
