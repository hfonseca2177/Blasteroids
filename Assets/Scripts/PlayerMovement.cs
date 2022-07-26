using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 currentViewportPosition;
    [SerializeField] private float rotationTime = 0.1f;
    [SerializeField] private float rotationAngle = 75f;
    
    
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Move();
        ClampPosition();
        RotateSpaceship();
    }

    private void Move()
    {
        transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }

    private void ClampPosition()
    {
        if(Camera.main == null) return;
        //Convert world position into viewport position
        currentViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        //Clamp the values of the edge of the screen
        currentViewportPosition.x = Mathf.Clamp(currentViewportPosition.x, 0.15f, 0.85f);
        currentViewportPosition.y = Mathf.Clamp(currentViewportPosition.y, 0.15f, 0.85f);
        //Convert back viewport position to world position
        transform.position = Camera.main.ViewportToWorldPoint(currentViewportPosition);
    }

    private void RotateSpaceship()
    {
        Quaternion localRotation = transform.localRotation;
        float rotationX = Mathf.LerpAngle(localRotation.x, -vertical * rotationAngle, rotationTime);
        float rotationZ = Mathf.LerpAngle(localRotation.z, -horizontal * rotationAngle, rotationTime);
        transform.localRotation = Quaternion.Euler(rotationX, localRotation.y, rotationZ);
    }

}
