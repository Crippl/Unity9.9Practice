using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] private float explosionFrequency;
    [SerializeField] private float explosionPower;
    [SerializeField] private float explosionRadius;
    private Vector3 boomPoint;

    private void Start()
    {
        boomPoint = transform.position;
    }

    private void Update()
    {
        explosionFrequency -= Time.deltaTime;
        if (explosionFrequency <= 0)
        {
            Boom();
        }
    }

    private void Boom()
    {
        Rigidbody[] objects = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody obj in objects)
        {
            Vector3 objectPosition = obj.transform.position;
            if (Vector3.Distance(boomPoint, obj.transform.position) < explosionRadius)
            {
                Vector3 direction = objectPosition-boomPoint;
                obj.AddForce((explosionRadius - Vector3.Distance(boomPoint, objectPosition))
                    * explosionPower * direction.normalized,ForceMode.Impulse);
            }
        }
        explosionFrequency = 2;
    }
}
