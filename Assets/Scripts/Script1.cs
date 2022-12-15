using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    public Transform myPrefab;
    public Transform monsterPrefab;

    [SerializeField]
    private int _spawnNumber = 10;
    [SerializeField]
    private int _spawnNumberMonsters = 10;

    private int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn(_spawnNumber, myPrefab);
        spawn(_spawnNumberMonsters, monsterPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> i)
        {
            i += 10;
            spawn(1, monsterPrefab);
        }
    }

    /**
     * Spawns new Prefabs up to the number passed as the argument
     */
    void spawn(int spawnCount, Transform prefab)
    {
        for(int i = 0; i < spawnCount; i = i+1)
        {
            float x = UnityEngine.Random.Range(-25f,25f);
            float y = 1f;
            float z = UnityEngine.Random.Range(-25f,25f);
            Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}
