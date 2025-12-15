using UnityEngine;

[CreateAssetMenu(fileName = "ChargedWeapon", menuName = "Scriptable Objects/ChargedWeapon")]
public class ChargedWeapon : WeaponBase
{
    private float _newSpeed;
    public override bool CanShoot(float timeStarted, float timeEnded)
    {
        //calculate the new speed of the projectile
        var timeSpent = timeEnded - timeStarted;
        if (timeSpent > 1f)
        {
            _newSpeed = projectileSpeed;
        }else
        {
            _newSpeed = projectileSpeed * timeSpent;
        }
        
        //the minimum for shooting is 20% of the charge
        return (timeEnded - timeStarted) > 0.2f;
    }

    public override float GetProjectileSpeed()
    {
        return _newSpeed;
    }
}
