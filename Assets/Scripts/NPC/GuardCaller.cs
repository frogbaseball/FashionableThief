using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GuardCaller : MonoBehaviour {
    private GameObject[] cops;
    [SerializeField] private GameObject copPrefab;
    [SerializeField] private Vector3 callPosition;
    [SerializeField] private int copsAmount;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private MusicPlayer musicPlayer;
    public void CallAllGuardsToPosition(Vector3 position) {
        if (cops == null) {
            musicPlayer.PlayMusic(1);
            CallCopsToPlace();
        }
        for (int i = 0; i < cops.Length; i++) {
            if (cops[i].GetComponent<CopStateMachine>().CurrentState == null)
                cops[i].GetComponent<CopStateMachine>().CallToLocation(position);
            else if (cops[i].GetComponent<CopStateMachine>().CurrentState.ToString() == "CatchPlayerState")
                return;
            else
                cops[i].GetComponent<CopStateMachine>().CallToLocation(position);
        }
    }
    public void CallCopsToPlace() {
        cops = new GameObject[copsAmount];
        for (int i = 0; i < cops.Length; i++) {
            cops[i] = Instantiate(copPrefab, callPosition + Vector3.right * i, Quaternion.identity);
            cops[i].GetComponent<CopStateMachine>().gameOverEvent.AddListener(delegate { gameOverScreen.EndGame(0); });
        }
    }
}