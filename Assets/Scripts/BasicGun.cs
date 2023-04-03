using UnityEngine;




public class BasicGun : MonoBehaviour
{
    [Header("Gun Properties")]
    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] private KeyCode fireGun = KeyCode.Mouse0;

    [SerializeField] public Camera fpsCameraRef;
    [SerializeField] public ParticleSystem muzzleFlash;
    [SerializeField] public GameObject bulletImpact;
    [SerializeField] public float bulletImpactForce;
    [SerializeField] public float rateOfFire;

    private float nextTimeToFire = 0f;

    private void Awake()
    {
        damage = 10f;
        range = 100f;
        rateOfFire = 1f;
        bulletImpactForce = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fireGun) && Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f/rateOfFire;
            Shoot();
        }
    }
    void Shoot() 
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCameraRef.transform.position, fpsCameraRef.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyMovement target = hit.transform.GetComponent<EnemyMovement>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * bulletImpactForce);
            }
            GameObject impactGo = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
