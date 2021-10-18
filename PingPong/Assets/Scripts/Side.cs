using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Side : MonoBehaviour
{
    public int random;
    private TextMeshPro textMeshPro;
    private BoxCollider boxCollider;
  
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        random  = Random.Range(1, 10);
        textMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
        textMeshPro.text = random.ToString();
        StartCoroutine(SpawnHuman());
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Ball")
        {
            boxCollider.enabled = false;
            StartCoroutine(SpawnHuman());
           
        }
    }

    IEnumerator SpawnHuman()
    {
       
      
        for (int i = 0; i < random; i++)
        {
          
            GameObject bullet = GameManager.SharedInstance.GetPooledObject();
            bullet.transform.position = gameObject.transform.position;
            bullet.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
