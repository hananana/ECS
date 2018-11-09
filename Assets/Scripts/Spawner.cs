using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int count;
    public GameObject prefab;
    public GameObject classic;
    int total;

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 100), "JOBECS"))
        {
            spawn(this.prefab);
            this.total += this.count;
        }
        if(GUI.Button(new Rect(0, 100, 100, 100), "CLASSIC"))
        {
            spawn(this.classic);
            this.total += this.count;
        }

        GUI.Label(new Rect(100, 0, 100, 100), this.total.ToString());
    }

    void spawn(GameObject prefab)
    {
        for (int i = 0; i < this.count; i++)
        {
            var pos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            var go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            go.transform.position = pos;

        }
    }
}
