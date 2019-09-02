using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPause = true; //是否暂停
    private Shape currentShape = null;
    public Shape[] shapes;

    private Transform blockHolder;

    private Ctrl ctrl;

    public Color[] colors;
    // Start is called before the first frame update
    private void Awake()
    {
        ctrl = GetComponent<Ctrl>();
        blockHolder = transform.Find("BlockHolder").GetComponent<Transform>();
    }
     

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        if(currentShape == null)
        {
            SpawnShape();
        }
    }

    public void StartGame()
    {
        isPause = false;
        if (currentShape != null)
        {
            currentShape.Resume();
        }
    }
    public void PauseGame()
    {
        isPause = true;
        if(currentShape != null)
        {
            currentShape.Pause();
        }
    }
    public void ClearShape()
    {
        if(currentShape!= null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }

    void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        currentShape = GameObject.Instantiate(shapes[index]);
        currentShape.transform.SetParent (blockHolder);
        currentShape.Init(colors[indexColor], ctrl, this);
    }

    public void FallDown()
    {
        currentShape = null;
        if (ctrl.model.isDataUpdate)
        {
            ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
        }
        foreach(Transform t in blockHolder)
        {
            if(t.childCount <= 1)
            {
                Destroy(t.gameObject);
            }
        }
        if (ctrl.model.IsGameOver())
        {
            PauseGame();
            ctrl.view.ShowGameOverUI(ctrl.model.Score);
        }

    }
}
