using UnityEngine;




public class BasicGun : MonoBehaviour
{
    [Header("Gun Properties")]
    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] private KeyCode fireGun = KeyCode.Mouse0;

    [SerializeField] public Camera fpsCameraRef;
    [SerializeField] public ParticleSystem muzzleFlash;

    private void Awake()
    {
        damage = 10;
        range = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireGun))
        {
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
        }
    }
}
