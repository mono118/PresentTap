using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class BoxGenerator : MonoBehaviour
{
    public GameObject RedBoxPrefab;
    public GameObject BlueBoxPrefab;
    public GameObject GreenBoxPrefab;
    public GameObject cakePrefab;
    Dictionary<int, GameObject> presents;

    // Start is called before the first frame update
    void Start()
    {
        presents = new Dictionary<int, GameObject>{
            {0, RedBoxPrefab},
            {1, BlueBoxPrefab},
            {2, GreenBoxPrefab},
            {3, cakePrefab}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンが押された時にプレゼントを生成
    public void PresentGeneration(){
        GameObject boxPrefab = presents[Random.Range(0, 4)];
        GameObject Generate = Instantiate(boxPrefab);
        int px = Random.Range(-2, 2);
        Generate.transform.position = new Vector3(px, 5, 0);
    }
}
