using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnersSystem : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform runnersParent;
    [SerializeField] private GameObject runnerPrefab;

    [Header("Settings")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    void Start()
    {

    }

    void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch(bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount); 
                break;
            case BonusType.Product:
                int runnersToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnersToAdd);
                break;
            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                break;
            case BonusType.Division:
                int runnersToRemove = runnersParent.childCount - (runnersParent.childCount / bonusAmount);
                RemoveRunners(runnersToRemove);
                break;
        }
    }
    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newRunner = Instantiate(runnerPrefab, runnersParent);

            Transform bottomObject = newRunner.transform.Find("bottom");
            if (bottomObject != null)
            {
                Destroy(bottomObject.gameObject);
            }

            float scaleFactor = 1f + (runnersParent.childCount * 0.005f); 
            newRunner.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }

    private void RemoveRunners(int amount)
    {
        int runnersAmount = runnersParent.childCount;
        amount = Mathf.Min(amount, runnersAmount);

        List<Transform> runnersToRemove = new List<Transform>();

        for (int i = 0; i < amount; i++)
        {
            Transform runner = runnersParent.GetChild(runnersParent.childCount - 1);
            if (runner != null)
            {
                runnersToRemove.Add(runner);
            }
        }

        foreach (Transform runner in runnersToRemove)
        {
            if (runner != null)
            {
                runner.SetParent(null);
                Destroy(runner.gameObject);
            }
        }
    }




}
