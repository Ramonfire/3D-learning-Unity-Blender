
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{


    
    //gunstats
    public int damage;
    public float timeBetweenShooting, spread, range,reloadTime, fireRate;
    public int magazineSize, bulletPerTap;
    public bool allowedToHold;
    int bulletsLeft, bulletsShot;

    //boolean
    bool shooting, readyToShoot, reloading;
    //references

    public Transform Offset;
    public Camera MainCam;
    public RaycastHit raycast;
    public LayerMask enemy;

    public TextMeshProUGUI text;

    //Graphics
    public GameObject bulletHole;
    public GameObject muzzleFlash;
    public GameObject blood;


    protected virtual void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }


    protected virtual void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
    }








   
    private void MyInput()
    {
        if (allowedToHold) { shooting = Input.GetKey(KeyCode.Mouse0); }
        else { shooting = Input.GetKeyDown(KeyCode.Mouse0); }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft<magazineSize && !reloading)
        {
            reload();
        }

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletPerTap;
            shoot();
        }
        }

    private void shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = MainCam.transform.forward + new Vector3(x, y, 0);
        if (Physics.Raycast(MainCam.transform.position,direction,out raycast, range, enemy))
        {
            if (raycast.collider.CompareTag("enemy"))
            { 
                raycast.collider.GetComponent<EnemyAi>().takeDamage(damage); 
              //  Instantiate(blood, raycast.point, Quaternion.Euler(0, 180, 0));

            }
            else { 
          //  Instantiate(bulletHole, raycast.point, Quaternion.Euler(0, 180, 0));
            }
        }

        
      //  Instantiate(muzzleFlash, Offset.position,Quaternion.identity);



        bulletsLeft--;
        bulletsShot--;
        Invoke("resetShooting", timeBetweenShooting);

        if(bulletsLeft>0 && bulletsShot > 0)
        {
            Invoke("shoot", fireRate);
        }
    }

    private void resetShooting()
    {
        readyToShoot = true;
    }


    private void reload()
    {
        reloading = true;
        Invoke("reloadFinish", reloadTime);
    }


    private void reloadFinish()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }













}
