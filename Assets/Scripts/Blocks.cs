using UnityEngine;

public class Blocks : MonoBehaviour
{

    [SerializeField] float health = 100f;

    public void AddDamage(float damage)
    {
        health -= damage;

        if (health < 0)
            Destroy(gameObject);
    }
}
