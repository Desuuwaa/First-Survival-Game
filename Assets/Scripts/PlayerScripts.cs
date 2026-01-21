using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScripts : MonoBehaviour
{
    public float kecepatan = 5.0f;
    public float kekuatanLompat = 5.0f;
    public TextMeshProUGUI textSkor;

    private Rigidbody rb;
    private bool isGrounded = true;
    private int jumlahKoin = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateTampilanSkor();
    }

    private void Update()
    {
        float gerakKiriKanan = Input.GetAxis("Horizontal");
        float gerakMajuMundur = Input.GetAxis("Vertical");
        Vector3 arahGerakan = new Vector3(gerakKiriKanan, 0, gerakMajuMundur) * kecepatan;
        Vector3 arahLompatan = new Vector3(0, kekuatanLompat, 0);

        rb.linearVelocity = new Vector3(arahGerakan.x, rb.linearVelocity.y, arahGerakan.z);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(arahLompatan, ForceMode.Impulse);
            isGrounded = false;
        }

        if (transform.position.y < -7f)
        {
            string sceneSaatIni = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneSaatIni);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Kena tanah!");
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            jumlahKoin = jumlahKoin + 1;
            UpdateTampilanSkor();
        }
    }

    private void UpdateTampilanSkor()
    {
        textSkor.text = "Skor: " + jumlahKoin.ToString();
    }
}
