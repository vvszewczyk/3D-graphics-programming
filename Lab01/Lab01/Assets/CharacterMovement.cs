using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float accel = 400.0f;
    public float maxSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public Animator anim;

    private Vector3 moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= accel * Time.deltaTime;

        rb.AddForce(moveDirection);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        Vector3 vel = rb.linearVelocity;
        if (vel.magnitude > maxSpeed)
        {
            rb.linearVelocity = vel.normalized * maxSpeed;
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
