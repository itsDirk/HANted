using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Color = System.Drawing.Color;

[ExecuteInEditMode]
public class HitEffect : MonoBehaviour
{
    [Range(0f, 1000f)]
    public float Health = 1000f; 
    private float maxHealth = 1000f; 
    public GameObject player;

    Vignette vignette;

    void Start()
    {
        
        Volume volume = gameObject.GetComponent<Volume>();

  
        if (volume != null && volume.profile.TryGet(out vignette))
        {
          
            vignette.intensity.value = 0f; 
            // vignette.color.value = Color.black; 
            vignette.color.value = UnityEngine.Color.red;
        }
        else
        {
            Debug.LogError("Vignette effect not found on the Volume Profile!");
        }
    }

  
    void Update()
    {

        Health = Mathf.Clamp(Health, 0, maxHealth);

        // if (Health > 0 && Health < 100)
        // {
        //     vignette.intensity.value = 0.7f;
        // }
        //
        // if (Health > 100 && Health < 200)
        // {
        //     vignette.intensity.value = 0.55f;
        // }
        //
        // if (Health > 200 && Health < 300)
        // {
        //     vignette.intensity.value = 0.45f;
        // }
        //
        // if (Health > 300 && Health < 400)
        // {
        //     vignette.intensity.value = 0.35f;
        // }
        //
        // if (Health > 400 && Health < 500)
        // {
        //     vignette.intensity.value = 0.3f;
        // }
        //
        // if (Health > 500 && Health < 600)
        // {
        //     vignette.intensity.value = 0.25f;
        // }
        //
        // if (Health > 600 && Health < 700)
        // {
        //     vignette.intensity.value = 0.3f;
        // }
        //
        // if (Health > 700 && Health < 800)
        // {
        //     vignette.intensity.value = 0.1f;
        // }
        //
        // if (Health > 800 && Health < 900)
        // {
        //     vignette.intensity.value = 0.05f;
        // }
        //
        // if (Health > 900 && Health < 1000)
        // {
        //     vignette.intensity.value = 0.01f;
        // }
        
        vignette.intensity.value = 1 - (Health / maxHealth);

    }


    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        
        if (Health <= 0)
        {
            player.transform.position = new Vector3(-19, 1, 0);
            Health = maxHealth;
        }
    }
}
