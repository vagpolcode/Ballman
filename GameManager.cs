using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{   
    public CharacterController controller;

    public GameObject PointsPrefab;
    GameObject actObject1;

    public GameObject Touch; 

    public GameObject World; 
    public GameObject EnemiesPrefab;
    public GameObject Points;
    public GameObject Enemies; 

    public GameObject SettingsButton;

    public GameObject NameChanged; 

    public GameObject SlowEnabled;
    public GameObject MediumEnabled;
    public GameObject FastEnabled;
    public GameObject FastestEnabled;

    public GameObject HardMode;
    public GameObject EasyMode;
    public GameObject MediumMode;
    
    public GameObject Ghost; 
    public GameObject Ghost1;
    public GameObject Ghost2;
    public GameObject Ghost3;
    public GameObject Ghost4;
    public GameObject Ghost5;
    public GameObject Ghost6;
    public GameObject Ghost7;
    public GameObject Ghost8;
    public GameObject Ghost9;
    public GameObject Ghost10;
    public GameObject Ghost11;
    public GameObject Ghost12;
    public GameObject Ghost13;
    public GameObject Ghost14;
    public GameObject Ghost15;
    public GameObject Ghost16;
    public GameObject Ghost17;
    public GameObject Ghost18;
    public GameObject Ghost19;

    public Quaternion orginalRosPlayer;
    public Vector3 orginalPosPlayer;
    public Vector3 orginalPos;
    public Vector3 orginalPos1;
    public Vector3 orginalPos2;
    public Vector3 orginalPos3;
    public Vector3 orginalPos4;
    public Vector3 orginalPos5;
    public Vector3 orginalPos6;
    public Vector3 orginalPos7;
    public Vector3 orginalPos8;
    public Vector3 orginalPos9;
    public Vector3 orginalPos10;
    public Vector3 orginalPos11;
    public Vector3 orginalPos12;
    public Vector3 orginalPos13;
    public Vector3 orginalPos14;
    public Vector3 orginalPos15;
    public Vector3 orginalPos16;
    public Vector3 orginalPos17;
    public Vector3 orginalPos18;
    public Vector3 orginalPos19;

    public Vector3 orginalPosPoints;


  

    public GameObject Ads;
    public GameObject MenuCamera;
    public GameObject Player;
    public GameObject Canvas;
    public GameObject CanvasScoreBoard;
    public GameObject CanvasSettings;


    public Text scoreText;
    public Text livesText;
    //public Text levelText;
    public Text nameText;

    public Text name1Text;
    public Text name2Text;
    public Text name3Text;
    public Text name4Text;
    public Text name5Text;

    public Text score1Text;
    public Text score2Text;
    public Text score3Text;
    public Text score4Text;
    public Text score5Text;

    public Text PlayerName;
    

    public int HighScore1;
    public int HighScore2;
    public int HighScore3;
    public int HighScore4;
    public int HighScore5;
    public int temp;
    public string tempName;

    public int gameon;
    public int RecorScore;

    public static GameManager Instance { get; private set; }

    // public GameObject[] levels;

    
    public int Finish;
    public int _score;
    public int _lives;
    public int _level;
    public string _name;
    public string SaveName;

    public string _name1;
    public string _name2;
    public string _name3;
    public string _name4;
    public string _name5;

    public int _score1;
    public int _score2;
    public int _score3;
    public int _score4;
    public int _score5;

    public int Worldrotate;


    public int Score
    {
        get { return _score; }
        set { _score = value;
            scoreText.text = "SCORE: " + _score;
        }
    }

    public int Lives
    {
        get { return _lives; }
        set { _lives = value;
            livesText.text = "LIVES: " + _lives;
        }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value;
           // levelText.text = "LEVEL: " + _level;
        }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value;
            nameText.text = "NAME: " + _name;
        }
    }

    public string Name1
    {
        get { return _name1; }
        set { _name1 = value;
            name1Text.text = "NAME: " + _name1;
        }
    }

    public string Name2
    {
        get { return _name2; }
        set { _name2 = value;
            name2Text.text = "NAME: " + _name2;
        }
    }

    public string Name3
    {
        get { return _name3; }
        set { _name3 = value;
            name3Text.text = "NAME: " + _name3;
        }
    }

    public string Name4
    {
        get { return _name4; }
        set { _name4 = value;
            name4Text.text = "NAME: " + _name4;
        }
    }

    public string Name5
    {
        get { return _name5; }
        set { _name5 = value;
            name5Text.text = "NAME: " + _name5;
        }
    }

    public int Score1
    {
        get { return _score1; }
        set { _score1 = value;
            score1Text.text = "SCORE: " + _score1;
        }
    }
    public int Score2
    {
        get { return _score2; }
        set { _score2 = value;
            score2Text.text = "SCORE: " + _score2;
        }
    }
    public int Score3
    {
        get { return _score3; }
        set { _score3 = value;
            score3Text.text = "SCORE: " + _score3;
        }
    }
    public int Score4
    {
        get { return _score4; }
        set { _score4 = value;
            score4Text.text = "SCORE: " + _score4;
        }
    }
     public int Score5
    {
        get { return _score5; }
        set { _score5 = value;
            score5Text.text = "SCORE: " + _score5;
        }
    }


    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;
    

    public enum State { MENU, PLAY, MENU2, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;

    public void PlayClicked()
    {
        gameon = 1;
        SwitchState(State.PLAY);
    }
    public void SettingsClicked()
    {   
        gameon =0;
        Ads.SetActive(true);
        CanvasSettings.SetActive(true);
        Canvas.SetActive(false);
        CanvasScoreBoard.SetActive(false);
        NameChanged.SetActive(false);
        
    }
    public void ScoreBoardClicked()
    {
        gameon = 0;
        Canvas.SetActive(false);
        CanvasScoreBoard.SetActive(true);
        NameChanged.SetActive(false);
        //SwitchState(State.MENU2);
    }
     public void ReturnClicked()
    {
        SwitchState(State.LOADLEVEL);
    }
    public void ResetAllClicked()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void SubmitClicked()
    {
        Name = PlayerName.text;
        NameChanged.SetActive(true);
    }
     public void BackClicked()
    {
        gameon = 0;
        Ads.SetActive(false);
        Canvas.SetActive(true);
        CanvasScoreBoard.SetActive(false);
        CanvasSettings.SetActive(false);
        NameChanged.SetActive(false);
        HardMode.SetActive(false);
        EasyMode.SetActive(false);
        MediumMode.SetActive(false);
        FastEnabled.SetActive(false);
        MediumEnabled.SetActive(false);
        SlowEnabled.SetActive(false);
        FastestEnabled.SetActive(false);
        Touch.SetActive(false);
    }
     
        public void SlowClicked()
        {
            SlowEnabled.SetActive(true);
            FastestEnabled.SetActive(false);
            MediumEnabled.SetActive(false);
            FastEnabled.SetActive(false);
        }
        public void MediumMouseClicked()
        {
            MediumEnabled.SetActive(true);
            SlowEnabled.SetActive(false);
            FastestEnabled.SetActive(false);
            FastEnabled.SetActive(false);
        }
        public void FastClicked()
        {
            FastEnabled.SetActive(true);
            MediumEnabled.SetActive(false);
            SlowEnabled.SetActive(false);
            FastestEnabled.SetActive(false);
        }
        public void FastestClicked()
        {
            FastestEnabled.SetActive(true);
            FastEnabled.SetActive(false);
            MediumEnabled.SetActive(false);
            SlowEnabled.SetActive(false);
        }


    public void EasyClicked()
    {
        Lives = 5;
        EasyMode.SetActive(true);
        MediumMode.SetActive(false);
        HardMode.SetActive(false);
    }
    public void MediumClicked()
    {
        Lives = 3;
        MediumMode.SetActive(true);
        EasyMode.SetActive(false);
        HardMode.SetActive(false);
    }
    public void HardClicked()
    {
        Lives = 1;
        HardMode.SetActive(true);
        EasyMode.SetActive(false);
        MediumMode.SetActive(false);
    }

      public void TouchClicked()
    {
        Touch.SetActive(true);
    }
      public void QuitClicked()
    {
         
        Application.Quit();
        
    }


    // Start is called before the first frame update
    void Start()
    {   
        orginalRosPlayer = Player.transform.rotation;
        orginalPosPlayer = Player.transform.position;

        //orginalPosPoints = Points.transform.position;
        //orginalPosPoints = PointsPrefab.transform.position;

        orginalPos = Ghost.transform.position;
        orginalPos1 = Ghost1.transform.position;
        orginalPos2 = Ghost2.transform.position;
        orginalPos3 = Ghost3.transform.position;
        orginalPos4 = Ghost4.transform.position;
        orginalPos5 = Ghost5.transform.position;
        orginalPos6 = Ghost6.transform.position;
        orginalPos7 = Ghost7.transform.position;
        orginalPos8 = Ghost8.transform.position;
        orginalPos9 = Ghost9.transform.position;
        orginalPos10 = Ghost10.transform.position;
        orginalPos11 = Ghost11.transform.position;
        orginalPos12 = Ghost12.transform.position;
        orginalPos13 = Ghost13.transform.position;
        orginalPos14 = Ghost14.transform.position;
        orginalPos15 = Ghost15.transform.position;
        orginalPos16 = Ghost16.transform.position;
        orginalPos17 = Ghost17.transform.position;
        orginalPos18 = Ghost18.transform.position;
        orginalPos19 = Ghost19.transform.position;
        
        Finish = 0;
        HighScore1 = 0;
        HighScore2 = 0;
        HighScore3 = 0;
        HighScore4 = 0;
        HighScore5 = 0;

        Touch.SetActive(false);
        NameChanged.SetActive(false);
        Name = "player";

        gameon = 0;
        Score = 0;
        Lives = 5;
        Level = 1;
        Cursor.visible = true;
        Worldrotate = 1;

        SlowEnabled.SetActive(false);
        FastestEnabled.SetActive(false);
        MediumEnabled.SetActive(false);
        FastEnabled.SetActive(false);

        HardMode.SetActive(false);
        EasyMode.SetActive(false);
        MediumMode.SetActive(false);

        Ads.SetActive(false);
        CanvasSettings.SetActive(false);
        CanvasScoreBoard.SetActive(false);
        panelLevelCompleted.SetActive(false);
        panelGameOver.SetActive(false);        
        panelMenu.SetActive(true);
        MenuCamera.SetActive(true);
        Canvas.SetActive(true);
        Player.SetActive(false);
        Enemies.SetActive(false);


        Instance = this;
        SwitchState(State.MENU);
    }

    // Update is called once per frame
    void Update()
    {      
        if(Worldrotate == 1)
        { 
        World.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 10f);
        }


        if(_lives > 0 && _score != 84500){
            Level = 1;
        }

        if(_lives==0 && Level == 1){
            Level = 0;
            controller.enabled = false;
            SwitchState(State.GAMEOVER);
            
        }
        else if((_score==84500 && Level == 1) || Finish == 1){

            Level = 0;
            controller.enabled = false;
            SwitchState(State.LEVELCOMPLETED);

        }

        else if(Input.GetKeyDown(KeyCode.Tab) && Level == 1 && gameon == 1)
        {
            SwitchState(State.MENU);
            SettingsButton.SetActive(false);
        }

        switch (_state)
        {
            case State.MENU:
                
                break;
            case State.PLAY:
                 
                break;
            case State.MENU2:
               
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:                
                break;
            case State.GAMEOVER:
                
                break;
        }
    }

    public void SwitchState(State newState)
    {
        EndState();
        BeginState(newState);
    }

   

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                Finish = 0;
                gameon = 0;
                Worldrotate = 1;
                CanvasScoreBoard.SetActive(false);
                panelLevelCompleted.SetActive(false);
                panelGameOver.SetActive(false);
                Player.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
                SettingsButton.SetActive(true);
                panelMenu.SetActive(true);
                MenuCamera.SetActive(true);
                Canvas.SetActive(true);
                Player.SetActive(false);
                Enemies.SetActive(false);
                Touch.SetActive(false);
                break;
            case State.PLAY:
                Worldrotate = 0;
                Player.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                panelPlay.SetActive(true);
                controller.enabled = true;
                NameChanged.SetActive(false);
                //    Instantiate(playerPrefab);
                // SwitchState(State.LOADLEVEL);
                break;
            case State.MENU2:
                break;
            case State.LEVELCOMPLETED:

                gameon = 0;
      
                RecorScore = Score;

                

                
                panelPlay.SetActive(false);            
                panelLevelCompleted.SetActive(true);
                Enemies.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                
                
                
                break;
            case State.LOADLEVEL:
                //Destroy(Player.gameObject);

                SaveName = Name;
                if(Score > HighScore1)
                {   
                    temp = HighScore1;
                    HighScore1 = Score; 
                    Score = temp;
                    Score1 = HighScore1;

                    tempName = Name1;
                    Name1 = Name; 
                    Name = tempName;
                }
                if(Score > HighScore2)
                {   
                    temp = HighScore2;
                    HighScore2 = Score; 
                    Score = temp;  
                    Score2 = HighScore2;

                    tempName = Name2;
                    Name2 = Name; 
                    Name = tempName;
                }
                if(Score > HighScore3)
                {
                    temp = HighScore3;
                    HighScore3 = Score; 
                    Score = temp;
                    Score3 = HighScore3;

                    tempName = Name3;
                    Name3 = Name; 
                    Name = tempName;
                }
                if(Score > HighScore4)
                {
                    temp = HighScore4;
                    HighScore4 = Score; 
                    Score = temp;   
                    Score4 = HighScore4;

                    tempName = Name4;
                    Name4 = Name; 
                    Name = tempName;
                }
                 if(Score > HighScore5)
                {
                    temp = HighScore5;
                    HighScore5 = Score; 
                    Score = temp;  
                    Score5 = HighScore5;

                    tempName = Name5;
                    Name5 = Name; 
                    Name = tempName;
                }

                Finish = 0;
                Name = SaveName;
                gameon = 0;
                Score = 0;
                Lives = 5;
                Destroy(Points.gameObject);
                Destroy(actObject1);
                actObject1 = Instantiate(PointsPrefab);
                
                panelMenu.SetActive(true);
                MenuCamera.SetActive(true);
                Canvas.SetActive(true);

                //PointsPrefab.transform.position = orginalPosPoints;
                //Points.transform.position = orginalPosPoints;

                Player.transform.rotation = orginalRosPlayer;
                Player.transform.position = orginalPosPlayer;
                Ghost.transform.position = orginalPos;
                Ghost1.transform.position = orginalPos1;
                Ghost2.transform.position = orginalPos2;
                Ghost3.transform.position = orginalPos3;
                Ghost4.transform.position = orginalPos4;
                Ghost5.transform.position = orginalPos5;
                Ghost6.transform.position = orginalPos6;
                Ghost7.transform.position = orginalPos7;
                Ghost8.transform.position = orginalPos8;
                Ghost9.transform.position = orginalPos9;
                Ghost10.transform.position = orginalPos10;
                Ghost11.transform.position = orginalPos11;
                Ghost12.transform.position = orginalPos12;
                Ghost13.transform.position = orginalPos13;
                Ghost14.transform.position = orginalPos14;
                Ghost15.transform.position = orginalPos15;
                Ghost16.transform.position = orginalPos16;
                Ghost17.transform.position = orginalPos17;
                Ghost18.transform.position = orginalPos18;
                Ghost19.transform.position = orginalPos19;






                //Player.transform.position = new Vector3( 1, 68, 100);
                

                SwitchState(State.MENU);
                break;
            case State.GAMEOVER:
  
                RecorScore = Score;
                gameon = 0;

                panelPlay.SetActive(false);
                panelGameOver.SetActive(true);
                Enemies.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                

                
                
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                
                panelMenu.SetActive(false);
                MenuCamera.SetActive(false);
                Canvas.SetActive(false);
                Player.SetActive(true);
                Enemies.SetActive(true);
                controller.enabled = true;
                break;
            case State.PLAY:
                break;
            case State.MENU2:
                break;
            case State.LEVELCOMPLETED:
                
                panelLevelCompleted.SetActive(false);

                Player.SetActive(false);

                panelMenu.SetActive(true);
                MenuCamera.SetActive(true);
                Canvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                break;
            case State.LOADLEVEL:
                
                break;
            case State.GAMEOVER:
                
                panelGameOver.SetActive(false);
                Player.SetActive(false);

                panelMenu.SetActive(true);
                MenuCamera.SetActive(true);
                Canvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                
                
                break;
        }
    }
















}
