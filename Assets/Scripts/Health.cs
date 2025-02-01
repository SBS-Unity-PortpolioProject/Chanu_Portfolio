using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;

    private int _hp
    {
        get => _hp;
        // HP�� PlayerController������ ���� �ϵ��� private���� ó��
        // Math.Clamp �Լ��� ����ؼ� hp�� 0���� �Ʒ��� �������� �ʰ� �մϴ�.
        set => _hp = Math.Clamp(value, 0, _hp);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        // �÷��̾��� HP ���� �ʱ� �����մϴ�.
        _hp = 100;
        // MaxValue�� �����ϴ� �Լ��Դϴ�.
        SetMaxHealth(_hp);
    }

    public void SetMaxHealth(int health)
    {
        _hpBar.maxValue = health;
        _hpBar.value = health;
    }
    public void GetDamage(int damage)
    {
        int getDamagedHp = _hp - damage;
        _hp = getDamagedHp;
        _hpBar.value = _hp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
