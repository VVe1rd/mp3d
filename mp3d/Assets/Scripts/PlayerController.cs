using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSpeed = 6f;
 
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent <PlayerMotor> ();
    }

    void Update()
    {
        // Calculating movement velocity as a 3D vector
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        // Final movement velocity
        Vector3 velocity = (0.6f * movHor + movVer).normalized * speed;

        // Apply movement
        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSpeed;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;

        motor.RotateCam(camRotation);
    }
}
