//using UnityEngine;
//using UnityEditor.UI;

//public class InventoryHandler : MonoBehaviour
//{
//    [SerializeField] Image image;

//    private Item _item;
//    public Item item 
//        { get { return _item; }
//        set { _item = value;
//            if (_item == null)
//            {
//                image.enabled = false;
//            }
//            else
//            {
//                image.sprite = _item.Icon;
//                image.enabled = true;
//            }
//        }
//    }

//    private void OnValidate()
//    {
//        if (image == null)
//        {
//            image = GetComponent<Image>();
//        }
//    }
//}
