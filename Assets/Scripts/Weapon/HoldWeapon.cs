using UnityEngine;

[CreateAssetMenu(fileName = "HoldWeapon", menuName = "Scriptable Objects/HoldWeapon")]
public class HoldWeapon : WeaponBase
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
