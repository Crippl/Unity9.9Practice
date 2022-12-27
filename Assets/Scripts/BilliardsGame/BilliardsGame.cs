using UnityEngine;

public class BilliardsGame : MonoBehaviour
{
    [SerializeField] private byte power;
    void Start()
    {
        Vector3 direction = new Vector3(0, 0, -10);
        GetComponent<Rigidbody>().AddForce(direction*power, ForceMode.Impulse);
    }
}
