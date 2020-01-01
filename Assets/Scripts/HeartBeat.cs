using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public float maxDistanceBeforeHearing = 10; // on fait en radial mais si on voulait faire un bon truc on calculerait un bon chemin
    bool playSound = false;

    public bool isSourd = false;
    bool isAccouphene = false;

    public float retryTimeSourd = 5.0f;
    public int randomSourd = 4;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("Silence", 1);
        GetComponents<FMODUnity.StudioEventEmitter>()[0].Play();
        GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("Silence", 1);

        GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 1);
        GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("pitch", 0.43f);
        GetComponents<FMODUnity.StudioEventEmitter>()[1].Play();

        GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 1);
        GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("pitch", 0.43f);
        GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 1);
        GetComponents<FMODUnity.StudioEventEmitter>()[2].Play();
        GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 1);

        StartCoroutine(SourdCorout());

    }

    private IEnumerator SourdCorout()
    {
        while (true)
        {
            int rnd = Random.Range(0, randomSourd);
            if (isSourd && rnd == 1)
            {
                if(!isAccouphene)
                {
                    isAccouphene = true;
                    GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 0);
                } else
                {
                    isAccouphene = false;
                    GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 1);
                }

            }
            yield return new WaitForSeconds(retryTimeSourd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSourd) {
            //GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sourd", 1);
            // ensuite aléatoirement on activera désactivera l'acouiphene

        }
        else {
            GetComponents<FMODUnity.StudioEventEmitter>()[2].SetParameter("Silence", 1);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sourd", 0);
        }
        // On va regarder si y a un ennemi proche
        // On garde la plus petite distance aussi
        float minDistance = maxDistanceBeforeHearing+1;
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = Vector3.Distance(Enemy.transform.position, transform.position);
            if (distance < minDistance)
                minDistance = distance;
        }

        if (minDistance <= maxDistanceBeforeHearing)
        {
            playSound = true;
            GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("Silence", 0);
            GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 1);
            // QUand y a le batement de coeur on retire le son du truc
        }
        else
        {
            playSound = false;
            GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("Silence", 1);
            GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 0);

        }

        if (playSound)
        {
            float ratio = minDistance / maxDistanceBeforeHearing;
            GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("reverb", ratio);
        }
    }
}
