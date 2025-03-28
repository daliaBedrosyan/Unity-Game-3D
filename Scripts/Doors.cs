using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BonusType { Addition, Difference, Product, Division }

public class Doors : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider collider;

    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount; 

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch(rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;

            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;

            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "*" + rightDoorBonusAmount;
                break;

            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }

        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "*" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
        }

    }

    public int GetBonusAmount(float playerX)
    {
        float rightDoorX = rightDoorRenderer.transform.position.x;
        float leftDoorX = leftDoorRenderer.transform.position.x;

        if (Mathf.Abs(playerX - rightDoorX) < Mathf.Abs(playerX - leftDoorX))
        {
            return rightDoorBonusAmount; // Player is closer to the right door
        }
        else
        {
            return leftDoorBonusAmount; // Player is closer to the left door
        }
    }

    public BonusType GetBonusType(float playerX)
    {
        float rightDoorX = rightDoorRenderer.transform.position.x;
        float leftDoorX = leftDoorRenderer.transform.position.x;

        if (Mathf.Abs(playerX - rightDoorX) < Mathf.Abs(playerX - leftDoorX))
        {
            return rightDoorBonusType; // Player is closer to the right door
        }
        else
        {
            return leftDoorBonusType; // Player is closer to the left door
        }
    }


    public void Disable()
    {
        collider.enabled = false;
    }

}
