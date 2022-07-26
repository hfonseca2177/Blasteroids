using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootCooldown = .5f;
    private float nextShootTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(input) && Time.timeSinceLevelLoad >= nextShootTime)
        {
            nextShootTime = Time.timeSinceLevelLoad + shootCooldown;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}