/*
 * This script determines how the enemy shoots
 * Which projectile is being shot
 * And the effect of the shot (particle system and sound of the secondary weapon)
 */

using UnityEngine;

public class EnemyShoot : ShootProjectilesBase
{
    [Header("Enemy Shoot")]

    //keep time between firing
    public float startWaitTime;
    private float waitTime;

    //particle system to represent projectile 
    public GameObject projectile1; //main projectile
    [SerializeField] GameObject launchOrigin; //where the projectile will be launched from

    //for projectile 1 to shoot
    public GameObject hardBodyAmmo;
    private GameObject ammo;

    //secondary projectile
    public GameObject projectile2; //secondary projectile

    //for projectile 2 to shoot
    [SerializeField] GameObject launchOrigin2;
    public GameObject hardBodyAmmo2;
    private GameObject ammo2;

    GameObject player;
    public float speed = 700f;

    [SerializeField] ParticleSystem shootParticles2;
    [SerializeField] AudioClip shootSound2;
    [SerializeField] float volume2 = 1f;

    private void Start()
    {
        player = PlayerManager.instance.player;
        waitTime = 0;
    }

    //determines which projectile will be shot
    public void Shoot()
    {
        int i = Random.Range(1, 3); 
        //every so often, FireObject()
        if (waitTime <= 0)
        {
            if(i == 1)
                FireObject(projectile1, launchOrigin);
            else
                FireSecondaryWeapon();
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    //fires the enemy's primary weapon
    public override void FireObject(GameObject projectile, GameObject launchOrigin)
    {
        base.FireObject(projectile1, launchOrigin); //will fire particle representing the projectile

        //fire real projectile while hiding it
        ammo = Instantiate(hardBodyAmmo, launchOrigin.transform.position, transform.rotation);
        ammo.transform.LookAt(player.transform);

        ammo.GetComponent<MeshRenderer>().enabled = false;
        ammo.AddComponent<ParticleMove>();
    }

    //fires the enemy's secondary weapon
    private void FireSecondaryWeapon()
    {
        ball = Instantiate(projectile2, launchOrigin2.transform.position, transform.rotation);

        ammo2 = Instantiate(hardBodyAmmo2, launchOrigin2.transform.position, transform.rotation);
        ammo2.transform.LookAt(player.transform);

        ammo2.GetComponent<MeshRenderer>().enabled = false;
        ammo2.AddComponent<ParticleMove>();

        if (shootParticles2 != null)
        {
            Instantiate(shootParticles2, launchOrigin.transform.position, shootParticles2.transform.rotation);
        }
        if (shootSound2 != null)
        {
            AudioHelper.PlayClip2D(shootSound2, volume2);
        }
    }
}
