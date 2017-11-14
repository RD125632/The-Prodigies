using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs : MonoBehaviour {

    public Transform mapTransform;
    public GameObject mob;

    private int mobCount;
    private List<GhostEnemy> mobs;
    private GhostEnemy newEnemy;

    // Use this for initialization
    void Start () {
        mobCount = 0;
        mobs = new List<GhostEnemy>();
    }

    // Update is called once per frame
    void Update () {
        SpawnMobs();
        mobs.ForEach(x => x.Walk());
    }

    void SpawnMobs()
    {
        if (mobCount < 10)
        {
            Vector3 mobPosition = new Vector3(55.0f, 4.0f, Random.value * 10 + 7);

            GameObject newGameObject = Instantiate(mob, mobPosition, mob.transform.rotation, mapTransform);
            newGameObject.transform.rotation *= Quaternion.Euler(0, -90, 0);
            newGameObject.transform.localScale += new Vector3(4.0f, 4.0f, 4.0f);

            newEnemy = new GhostEnemy(100.0f, Random.value * 5 + 2, newGameObject, GeneratePath());
            mobs.Add(newEnemy);
        }

        mobCount++;
    }

    List<Vector3> GeneratePath()
    {
        List<Vector3> path = new List<Vector3>();
        //Vector3 SpawnPoint = new Vector3(55.0f, 4.0f, Random.value * 10 + 7);         // SpawnPoint
        path.Add(new Vector3(Random.value * 2 - 1, 4.0f, Random.value * 10 + 7));       // TurnLeft
        path.Add(new Vector3(Random.value * 2 - 1, 4.0f, -(Random.value * 10 + 7)));    // TurnRight
        path.Add(new Vector3(-55.0f, 4.0f, -(Random.value * 10 + 7)));                  // Finish
        return path;
    }
}
