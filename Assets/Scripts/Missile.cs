
using System.Collections;
using UnityEngine;
/*
 * Custom Weapon - Limited Powerful Missile with a wide impact
 */
    public class Missile : Weapon
    {   
        private bool _isUsed;

        protected override void Shoot()
        {
            if (!_isUsed)
            {
                _isUsed = true;
                base.Shoot();
            }
            
        }


}
