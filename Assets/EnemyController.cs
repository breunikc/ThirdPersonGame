using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<NavMeshAgent>().destination = target.position;
    }

}
