using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    // store a public reference to the Player game object, so we can refer to it's Transform
    public GameObject player;
    public Canvas canvasMain;
    public Canvas canvasSkin;
    public Canvas canvasJoy;
    public Canvas canvasReload;
    public Text scoreText;
    public GameObject skinGO;
    // Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
    private Vector3 offset;
    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;
    private bool setStatusSkin;
    protected Joystick joystick;
    skinController adSkin;
    // At the start of the game..
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

        setStatusSkin = false;
        //skinGO = GameObject.Find("SkinGame");
        // Nếu không có Icon Skin thì mới cho phép Camera Follow theo Player
        if (setStatusSkin == false)
        {
            offset = transform.position - player.transform.position;
        }
        //Time.timeScale = 0.0f;
        // Create an offset by subtracting the Camera's position from the player's position
    }

    public void loadSceneSkinBall()
    {
        setStatusSkin = true;
        canvasMain.enabled = false;
        canvasJoy.enabled = false;
        canvasReload.enabled = false;
        canvasSkin.enabled = true;
        Time.timeScale = 1.0f;

        Vector3 posSkin = new Vector3(1.8f, 22.0f, -148f);
        Quaternion rotationSkin = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        this.transform.position = posSkin;
        this.transform.rotation = rotationSkin;
    }

    public void loadScenePlayer()
    {
        Vector3 posSkin = new Vector3(0.0f, 9.0f, -50.6f);
        Quaternion rotationSkin = Quaternion.Euler(20.0f, 0.0f, 0.0f);
        this.transform.position = posSkin;
        this.transform.rotation = rotationSkin;
        canvasMain.enabled = true;
        canvasJoy.enabled = true;
        canvasSkin.enabled = false;
        setStatusSkin = false;
        Time.timeScale = 0.0f;
        skinGO.SetActive(false);
        adSkin = skinGO.gameObject.GetComponent<skinController>();
        //adSkin.destroyAdBanner();
    }

    // After the standard 'Update()' loop runs, and just before each frame is rendered..
    void LateUpdate()
    {
        Vector3 nowCamera = player.transform.position + offset;
        float playCameraY = 7.4f;
        float playCameraX = nowCamera.x;
        float playCameraZ = nowCamera.z;
        int scoreUp = int.Parse(scoreText.text);
        Vector3 cameraPlay = new Vector3(playCameraX, playCameraY, playCameraZ);
        if (setStatusSkin == false)
        {
            if (scoreUp > 0)
            {
                transform.position = cameraPlay;
            }
        }
    }

    private void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        float cameAroundZ = joystick.Horizontal * tiltAngle;
        Quaternion target = Quaternion.Euler(20.6f, 0, cameAroundZ);
        if (setStatusSkin == false)
        {
            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}