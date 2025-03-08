using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float pushStrength = 5f; // Adjust to control push force
    public float maxPushVelocity = 2f; // Limits box push speed

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PressureBox")) // Ensure the box has this tag
        {
            Rigidbody2D boxRB = collision.gameObject.GetComponent<Rigidbody2D>();

            if (boxRB != null)
            {
                Vector2 pushDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

                // Apply force instead of setting velocity directly
                if (Mathf.Abs(boxRB.velocity.x) < maxPushVelocity)
                {
                    boxRB.AddForce(pushDirection * pushStrength, ForceMode2D.Force);
                }
            }
        }
    }
}
