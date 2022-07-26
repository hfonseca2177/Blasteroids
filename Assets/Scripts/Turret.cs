using UnityEngine;
    public class Turret: Weapon
    {
        [SerializeField] private float minAngle = -60f;
        [SerializeField] private float maxAngle = 60f;
        [SerializeField] private float rotationPerShot = 10f;
        [SerializeField] private float currentYAngle = 0f;

        protected override void Shoot()
        {
            //Debug.Log(transform.rotation.y);
            //Debug.Log(transform.eulerAngles.y);
            currentYAngle = UnityEditor.TransformUtils.GetInspectorRotation(transform).y;
            float newYAngle = currentYAngle + rotationPerShot;
            if (newYAngle < minAngle || newYAngle > maxAngle)
            {
                rotationPerShot *= -1;
            }

            Vector3 rotation = new Vector3(0, rotationPerShot, 0);
            transform.Rotate(rotation);
            
            base.Shoot();
        }
        
    }
