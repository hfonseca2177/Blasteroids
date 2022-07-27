using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Special Projectile that spawns a impact zone
 */
public class ProjectileWithImpactZone : Projectile
{
    // Start is called before the first frame update

    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 3f;
    [SerializeField] private float triggerAt = 2f;
    [SerializeField] private float duration = 10f;
    [SerializeField] private GameObject impactZone;

    private float timeElapsed = 0;
    private bool zoneUp;    
    private GameObject instantiatedImpactZone;
    private float currentScale;

    

    // Update is called once per frame
    void Update()
    {
        this.timeElapsed += Time.deltaTime;
        
        if(timeElapsed > triggerAt && !zoneUp)
        {
            zoneUp = true;
            SpawnImpactZone();            
        }



        if(timeElapsed > duration)
        {
            Destroy(this);
        }
        else
        {
            MagnifyImpactZone();
        }       

        
    }

    private void SpawnImpactZone()
    {
        instantiatedImpactZone = Instantiate(impactZone, this.transform);
    }

    private void MagnifyImpactZone()
    {
        instantiatedImpactZone.transform.localScale.Set(currentScale, currentScale,currentScale);
    }


}
