using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : ShootProjectiles
{
    [Header("Player Shoot")]
    public GameObject projectile1; //main projectile
    public GameObject projectile2; //secondary projectile
    private GameObject selectedProjectile, unselectedProjectile, thirdHoldingPlace;
    [SerializeField] GameObject launchOrigin; //where the projectile will be launched from

    public TextMeshProUGUI displaySelectedProjectile;

    private void Start()
    {
        selectedProjectile = projectile1;
        unselectedProjectile = projectile2;
        SelectedProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Projectile " + selectedProjectile + " is active");
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Right mouse has been clicked");
            
            thirdHoldingPlace = unselectedProjectile;
            unselectedProjectile = selectedProjectile;
            selectedProjectile = thirdHoldingPlace;
            SelectedProjectile();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireObject(selectedProjectile, launchOrigin);
        }
    }

    public override void FireObject(GameObject projectile, GameObject launchOrigin)
    {
        base.FireObject(selectedProjectile, launchOrigin);
        if(ball != null)
            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, launchVelocity);
    }

    private void SelectedProjectile()
    {
        if(selectedProjectile == projectile1)
        {
            displaySelectedProjectile.text = ("You have damage projectile active. Right click to switch projectile");
        }
        if (selectedProjectile == projectile2)
        {
            displaySelectedProjectile.text = ("You have explosive projectile active. Right click to switch projectile");
        }
    }
}
