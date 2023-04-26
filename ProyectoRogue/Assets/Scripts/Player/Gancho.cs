using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] LayerMask grapplableMask;
    [SerializeField] float maxDistance = 20f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

    bool isGrapable = false;

    [HideInInspector] public bool retracting = false;

    Vector2 target;

    public GameObject escudo;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        escudo.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && !isGrapable)
        {
            StartGrapple();
        }
        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
            transform.position = grapplePos;
            line.SetPosition(0, transform.position);

            if(Vector2.Distance(transform.position,target) < 1.5f)
            {
                retracting = false;
                isGrapable = false;
                line.enabled = false;
                StartCoroutine(Esperar());
            }
        }
    }

    private void StartGrapple()
    {
      
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);
    
        if(hit.collider != null)
        {
            PlayerMove.instance.tag = "Gancho";
            escudo.SetActive(true);
            isGrapable = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;
            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;

        line.SetPosition(0,transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;

        for(; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            yield return null;
        }
        line.SetPosition(1,target);
        retracting = true;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
        PlayerMove.instance.tag = "Player";
        escudo.SetActive(false);
    }


}
