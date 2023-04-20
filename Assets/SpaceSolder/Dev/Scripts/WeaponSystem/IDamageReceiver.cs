using UnityEngine;

public interface IDamageReceiver
{
    public void GetDamage(float damage, RaycastHit hit);
}
