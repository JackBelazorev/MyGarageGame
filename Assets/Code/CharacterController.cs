using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 300f;

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (movement != Vector3.zero)
        {
            RotateCharacter(movement);
        }
    }

    private void RotateCharacter(Vector3 movement)
    {
        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
