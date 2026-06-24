using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputActions inputActions;
    [SerializeField] float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       inputActions = new PlayerInputActions();
       inputActions.Move.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputs = inputActions.Move.Walking.ReadValue<Vector3>();

       gameObject.transform.Translate(inputs.x * speed * Time.deltaTime, 0, inputs.z * speed * Time.deltaTime);
    }
}
