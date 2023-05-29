using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float speed;
    [SerializeField] private float offsetY;

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, ball.transform.position.y - offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }
}
