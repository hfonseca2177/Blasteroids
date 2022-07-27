using UnityEngine;

/*
 * Special Projectile that spawns a impact zone
 */
public class ProjectileWithImpactZone : Projectile
{
    [Header("After how much time spawns the Impact Zone")]
    [SerializeField] private float triggerAt = 2f;
    [Header("Impact Zone prefab")]
    [SerializeField] private GameObject impactZone;
    private float _timeElapsed;
    
    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (!(_timeElapsed > triggerAt)) return;
        
        SpawnImpactZone();
        Destroy(gameObject);
    }

    /**
     * Instantiate impact zone at projectile current position
     */
    private void SpawnImpactZone()
    {
        Instantiate(impactZone, this.transform.localToWorldMatrix.GetPosition(), Quaternion.identity);
    }

}
