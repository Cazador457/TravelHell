using UnityEditor;
using UnityEngine;
public class Gun : MonoBehaviour
{
    enum ForceType { None, AddForce, Immediate, Impulse }
    enum ShootType { None, Raycast, Projectile }
    enum BulletType { None, Antipersonnel, Antitank, Normal, Ricochet }
    [SerializeField]private ShootType shootType;
    [SerializeField]private BulletType bulletType;
    public GameObject bulletPrefab;

    public Transform spawn;

    private float elapsedFireTime;
    public float cooldown = .25f;
    void Update()
    {
        elapsedFireTime += Time.deltaTime;
        //if (elapsedFireTime >= cooldown) { elapsedFireTime = 0; Shoot(); }
    }
    public void Shoot()
    {
        switch (shootType)
        {
            case ShootType.Projectile:
                switch (bulletType)                                                                               
                {                                                                                                 
                    case BulletType.None:                                                                         
                        print("Definir Tipo de Bala");                                                            
                        break;                                                                                    
                    case BulletType.Normal:                                                                       
                        GameObject bullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);   
                        bullet.GetComponent<Bullet>().direction = transform.parent.forward;
                        break;                                                                                    
                    case BulletType.Antipersonnel:                                                                
                        break;                                                                                    
                    case BulletType.Antitank:                                                                     
                        break;                                                                                    
                }                                                                                                 
                break;
            case ShootType.Raycast:
                break;
        }
    }
}
