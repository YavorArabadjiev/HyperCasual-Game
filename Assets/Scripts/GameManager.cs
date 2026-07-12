using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject cameraFollow;
   [SerializeField] GameObject startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraFollow = GameObject.FindGameObjectWithTag("Player");
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cameraFollow != null)
        Camera.main.transform.position = new Vector3(cameraFollow.transform.position.x - 10, -30, -8.3f);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        Destroy(startButton);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
