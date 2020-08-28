using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
    
    public class MoveTo : MonoBehaviour 
    {
       //Variables públicas
       public float agroDistance;
       public float patrolDistance;

       //Variables privadas
       private GameObject player;
       private NavMeshAgent agent;
       private GameObject[] patrolPoint;
       private Transform actualPatrol;
       private PlayerController playerScript;

       //Inicialización
       void Start ()
       {
          agent = GetComponent<NavMeshAgent>();
          player = GameObject.FindWithTag("Player");
          patrolPoint = GameObject.FindGameObjectsWithTag("PatrolPoint");
          playerScript = player.GetComponent<PlayerController>();
          NextPatrol();
       }

       //Update
       void FixedUpdate()
       {
           //Patrulla
           if (Vector3.Distance(this.transform.position, player.transform.position) > agroDistance)
           {
               Debug.Log("Patrulla");
               if (Vector3.Distance(this.transform.position, actualPatrol.position) < patrolDistance)
               {
                   Debug.Log("Cambio de patrulla");
                   NextPatrol();
               }
               else
               {
                   agent.SetDestination(actualPatrol.position);
               }
           }
           //Detección del jugador
           else
           {
              agent.SetDestination(player.transform.position); 
           }
       }

       //Colisión con el jugador
       private void OnCollisionEnter(Collision other)
       {
           if (other.gameObject.tag == "Player")
           {
               if (this.gameObject.tag == "Slime")
               {
                   //Lanzar soltar objeto
                   playerScript.setInvert();
               } else if (this.gameObject.tag == "Virus")
               {
                   playerScript.setInvert();
                   //Lanzar inversión de controles
               }
               Destroy(this.gameObject);
           }
       }

       //Elección de punto de patrulla
       void NextPatrol ()
       {
           actualPatrol = patrolPoint[Random.Range(0, patrolPoint.Length - 1)].transform;
       }
    }