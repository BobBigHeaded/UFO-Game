using UnityEngine;

[CreateAssetMenu(fileName = "ClickWeapon", menuName = "Scriptable Objects/ClickWeapon")]
public class ClickWeapon : WeaponBase
{
    public override bool CanShoot(float timeStarted, float timeEnded)
    {
        throw new System.NotImplementedException();
    }
    
    public override float GetProjectileSpeed()
    {
        throw new System.NotImplementedException();
    }
}
