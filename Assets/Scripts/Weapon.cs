using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootCooldown = .5f;
    private float _nextShootTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(input) && Time.timeSinceLevelLoad >= _nextShootTime)
        {
            _nextShootTime = Time.timeSinceLevelLoad + shootCooldown;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}