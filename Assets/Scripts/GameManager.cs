using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
   [SerializeField] GameObject startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x - 10, -30, -8.3f);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        Destroy(startButton);
    }
}
