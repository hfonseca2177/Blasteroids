using UnityEngine;
/*
 * Custom Weapon - Limited use Powerful Missile weapon
 */
    public class Missile : Weapon
    {
        [Header("How many times the missile weapon can be used")]
        [SerializeField] private int useLimit = 3;
        private int _useCount;

        protected override void Shoot()
        {
            if (_useCount >= useLimit) return;
            
            _useCount++;
            base.Shoot();
        }


}
