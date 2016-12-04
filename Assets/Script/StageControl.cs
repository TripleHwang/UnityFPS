using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour {
    public GameObject Enemy;
    float SpwanTime,timer;
    //230~120; z축
    //70~230 x축
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        SpwanTime = 5f;
        InvokeRepeating("SpwanEnemy", 2f, SpwanTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>60)
        {
            CancelInvoke();
            SpwanTime -= 1f;
            InvokeRepeating("SpwanEnemy", 5f, SpwanTime);
            timer = 0;
        }
	}
    void SpwanEnemy()
    {
        if (Random.Range(1, 5) == 1)
            Instantiate(Enemy, new Vector3(70, 0.25f, Random.Range(130, 230)), transform.rotation);
        if (Random.Range(1, 5) == 2)
            Instantiate(Enemy, new Vector3(Random.Range(70, 230), 0.25f, 230), transform.rotation);
        if (Random.Range(1, 5) == 4)
            Instantiate(Enemy, new Vector3(Random.Range(70, 230), 0.25f, 120), transform.rotation);
        if (Random.Range(1, 5) == 3)
            Instantiate(Enemy, new Vector3(230, 0.25f, Random.Range(130, 230)), transform.rotation);
    }
}
