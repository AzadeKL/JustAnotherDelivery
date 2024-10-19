using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeedManager : UpgradePanelManagerTextBase
{
    [SerializeField] private string upgradeLabel = "Travel Speed Multiplier";
    [SerializeField] private int costPerLevel = 2;
    [SerializeField] private float value = -1;
    [SerializeField] private float nextValue = -1;

    private void Start()
    {
        SetVars();
    }
    protected override string GetUpgradeLabel()
    {
        return upgradeLabel;
    }

    protected override void DoUpgrade()
    {
        GameManager.instance.speedMultiplier = nextValue;
    }
    protected override void UpdateValues()
    {
        value = GameManager.instance.speedMultiplier;
        nextValue = value + 1;
    }
    protected override string GetCurrentValue()
    {
        return value.ToString() + "x";
    }

    protected override string GetNextValue()
    {
        return nextValue.ToString() + "x";
    }

    protected override int GetUpgradeCost()
    {
        return (int)(nextValue * costPerLevel);
    }

    protected override bool HasUpdatedValue()
    {
        return value != GameManager.instance.speedMultiplier;
    }
}
