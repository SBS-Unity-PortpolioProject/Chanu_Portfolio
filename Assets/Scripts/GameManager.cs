using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMamager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform Dongle_Group;

    public int MaxLevel;
    public int Score;
    
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
       lastDongle.Manager = this;
       lastDongle.level = Random.Range(0, MaxLevel);
       lastDongle.gameObject.SetActive(true);

       StartCoroutine(WaitNext());
    }

    IEnumerator WaitNext()
    {
        while (lastDongle != null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

        NextDongle() ;
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
