using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    AudioSource breakSound;
   [SerializeField] int wallStrenght = 100;
   [SerializeField] TextMeshProUGUI wallText;
   [SerializeField] GameObject winText;
   [SerializeField] GameObject loseText;
   [SerializeField] GameObject restartButton;
   bool loseTimerStart = false;
   PlayerInputActions inputActions;

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
            winText.SetActive(true);
            restartButton.SetActive(true);
            if(DoorScript.doorScript.player != null)
            {
                Destroy(DoorScript.doorScript.player);
            }
            Destroy(gameObject);
            if(inputActions != null)
            inputActions.Disable();
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ally")
        {
            if (loseTimerStart == false)
            {
              StartCoroutine(loseTimer()); 
              loseTimerStart = true;  
            }
            wallStrenght--;
            Destroy(other.gameObject);
            if (!breakSound.isPlaying)
            {
                breakSound.Play();
            }
        }
    }

    IEnumerator loseTimer()
    {
        yield return new WaitForSeconds(10f);
        loseText.SetActive(true);
        restartButton.SetActive(true);
        if(inputActions != null)
        inputActions.Disable();
    }
}
