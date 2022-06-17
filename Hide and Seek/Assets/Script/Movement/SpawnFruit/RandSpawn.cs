using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandSpawn : MonoBehaviour
{
    public string spawnPointTag = "Fruit";
	public bool alwaysSpawn = true;
	
	public List<GameObject> prefabsToSpawn;
	
    // Start is called before the first frame update
    public void StartButtonPress()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
		foreach(GameObject spawnPoint in spawnPoints){
			int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
			if (alwaysSpawn) {
				GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
                Vector3 v = new Vector3(0, 14 , 0);
				pts.transform.position = spawnPoint.transform.position - v;
			} else {
				int spawnOrNot = Random.Range(0, 2);
				if(spawnOrNot == 0){
					GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
					pts.transform.position = spawnPoint.transform.position;
				}
			}
		}
    }
}
