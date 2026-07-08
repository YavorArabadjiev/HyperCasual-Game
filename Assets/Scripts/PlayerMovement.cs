using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputActions inputActions;
    public float xSpeed = 5f;
    public float zSpeed = 15f;
    public static PlayerMovement instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       instance = this;
       inputActions = new PlayerInputActions();
       inputActions.Move.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputs = inputActions.Move.Walking.ReadValue<Vector3>();
        //inputs.x = Mathf.Clamp(inputs.z, -13f, -4f);

       gameObject.transform.Translate(inputs.x * xSpeed * Time.deltaTime, 0, inputs.z * zSpeed * Time.deltaTime);
    }
}
