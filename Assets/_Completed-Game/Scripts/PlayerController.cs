using UnityEngine;
// Include the namespace required to use Unity UI
using UnityEngine.UI;
using System.Collections;
//using GoogleMobileAds.Api;
public class PlayerController : MonoBehaviour
{
    // Create public variables for player speed, and for the Text UI game objects
    private int gold;
    private int score;
    public float scaleFactor = 0.5f;
    private float timeRemaining;
    bool checkDia;
    private int timeNow;
    //bool currentPlatformAndroid;
    int textDia;
    bool statusGold;
    private float timeRemainingGold;
    private int i;
    public Canvas cvGold;
    public Canvas m_gameOverPopup;
    public GameObject popupBestScore;
    public Text goldTimeText;
    public Text countText;
    public Text scoreText;
    public Text bestGoldText;
    public Text textbestScore;
    public Text diaText;
    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    //private Rigidbody rb;
    public LayerMask groundLayers;
    public SphereCollider col;
    bool checkGold;
    private int timeUpGold;

    public GameObject bloodEffect;
    //private GameObject pickGold;
    public GameObject diamondPick;
    //private GameObject Meteorite;
    public GameObject boxRandom;
    public GameObject skinGame;
    public GameObject ufoGO;
    public GameObject rocketFire;
    public GameObject GoAdVideo;
    public GameObject GoReload;
    GoldPooler goldPooler;
    MeteoritePooler meteoritePooler;

    Vector3 posPick;
    public Canvas cvTime;
    MeshRenderer ms;

    // At the start of the game..
    private Vector3[] verticesDefault;
    private Mesh mesh;
    public getMeshCap getMeshCap;
    public getMeshCube getMeshCube;
    private Renderer rend;
    ParticleSystem particlePlay;
    ParticleSystem.ShapeModule shapes;
    private Texture[] textureSkin;
    private Texture2D[] texturePS;
    public AudioSource m_audio;
    public AudioSource m_audioDie;
    public AudioSource audioBgr;
    public AudioClip[] yourAudioFile;
    Quaternion rotationSkin;
    //private RewardBasedVideoAd rewardBasedVideo;
    private void Awake()
    {
        ufoGO = GameObject.Find("PlayerBall/UfoBody");
        skinGame = GameObject.Find("/Canvas/ImgSkinBall");
        texturePS = new Texture2D[9];
        textureSkin = new Texture[9];
        texturePS = Resources.LoadAll<Texture2D>("Textures");
        textureSkin = Resources.LoadAll<Texture>("Textures");
    }

    void Start()
    {
        // Get singleton reward based video ad reference.
        goldPooler = GoldPooler.Instance;
        meteoritePooler = MeteoritePooler.Instance;
        m_audio = GetComponent<AudioSource>();
        m_audioDie = GameObject.Find("ASourceDie").GetComponent<AudioSource>();
        audioBgr = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        particlePlay = GetComponent<ParticleSystem>();
        col = GetComponent<SphereCollider>();
        mesh = GetComponent<MeshFilter>().mesh;
        Mesh meshs = GetComponent<MeshFilter>().sharedMesh;
        m_audio.clip = yourAudioFile[0];
        m_audioDie.clip = yourAudioFile[1];
        // shapes extend ParticleSystem.ShapeModule
        shapes = particlePlay.shape;
        verticesDefault = mesh.vertices;
        // Khởi động dừng Particle system của Player
        particlePlay.Stop();
        gold = 0;
        score = 0;
        // Run the SetCountText function to update the UI (see below)
        SetCountGold();
        SetScoreText();
        // Get instantiated mesh
        // Randomly change vertices
        Vector3[] vertices = mesh.vertices;
        Vector3[] tris = mesh.normals;
        Vector2[] Guv = mesh.uv;
        Vector2[] Guv2 = mesh.uv2;
        Vector3[] sharedVertices = meshs.vertices;
        rotationSkin = Quaternion.Euler(0.0f, 88.0f, 0.0f);

    }

