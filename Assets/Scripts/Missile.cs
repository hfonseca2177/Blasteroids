
using System.Collections;
using UnityEngine;
/*
 * Custom Weapon - Powerful Missile with a wide impact
 */
    public class Missile : Weapon
    {
        private static readonly string IsFired = "isFired";
        private bool _isUsed;

        protected override void Shoot()
        {
            if (!_isUsed)
            {
                LaunchMissile();
                _isUsed = true;
                base.Shoot();
                //StartCoroutine(PrepareLaunchMissile());    
            }
            
        }
        
        
        IEnumerator PrepareLaunchMissile()
        {
            while(true)
            {
                yield return new WaitForSeconds(2f);
                _isUsed = true;
            }
        }

        private void LaunchMissile()
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool(IsFired, true);
            }
        }
    }
