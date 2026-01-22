using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxDarahMusuh = 100;
    public int darahMusuh;
    public int isiUlangDarah = 2;
    public Slider healthBar;

    private void Start()
    {
        darahMusuh = maxDarahMusuh;
        healthBar.maxValue = maxDarahMusuh;
        healthBar.value = darahMusuh;
    }

    public void TerimaDamage(int damageMasuk)
    {
        darahMusuh = darahMusuh - damageMasuk;
        healthBar.value = darahMusuh;
    }

    private void Update()
    {
        if ((darahMusuh <= 50) && (isiUlangDarah > 0))
        {
            darahMusuh = darahMusuh + 30;
            isiUlangDarah = isiUlangDarah - 1;
        }

        if (darahMusuh <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar.gameObject);
        }
    }
}
