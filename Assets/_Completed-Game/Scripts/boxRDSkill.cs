using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class boxRDSkill : MonoBehaviour
{
    public GameObject playerUfo;
    public GameObject Meteorite;
    public GameObject pickDiamond;
    public GameObject goldGO;
    public PlayerController playerUFO;
    private MeteoritePooler meteoritePooler;
    GoldPooler goldPooler;

    private void Start()
    {
        meteoritePooler = MeteoritePooler.Instance;
        goldPooler = GoldPooler.Instance;
        playerUfo = GameObject.FindGameObjectWithTag("Player");
        playerUFO = playerUfo.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.tag == "Player")
        {
            int result = Random.Range(1, 3);
            int resultCommon = Random.Range(1, 6);
            int resultRD = Random.Range(5, 10);
            // Case Meteorite Xuat hien
            if (resultCommon == 1)
            {
                for (int i = 0; i < resultRD; i++)
                {
                    Vector3 localBallNow = playerUfo.transform.position;
                    Vector3 posThien = transform.position;
                    posThien.y = Random.Range(5.0f, 7.0f);
                    posThien.x = Random.Range(localBallNow.x - 2.0f, localBallNow.x + 2.0f);
                    posThien.z = localBallNow.z + 8.0f;
                    //Instantiate(Meteorite, posThien, Quaternion.identity);
                    meteoritePooler.SpawnFromPool("Stone", posThien, Quaternion.identity);
                }
            }
            // Case pickDiamond Xuat hien
            if (resultCommon == 2)
            {
                for (int i = 0; i < result; i++)
                {
                    Vector3 localBallNow = playerUfo.transform.position;
                    Vector3 posPick = transform.position;
                    posPick.y = Random.Range(3.0f, 5.0f);
                    posPick.x = Random.Range(-3.0f, 3.0f);
                    posPick.z = Random.Range(localBallNow.z + 10.0f, localBallNow.z + 20.0f);
                    Instantiate(pickDiamond, posPick, Quaternion.identity);
                }
            }
            // Case Gold Xuat hien
            if (resultCommon == 3)
            {
                for (int i = 0; i < resultRD; i++)
                {
                    Vector3 localBallNow = playerUFO.transform.position;
                    Vector3 posGold = transform.position;
                    posGold.y = Random.Range(3.0f, 5.0f);
                    posGold.x = Random.Range(-3.0f, 3.0f);
                    posGold.z = Random.Range(localBallNow.z + 15.0f, localBallNow.z + 20.0f);
                    goldPooler.SpawnFromPool("Pick Up", posGold, Quaternion.identity);
                }
            }
            // Case set about default for Player Start
            if (resultCommon == 4)
            {
                playerUFO.setMeshDefault();
            }
            // Case set Mesh thành Capsule
            if (resultCommon == 5)
            {
                playerUFO.setMeshCap();
            }
        }
    }
}
