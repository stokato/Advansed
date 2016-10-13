using UnityEngine;
using System.Collections;

public class TreadMillManager : MonoBehaviour {

    class Obstacle
    {
        static float zposition;

        GameObject obstacle;

        public enum MovementType
        {
            Static,
            Wave,
            Left, 
            Right
        }

        MovementType movementType;

        private float myZposition;

        public Obstacle(PrimitiveType primitive, MovementType movement)
        {
            obstacle = GameObject.CreatePrimitive(primitive);
            movementType = movement;

            myZposition = Random.Range(-10f, 10f);
            obstacle.transform.position =
                new Vector3(Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f));
        }

        public static void UpdatePosition(float z)
        {
            zposition += z;
        }

        public void DrawObstacle()
        {
            Vector3 pos = obstacle.transform.position;
            pos.z = (zposition + myZposition) % 10f;
            obstacle.transform.position = pos;
        }
    }

    private Obstacle[] obstacles;

    public int ObstacleCount = 1000;

    delegate void UpdateObstacles();

    UpdateObstacles treadMillUpdates;

	// Use this for initialization
	void Start () {
        obstacles = new Obstacle[ObstacleCount];

        for(int i = 0; i < ObstacleCount; i++)
        {
            obstacles[i] = new Obstacle(PrimitiveType.Sphere, Obstacle.MovementType.Static);

            treadMillUpdates += new UpdateObstacles(obstacles[i].DrawObstacle);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Obstacle.UpdatePosition(-0.1f);
        treadMillUpdates();
	}
}
