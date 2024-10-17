using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeedManager : UpgradePanelManagerTextBase
{
    [SerializeField] private string upgradeLabel = "Travel Speed Multiplier";
    [SerializeField] private float costPerLevel = 2;
    [SerializeField] private Player player;
    [SerializeField] private float value = -1;
    [SerializeField] private float nextValue = -1;

    private void Start()
    {
        SetVars();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    protected override string GetUpgradeLabel()
    {
        return upgradeLabel;
    }

    protected override void DoUpgrade()
    {
        player.speedMultiplier = nextValue;
        UpdateValues();
    }
    protected override void UpdateValues()
    {
        value = player.speedMultiplier;
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

    protected override float GetUpgradeCost()
    {
        return nextValue * costPerLevel;
    }

    protected override bool HasUpdatedValue()
    {
        return value != player.speedMultiplier;
    }
}
