using UnityEngine;
using UnityEngine.UI;

public class SwordScript : MonoBehaviour
{
    public int damagePedang = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth objekMusuh = other.gameObject.GetComponent<EnemyHealth>();
            objekMusuh.TerimaDamage(damagePedang);
            Destroy(gameObject);
        }
    }
}
