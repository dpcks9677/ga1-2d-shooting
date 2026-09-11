using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [Header("아이템 프리팹들")] [SerializeField] private Item[] _itemPrefabs;

    [Header("풀 사이즈")] [SerializeField] private int _poolSize;

    private Item[,] _pool;

    private static ItemPool _instance = null;
    public static ItemPool Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        _pool = new Item[_itemPrefabs.Length, _poolSize];

        for (int i = 0; i < _itemPrefabs.Length; i++)
        {
            Item itemPrefab = _itemPrefabs[i];
            for (int j = 0; j < _poolSize; j++)
            {
                Item item = Instantiate(itemPrefab, gameObject.transform);
                item.gameObject.SetActive(false);
                _pool[i, j] = item;
            }
        }
    }

    public Item GetItem(ItemType itemType)
    {
        for (int i = 0; i < _itemPrefabs.Length; i++) // 타입별로 순회 하면서
        {
            if (_pool[i, 0].Type != itemType) // 첫번째 요소의 타입이 내가 원하는게 아니라면 스킵
            {
                continue;
            }

            for (int j = 0; j < _poolSize; j++) // 원하는 타입의 배열 순회
            {
                Item item = _pool[i, j];

                // 비활성화 되어있는 (즉, 누가 빌려가지 않은 ) 총알 반환
                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(true);
                    return item;
                }
            }
        }

        return null;
    }
}