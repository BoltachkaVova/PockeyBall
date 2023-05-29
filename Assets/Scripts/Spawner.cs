using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block blockTemplate;
    [SerializeField] private Segment segmentTemplate;
    [SerializeField] private Finish finishTemplate;
    [SerializeField] private int towerSize;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;

    private void Awake()
    {
        BildTower();
    }
    private void BildTower()
    { 
        GameObject currentTemplate = gameObject;
        for (int i = 0; i < towerSize; i++)
        {
            currentTemplate = BildElement(currentTemplate, segmentTemplate.gameObject);
            currentTemplate = BildElementRandomScale(currentTemplate, blockTemplate.gameObject);
        }
        BildElement(currentTemplate, finishTemplate.gameObject);
    }

    private GameObject BildElement(GameObject currentTemplate, GameObject nextTemplate)
    {
        return Instantiate(nextTemplate, SetSpawnPoint(currentTemplate.transform, nextTemplate.transform), Quaternion.identity, transform);
    }

    private GameObject BildElementRandomScale(GameObject currentTemplate, GameObject nextTemplate)
    {
        nextTemplate.transform.localScale = SetScaleTenplate(nextTemplate);
        return Instantiate(nextTemplate, SetSpawnPoint(currentTemplate.transform, nextTemplate.transform), Quaternion.identity, transform);
    }

    private Vector3 SetSpawnPoint(Transform currentPoint, Transform nextPion)
    {
        return new Vector3(transform.position.x, currentPoint.position.y + currentPoint.localScale.y/2f + nextPion.localScale.y/2f, transform.position.z);
    }

    private Vector3 SetScaleTenplate(GameObject template)
    {
        float random = Random.Range(minScale, maxScale);
        return template.transform.localScale = new Vector3(template.transform.localScale.x, random, template.transform.localScale.z);
    }
}
