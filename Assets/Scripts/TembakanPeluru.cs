using UnityEngine;

public class TembakanPeluru : MonoBehaviour
{
    public GameObject bahanPeluru;
    public Transform wadahPeluru;
    public float kecepatanPeluru = 10f;

    void Start()
    {
        // Kunci kursor (pake script manager kamu yang tadi juga boleh)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        bool tekanMouse = Input.GetMouseButtonDown(0);

        if (tekanMouse)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject peluruBaru = Instantiate(bahanPeluru, wadahPeluru.position, wadahPeluru.rotation);
        Rigidbody rbPeluru = peluruBaru.GetComponent<Rigidbody>();

        if (rbPeluru != null)
        {
            rbPeluru.linearVelocity = wadahPeluru.forward * kecepatanPeluru;
        }

        Destroy(peluruBaru, 2f);
    }
}
