using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{

    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 10;
  
    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    //[SerializeField] private GameObject shootVfxPrefab;
    //[SerializeField] private GameObject hitVfxPrefab;
    [SerializeField] private int damage;
    void ShootRay()
    {
        RaycastHit hit; // (ตัวแปรเก็บ Ray ชน object อะไรตอนนี้)

        // วาดเส้น ray ดูระยะ และ debug อื่นๆ
        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        // ยิง invisible ray ออกไปเพื่อเช็คการกระทบ objects แล้วเก็บออกไปใส่ในตัว hit
        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            Debug.DrawRay(shootPos.position, transform.forward * hit.distance, Color.red);
            Debug.Log($"Ray hit: {hit.collider.name}");

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                // เสก prefab vfx จุด
                //GameObject shootVfx = Instantiate(shootVfxPrefab, shootPos.position, Quaternion.identity);
                // เสก prefab vfx จุดโดนยิง
                //GameObject hitVfx = Instantiate(hitVfxPrefab, hit.point, Quaternion.identity);
                //Destroy(shootVfxPrefab, 5);
                //Destroy(hitVfxPrefab, 3);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
                else if (hit.collider.CompareTag("Obstacle"))
                {
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddTorque(0, 50, 0);
                    }
                }
            }
        }
    }
}
