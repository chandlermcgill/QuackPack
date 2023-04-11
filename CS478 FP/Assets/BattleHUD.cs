using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

}

void SetHUD(Unit unit)
{
    nameText.text = unit.unitName;
    levelText.text = "Lvl" + unit.unitLevel;
    hpSlider.maxValue = unit.maxHP;
    hpSlider.value = unit.currentHP;
}

void SetHP(int hp)
{
    hpSlider.Value = hp;
}
