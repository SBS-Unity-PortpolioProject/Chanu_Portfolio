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
        // HP는 PlayerController에서만 수정 하도록 private으로 처리
        // Math.Clamp 함수를 사용해서 hp가 0보다 아래로 떨어지지 않게 합니다.
        set => _hp = Math.Clamp(value, 0, _hp);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        // 플레이어의 HP 값을 초기 세팅합니다.
        _hp = 100;
        // MaxValue를 세팅하는 함수입니다.
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
