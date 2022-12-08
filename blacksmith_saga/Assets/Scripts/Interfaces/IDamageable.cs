using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IDamageable
    {
        float Health { set; get; }

        void OnHit(float damage, Vector2 knockback);

        void OnHit(float damage);
    }
}