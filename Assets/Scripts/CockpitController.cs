using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CockpitController : MonoBehaviour
{
    public Button fireButtonGreen;
    public Button fireButtonRed;

    private bool canFireGreen = true;
    private bool canFireRed = true;

    void Start()
    {
        //add listener botao
        fireButtonGreen.onClick.AddListener(FireGreen);
        fireButtonRed.onClick.AddListener(FireRed);
    }

    void FireGreen()
    {
        if (canFireGreen)
        {
            StartCoroutine("FireGreenCo");

            GameObject laser = Instantiate(Resources.Load(("BulletGreen"), typeof(GameObject))) as GameObject;
            laser.transform.position = Camera.main.transform.position;
            laser.transform.rotation = Camera.main.transform.rotation;
            // laser.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500f);

            laser.GetComponent<AudioSource>().Play();

            Destroy(laser, 3f);
        }
    }

    IEnumerator FireGreenCo()
    {
        canFireGreen = false;
        yield return new WaitForSeconds(0.5f);
        canFireGreen = true;
    }

    void FireRed()
    {
        if (canFireRed)
        {
            StartCoroutine("FireRedCo");   

            GameObject laser = Instantiate(Resources.Load(("BulletRed"), typeof(GameObject))) as GameObject;
            laser.transform.position = Camera.main.transform.position;
            laser.transform.rotation = Camera.main.transform.rotation;
            // laser.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500f);

            laser.GetComponent<AudioSource>().Play();

            Destroy(laser, 3f);
        }
    }

    IEnumerator FireRedCo()
    {
        canFireRed = false;
        yield return new WaitForSeconds(0.5f);
        canFireRed = true;
    }
}
