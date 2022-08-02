using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Transform startPoint;
    public float spawnRate = 1f;
    public int convayorVerlocity;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private void OnCollisionStay(Collision collision)
    {
        Transition(collision.gameObject);
    }

    private void Transition(GameObject Trash)
    {
        if (Trash.TryGetComponent<Rigidbody>(out Rigidbody component))
        {
            component.velocity = gameObject.transform.right * Time.deltaTime * convayorVerlocity;
        }
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            //get obj from pool
            GameObject trash = ObjectPool.SharedInstance.GetPooledObject();
            if (trash != null)
            {
                OnSpawn(trash);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void OnSpawn(GameObject trash)
    {
        trash.transform.position = startPoint.position;
        trash.transform.rotation = startPoint.rotation;
        trash.gameObject.layer = LayerMask.NameToLayer("Trash");
        trash.SetActive(true);
    }
}
