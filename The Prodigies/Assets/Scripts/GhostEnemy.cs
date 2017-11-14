using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy {

    public GameObject gameObject;

    private float HitPoints;
    private float Speed;
    private int Checkpoint;
    private List<Vector3> Path;

    public GhostEnemy(float hp, float spd, GameObject mob, List<Vector3> path)
    {
        Path = path;
        Checkpoint = 0;
        HitPoints = hp;
        Speed = spd;
        gameObject = mob;
    }
	
    public void Walk()
    {
        if (gameObject.transform.position.Equals(Path[Checkpoint]))
        {
            Debug.Log("CHECKPOINT REACHED");
        }
        else
        {
            gameObject.transform.Translate(Path[Checkpoint] * Speed * Time.deltaTime);
        }
    }

}
