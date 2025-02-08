using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMamager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform Dongle_Group;
    
    void Start()
    {
        NextDongle(); 
    }

    Dongle GetDongle()
    {
        GameObject Instant = Instantiate(donglePrefab, Dongle_Group);
        Dongle instantDongle = Instant.GetComponent<Dongle>();
        return instantDongle;   
    }

    void NextDongle()
    {
       Dongle newDongle = GetDongle();
       lastDongle = newDongle;
    }

    

    public void TouchDown()
    {
        if (lastDongle == null)
            return;
        lastDongle.Drag();
    }

    public void TouchUp()
    {
        if (lastDongle == null)
            return;
        lastDongle.Drop();
        lastDongle = null;
    }
}
