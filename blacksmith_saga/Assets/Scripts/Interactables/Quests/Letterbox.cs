using UnityEngine;
using Random = System.Random;
using Math = System.Math;



public class Letterbox : MonoBehaviour
{

    private bool _isNear = false;
    public GameObject acceptRefuseHint;
    public GameObject questImage;
    public GameObject completeQuest;
    
    private SpriteRenderer _questImageSpriteRenderer;
    private SpriteRenderer _acceptRefuseHintSpriteRenderer;
    private SpriteRenderer _completeQuestHintSpriteRenderer;
    private Random _random = new Random();


    private bool _questOngoing = false;
    // private SmithingTask _ongoingTask;
    private void Awake()
    
    {
        _acceptRefuseHintSpriteRenderer = acceptRefuseHint.GetComponent<SpriteRenderer>();
        _questImageSpriteRenderer = questImage.GetComponent<SpriteRenderer>();
        _completeQuestHintSpriteRenderer = completeQuest.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _acceptRefuseHintSpriteRenderer.color = new Color(255, 255, 255, 0);
        _questImageSpriteRenderer.color = new Color(255, 255, 255, 0);
        _completeQuestHintSpriteRenderer.color = new Color(255, 255, 255, 0);
        
        bool isKeyAccept = Input.GetKeyDown(KeyCode.E);
        bool isKeyRefuse = Input.GetKeyDown(KeyCode.N);
        
        if (_isNear)
        {
            if (!_questOngoing)
            {
                int number  = _random.Next(1, 5);

                int randomReward = number * number;
                int fame = number;
                int chunksNeeded = 1;
                QuestManager.Instance.CreateSmithingTask(randomReward, fame, chunksNeeded);
                
                _acceptRefuseHintSpriteRenderer.color = new Color(255, 255, 255, 255);
                _questImageSpriteRenderer.color = new Color(255, 255, 255, 255);
            
                if (isKeyAccept)
                {
                    _questOngoing = true;
                }
            }
            if (_questOngoing)
            {
                
                print("quest is ongoing!!!");
                SmithingTask ongoingTask = QuestManager.Instance.GetOngoingSmithingTask();
                
                _completeQuestHintSpriteRenderer.color = new Color(255, 255, 255, 255);

                
                if (isKeyAccept)
                {
                    print("accept!");
                    if (ongoingTask.ChunksNeeded <= ResourcesManager.instance.blueChunksAmount)
                    {
                        ResourcesManager.instance.blueChunksAmount -= 1;
                        ResourcesManager.instance.moneyAmount += ongoingTask.Reward;
                        ResourcesManager.instance.fameAmount += ongoingTask.Fame;
                        QuestManager.Instance.CompleteOngoingSmithingTask();
                        _questOngoing = false;
                    }
                }

            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _isNear = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        _isNear = false;
        _acceptRefuseHintSpriteRenderer.color = new Color(255, 255, 255, 0);
        _questImageSpriteRenderer.color = new Color(255, 255, 255, 0);
        _completeQuestHintSpriteRenderer.color = new Color(255, 255, 255, 0);
    }
}