    private void Update()
    {
        if (skinGame.activeInHierarchy == false)
        {
            textDia = int.Parse(goldTimeText.text);
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float speed = 30.0f;
            //Vector3 movement = new Vector3(1.0f * moveHorizontal, 0.0f, 1);
            //rb.AddForce(movement * speed);
            if (ufoGO.activeInHierarchy == true)
            {
                this.transform.rotation = rotationSkin;
            }
        }
        else
        {
            int idApply = PlayerPrefs.GetInt("Skin Apply");
            setSkinForPlayer(idApply);
        }


        //string strText = diaText.text;
        //int parseTime = int.Parse(strText);
        StartCoroutine(testTimeDiamond());
        StartCoroutine(testTimeGold());
    }

    IEnumerator testTimeGold()
    {
        if (checkGold == true)
        {
            timeRemainingGold -= Time.deltaTime;
            timeUpGold = (int)timeRemainingGold;
            SetGoldText();
            if (timeUpGold == 0)
            {
                checkGold = false;
                cvGold.enabled = false;
            }
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator testTimeDiamond()
    {
        if (checkDia == true)
        {
            timeRemaining -= Time.deltaTime;
            timeNow = (int)timeRemaining;
            SetDiamondText();
            if (timeNow == 0)
            {
                particlePlay.Stop();
                checkDia = false;
                cvTime.enabled = false;
            }
        }
        yield return new WaitForEndOfFrame();
    }

    void SetGoldText()
    {
        if (timeRemainingGold > 0)
        {
            goldTimeText.text = timeUpGold.ToString();
        }
        else
        {
            goldTimeText.text = "0";
        }
    }

    void SetDiamondText()
    {
        if (timeRemaining > 0)
        {
            diaText.text = timeNow.ToString();
        }
        else
        {
            diaText.text = "0";
        }
    }

    public void playGame()
    {
        Time.timeScale = 1.0f;
        skinGame.SetActive(false);
    }

    public void makeDeadplayer()
    {
        //string sumGold = sumGoldText.text;
        int goldNow = int.Parse(countText.text);
        int bestGold = int.Parse(bestGoldText.text);
        //int parseGold = int.Parse(sumGold);
        PlayerPrefs.SetInt("Sum Gold", goldNow + bestGold);

        int nowScore = int.Parse(scoreText.text);
        int bestScore = int.Parse(textbestScore.text);
        if (nowScore == 0)
        {
            GoAdVideo.SetActive(false);
        }
        if (nowScore > bestScore)
        {
            PlayerPrefs.SetInt("Best Score", nowScore);
        }
        // UFO bị tắt và điểm Score hiện tại = 0
        if (ufoGO.activeInHierarchy == false || nowScore == 0)
        {
            Instantiate(bloodEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            m_audioDie.Play();
            audioBgr.Stop();
        }
        else
        {
            ufoGO.SetActive(false);
            m_gameOverPopup.enabled = false;
            Instantiate(bloodEffect, transform.position, transform.rotation);
        }
    }

    public void makePlayerLife()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            GoAdVideo.SetActive(false);
            GoReload.SetActive(true);
            gameObject.SetActive(true);
            timeRemaining = 10.0f;
            checkDia = true;
            Vector3 posNew = this.transform.position;
            posNew.z = posNew.z + 5.0f;
            this.transform.position = posNew;
            m_gameOverPopup.enabled = false;
            particlePlay.Play();
            cvTime.enabled = true;
        }
        else
        {
            GoAdVideo.SetActive(false);
            GoReload.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject,5);
            m_audio.Play();
            if (textDia > 0)
            {
                gold = gold + 2;
                // Run the 'SetCountText()' function (see below)
                SetCountGold();
            }
            else
            {
                // Add one to the score variable 'count'
                gold = gold + 1;
                // Run the 'SetCountText()' function (see below)
                SetCountGold();
            }
        }
        else if (other.gameObject.CompareTag("Diamond"))
        {
            timeRemaining = 10.0f;
            checkDia = true;
            particlePlay.Play();
            cvTime.enabled = true;
        }
        else if (other.gameObject.tag == "GoalPick")
        {
            score = score + 1;
            SetScoreText();
            int bestScore = int.Parse(textbestScore.text);
            if (score == 1 || score == 2)
            {
                ufoGO.SetActive(false);
            }
            if (score > bestScore)
            {
                popupBestScore.SetActive(true);
            }
            if (score > 4)
            {
                rocketFireMove callRocket = rocketFire.gameObject.GetComponent<rocketFireMove>();
                callRocket.callRocketFire();
            }
        }
        else if (other.gameObject.tag == "BoxRD")
        {
            other.gameObject.SetActive(false);
            //MeshRenderer game = other.gameObject.GetComponent<MeshRenderer>();
            //game.enabled = false;
            Destroy(other.gameObject, 5);

            int resultLVdefault = UnityEngine.Random.Range(1, 5);
            if (resultLVdefault == 1)
            {
                ufoGO.SetActive(true);
            }
            // Case Gold x2
            else if (resultLVdefault == 3)
            {
                timeRemainingGold = 15.0f;
                checkGold = true;
                cvGold.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GoalPick")
        {
            int resultLVdefault = UnityEngine.Random.Range(0, 5);
            int resultMeteo = UnityEngine.Random.Range(4, 6);
            int resultBox = Random.Range(2, 3);
            int resultLV3 = Random.Range(5, 20);
            for (i = 0; i < resultLV3; i++)
            {
                Vector3 localBallNow = this.transform.position;
                posPick = transform.position;
                posPick.y = Random.Range(3.0f, 5.0f);
                posPick.x = Random.Range(localBallNow.x - 1.5f, localBallNow.x + 1.5f);
                posPick.z = Random.Range(localBallNow.z + 10.0f, localBallNow.z + 30.0f);
                //Instantiate(pickGold, posPick, Quaternion.identity);
                goldPooler.SpawnFromPool("Pick Up", posPick, Quaternion.identity);
            }
            // Diamond Superpower
            if (resultLV3 == 6)
            {
                for (i = 0; i < resultLVdefault; i++)
                {
                    Instantiate(diamondPick, posPick, Quaternion.identity);
                }
            }
            //Random meteorite
            if (resultLVdefault == 2)
            {
                for (i = 0; i < resultMeteo; i++)
                {
                    Vector3 localBallNow = this.transform.position;
                    Vector3 posThien = transform.position;
                    posThien.y = Random.Range(5.0f, 7.0f);
                    posThien.x = Random.Range(localBallNow.x - 3.0f, localBallNow.x + 3.0f);
                    posThien.z = Random.Range(localBallNow.z + 10.0f, localBallNow.z + 15.0f);
                    //Instantiate(Meteorite, posThien, Quaternion.identity);
                    meteoritePooler.SpawnFromPool("Stone", posThien, Quaternion.identity);
                }
            }
            // Random appears Box ?
            if (resultLVdefault == 2)
            {
                for (i = 0; i < resultBox; i++)
                {
                    Vector3 localBallNows = this.transform.position;
                    Vector3 posBoxrd = transform.position;
                    posBoxrd.y = Random.Range(5.0f, 8.0f);
                    posBoxrd.x = Random.Range(localBallNows.x - 2.0f, localBallNows.x + 2.0f);
                    posBoxrd.z = Random.Range(localBallNows.z + 15.0f, localBallNows.z + 25.0f);
                    Instantiate(boxRandom, posBoxrd, Quaternion.identity);
                }
            }
        }
    }

    public void setSkinForPlayer(int idSkin)
    {
        rend.material.mainTexture = textureSkin[idSkin];
        shapes.texture = texturePS[idSkin];
    }

    public void setMeshForPlay()
    {
        // Get instantiated mesh
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Randomly change vertices
        Vector3[] vertices = mesh.vertices;
        int p = 0;
        while (p < vertices.Length)
        {
            vertices[p] += new Vector3(Random.Range(-0.3F, 0.3F), Random.Range(-0.3F, 0.3F), Random.Range(-0.3F, 0.3F));
            p++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    public void setMeshCap()
    {
        mesh.vertices = getMeshCap.verticesCapsule;
        mesh.RecalculateNormals();
    }

    public void setMeshCube()
    {
        mesh.vertices = getMeshCube.verticesCube;
        mesh.RecalculateNormals();
    }

    public void setMeshDefault()
    {
        mesh.vertices = verticesDefault;
        mesh.RecalculateNormals();
    }

    public void setSharedMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        int p = 0;
        while (p < 10)
        {
            vertices[p] *= scaleFactor;
            p++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    void SetCountGold()
    {
        // Update the text field of our 'countText' variable
        countText.text = gold.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }
}