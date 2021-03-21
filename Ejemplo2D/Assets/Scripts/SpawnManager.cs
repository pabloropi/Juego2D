using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bloques;
    public float tiempoMin = 5f;
    public float tiempoMax = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        // Crea un gameObject
        Instantiate(bloques[Random.Range(0, bloques.Length)], transform.position, Quaternion.identity);

        // Para que las corrutinas vuelvan a ejecutarse necesitamos
        StartCoroutine(SpawnCoroutine(Random.Range(tiempoMin, tiempoMax)));


    }
}
