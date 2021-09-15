using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : ShootProjectiles
{
    [Header("Player Shoot")]
    public GameObject projectile1; //primary projectile
    public GameObject projectile2; //secondary projectile
    public GameObject projectile3; //tertiary projectile
    private GameObject selectedProjectile, unselectedProjectile, thirdHoldingPlace;
    [SerializeField] GameObject launchOrigin; //where the projectile will be launched from
    public int mouseScrollInt;

    public TextMeshProUGUI displaySelectedProjectile;

    private void Start()
    {
        selectedProjectile = projectile1;
        unselectedProjectile = projectile2;
        mouseScrollInt = 1;
        displaySelectedProjectile.text = ("You have damage projectile active. Scroll up or down to change");
    }

    // Update is called once per frame
    void Update()
    {
        ScrollWeapons();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireObject(selectedProjectile, launchOrigin);
        }
    }

    private void ScrollWeapons()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            Debug.Log("mouse up");
            mouseScrollInt++;
            if (mouseScrollInt > 3)
            {
                mouseScrollInt = 1;
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            Debug.Log("mouse down");
            mouseScrollInt--;
            if (mouseScrollInt < 1)
            {
                mouseScrollInt = 3;
            }
        }

        switch (mouseScrollInt)
        {
            case 1:
                selectedProjectile = projectile1;
                Debug.Log("Projectile " + selectedProjectile + " is active");
                displaySelectedProjectile.text = ("You have \"damage\" projectile active. Scroll up or down to change");
                break;
            case 2:
                selectedProjectile = projectile2;
                Debug.Log("Projectile " + selectedProjectile + " is active");
                displaySelectedProjectile.text = ("You have \"explosive\" projectile active. Scroll up or down to change");
                break;
            case 3:
                selectedProjectile = projectile3;
                Debug.Log("Projectile " + selectedProjectile + " is active");
                displaySelectedProjectile.text = ("You have \"lock on\" projectile active. Scroll up or down to change");
                break;

        }
    }

    public override void FireObject(GameObject projectile, GameObject launchOrigin)
    {
        base.FireObject(selectedProjectile, launchOrigin);
        if(ball != null)
            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, launchVelocity);
    }
}
