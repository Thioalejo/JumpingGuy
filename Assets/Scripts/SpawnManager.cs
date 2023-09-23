using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance {  get; private set; }
    public GameObject EnemyPrefab;
    public float spawnTime = 2;
    void Awake()
    {
        Instance = this;
    }
  
    //Iniciar la generaci�n
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    //Encargado de generar el enemigo
    void SpawnEnemy()
    {
      Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }
    //Para detener la generaci�n
    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
}
