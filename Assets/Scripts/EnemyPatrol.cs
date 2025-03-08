using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform player;
    public float speed = 2f;
    public float visionLength = 5f;
    public float visionAngle = 40f;
    public LayerMask obstacleLayer;

    private int currentPointIndex = 0;
    public bool isPaused = false;
    private int facingDirection = 1; // 1 for right, -1 for left

    void Update()
    {
        if (!isPaused)
        {
            Patrol();
        }

        CheckVision();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0 || isPaused) return;

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position.x < patrolPoints[currentPointIndex].position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingDirection = 1; // Enemy facing right
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingDirection = -1; // Enemy facing left
        }

        if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    void CheckVision()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector2.Angle(facingDirection * Vector2.right, directionToPlayer);

        if (angleToPlayer < visionAngle / 2 && Vector2.Distance(transform.position, player.position) <= visionLength)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionLength);

            if (hit.collider != null)
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                isPaused = true;
            }
            else
            {
                isPaused = false;
            }
        }
        else
        {
            isPaused = false;
        }
    }

    // **Draw Vision Cone in Scene View**
    void OnDrawGizmos()
    {
        if (visionLength <= 0) return;

        // Set Gizmo color
        Gizmos.color = new Color(1, 1, 0, 0.3f); // Yellow with transparency

        // **Use facing direction to flip the vision cone**
        Vector3 forward = facingDirection * Vector3.right;

        // Calculate left and right boundaries of the vision cone
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -visionAngle / 2) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, visionAngle / 2) * forward;

        // Convert to world space
        Vector3 leftEdge = transform.position + leftBoundary * visionLength;
        Vector3 rightEdge = transform.position + rightBoundary * visionLength;

        // Draw the vision cone as a solid shape
        Gizmos.DrawLine(transform.position, leftEdge);
        Gizmos.DrawLine(transform.position, rightEdge);
        Gizmos.DrawWireSphere(transform.position + forward * visionLength, 0.1f); // Small circle at max range

        // Fill the cone using a triangle
        Gizmos.color = new Color(1, 1, 0, 0.1f); // Even more transparent yellow
        Vector3[] coneVertices = { transform.position, leftEdge, rightEdge };
        Gizmos.DrawMesh(CreateMesh(coneVertices));
    }

    // **Helper method to create a mesh for the vision cone**
    Mesh CreateMesh(Vector3[] vertices)
    {
        Mesh mesh = new Mesh();
        int[] triangles = { 0, 1, 2 }; // Triangle indices
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        return mesh;
    }
}
