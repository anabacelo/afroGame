using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector2 numberOfObstacles;
    public List<GameObject> newObstacles;
    public List<int> rightPositions; 
    // Start is called before the first frame update
    void Start()
    {
        int newNumberOfObstacles = (int) Random.Range(numberOfObstacles.x,numberOfObstacles.y);
        newObstacles.Clear();
        rightPositions.Add(-10);
        rightPositions.Add(-8);
        rightPositions.Add(-6);
        rightPositions.Add(-4);
        rightPositions.Add(-2);
        rightPositions.Add(0);
        rightPositions.Add(2);
        rightPositions.Add(10);
        rightPositions.Add(8);
        rightPositions.Add(6);
        rightPositions.Add(4);
        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            int range = Random.Range(0, obstacles.Length);
            newObstacles.Add(Instantiate(obstacles[range], transform));
            newObstacles[i].SetActive(false);
        }
        positionateObstacles();

    }

    void positionateObstacles(){
        for (int i = 0; i < newObstacles.Count; i++)
        {
            float posZMin = (300f / newObstacles.Count) + (300f / newObstacles.Count) * i;
            float posZMax = (300f / newObstacles.Count) + (300f / newObstacles.Count) * i + 1;
            int positionOnRoad = rightPositions[Random.Range(0,11)];
            newObstacles[i].transform.localPosition = new Vector3(positionOnRoad, 1, Random.Range(posZMin, posZMax));
            newObstacles[i].SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            transform.position = new Vector3(0,0, transform.position.z + 300f * 2);
            positionateObstacles();
        }
    }


}
