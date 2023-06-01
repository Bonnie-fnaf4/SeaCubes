using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public int[] pos;
    //public int startPos;
    public int thisPos;
    public Rigidbody rigidbody;

    public ColorGraund[] colorGraunds;
    public GraundController[] graundControllers;

    public float speedForse, ForseToMagnits, forseToMove;

    public bool leftMove, rightMove, jump, startColor;

    public Text countCube;

    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    private HashSet<Controller> controllerList = new HashSet<Controller>();

    public SwithsColor[] swithsColors;

    public int idTypeOld = -1, idColorOld = -1;

    public LevelAndMoney levelAndMoney;

    public int affectedBodiesCountNoLevelApp;

    public bool isOptimize = false;

    private void Start()
    {
        //ColorGraundsRefrash(thisPos);
        //Time.timeScale = 2;
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        if (startColor)
        {
            ColorGraundsRefrash(thisPos);
            startColor = false;
        }

        if (!isOptimize) countCube.text = affectedBodies.Count + "/350";
        if (isOptimize) countCube.text = affectedBodiesCountNoLevelApp + affectedBodies.Count +"/350";

        if (affectedBodies.Count >= 350 && !isOptimize) Finish();
        if (affectedBodies.Count >= 175 && isOptimize) FinishNoLevelApp();

        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, transform.forward.z * speedForse);
        foreach (Rigidbody body in affectedBodies)
        {
            if(!(body == null) && Time.timeScale >= 1) 
            {
                Vector3 forceDirection = (transform.position - body.position).normalized;
                body.AddForce(forceDirection * ForseToMagnits * Time.deltaTime);
            }
        }

        if (leftMove && !rightMove)
        {
            if(transform.position.x <= pos[thisPos])
            {
                leftMove = false;
                //rigidbody.velocity = Vector3.zero;
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
                transform.position = new Vector3(pos[thisPos], transform.position.y, transform.position.z);
            }
        }

        if (rightMove && !leftMove)
        {
            if (transform.position.x >= pos[thisPos])
            {
                rightMove = false;
                //rigidbody.velocity = Vector3.zero;
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
                transform.position = new Vector3(pos[thisPos], transform.position.y, transform.position.z);
            }
        }

        if(transform.position.y <= 5.40f && jump)
        {
            jump = false;

            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            transform.position = new Vector3(transform.position.x, 5.43f, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftMove();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RightMove();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpMove();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Finish();
        }
    }
    public void JumpMove()
    {
        if (jump) return;
        rigidbody.constraints = RigidbodyConstraints.None;
        //rigidbody.AddForce(0, 500, 0);
        
        jump = true;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 10, transform.forward.z);
    }
    public void LeftMove()
    {
        if (rightMove)
        {
            rightMove = false;
            //rigidbody.velocity = Vector3.zero;
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            thisPos--;
            leftMove = true;
            rigidbody.velocity = new Vector3(-20, rigidbody.velocity.y, transform.forward.z * speedForse);
            //rigidbody.AddForce(-transform.right * forseToMove);
            //return;
        }
        else
        {
            if (thisPos <= 0)
            {
                thisPos = 0;
            }
            else
            {
                thisPos--;
                leftMove = true;
                rigidbody.velocity = new Vector3(-20, rigidbody.velocity.y, transform.forward.z * speedForse);
                //rigidbody.AddForce(-transform.right * forseToMove);
            }
        }
        ColorGraundsRefrash(thisPos);
    }

    public void RightMove()
    {
        if (leftMove)
        {
            leftMove = false;
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            //rigidbody.velocity = Vector3.zero;
            thisPos++;
            rightMove = true;
            rigidbody.velocity = new Vector3(20, rigidbody.velocity.y, transform.forward.z * speedForse);
            //rigidbody.AddForce(-transform.right * forseToMove);
            //return;
        }
        else
        {
            if (thisPos >= pos.Length - 1)
            {
                thisPos = pos.Length - 1;
            }
            else
            {
                thisPos++;
                rightMove = true;
                rigidbody.velocity = new Vector3(20, rigidbody.velocity.y, transform.forward.z * speedForse);
                //rigidbody.AddForce(transform.right * forseToMove);
            }
        }
        ColorGraundsRefrash(thisPos);
    }

    //

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.tag == "Cube") //Механизм добавления кубов в массив игрока для дальнейшего управления ими
        {
            Controller controller = other.GetComponent<Controller>(); //Эта штука будет отвечать за цвет куба
            if (controller.isDead == true) return;
            controllerList.Add(controller);
            controller.playerController2 = this;
            controller.PlayerCube();

            affectedBodies.Add(other.attachedRigidbody);
            other.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null && other.tag == "Cube")
        {
            affectedBodies.Remove(other.attachedRigidbody);
            Controller controller = other.GetComponent<Controller>();
            controller.BlackCube();
            controller.isDead = true;
            controllerList.Remove(controller);
        }
    }

    public void RemoveCube(Collider other, Controller controller)
    {
        affectedBodies.Remove(other.attachedRigidbody);
        controllerList.Remove(controller);
    }

    public void ColorGraundsRefrash(int id)
    {
        for(int i = 0; i < colorGraunds.Length; i++)
        {
            if (id == colorGraunds[i].id) colorGraunds[i].SetColor();
            else colorGraunds[i].RefreshColor();
        }
    }

    public void Finish()
    {
        foreach (Controller body in controllerList)
        {
            body.isDead = true;
            body.WhiteCube();
        }

        int idType = Random.RandomRange(0, 4), idColor = Random.RandomRange(0, 10);

        while(idType == idTypeOld)
        {
            idType = Random.RandomRange(0, 4);
        }
        idTypeOld = idType;

        while (idColor == idColorOld)
        {
            idColor = Random.RandomRange(0, 10);
        }
        idColorOld = idColor;

        foreach (SwithsColor color in swithsColors)
        {
            color.ColorPanel(idType, idColor);
        }

        PlayerPrefs.SetInt("TypeColorLevel", idType);
        PlayerPrefs.SetInt("ColorLevel", idColor);
        levelAndMoney.UpLevel();

        foreach (GraundController controller in graundControllers)
        {
            controller.SetSpawnObject(idType);
        }
        affectedBodies.Clear();
    }

    public void FinishNoLevelApp()
    {
        affectedBodiesCountNoLevelApp += affectedBodies.Count;
        if (affectedBodiesCountNoLevelApp >= 350)
        {
            affectedBodiesCountNoLevelApp = 0;
            Finish();
        }
        else
        {
            foreach (Controller body in controllerList)
            {
                body.isDead = true;
                body.WhiteCube();
            }

            affectedBodies.Clear();
        }
    }

    public void SwitchColorFromStorage(int idType, int idColor)
    {
        foreach (SwithsColor color in swithsColors)
        {
            color.ColorPanel(idType, idColor);
        }
    }

    public float affectedBodiesCount()
    {
        return affectedBodies.Count;
    }
}
