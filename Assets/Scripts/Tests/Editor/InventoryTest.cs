using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Tests
{
    public static class InventoryTest
    {
        [MenuItem("Tests/InventoryTest")]
        public static void Test()
        {
            int allPassed = 0;
            int allFailed = 0;

            AddItems(0, ref allPassed, ref allFailed);
            AddItems(1, ref allPassed, ref allFailed);
            AddItems(100, ref allPassed, ref allFailed);

            RemoveItems(0, 0, ref allPassed, ref allFailed);
            RemoveItems(1, 1, ref allPassed, ref allFailed);
            RemoveItems(100, 1, ref allPassed, ref allFailed);
            RemoveItems(0, 1, ref allPassed, ref allFailed);
            RemoveItems(1, 100, ref allPassed, ref allFailed);

            Debug.Log($"\nPASSED : {allPassed}\n FAILED : {allFailed}");
        }

        private static void AddItems(int count, ref int PASSED, ref int FAILD)
        {
            IInventory inventory = new InventorySlotsData(99);
            var item = new TestItem();
            var ID = item.ID;
            item.Count = count;
            inventory.AddItem(null, item);
            if (inventory.GetItemCount(ID) != count)
            {
                FAILD++;
                Debug.Log($"TRY ADD A {count} TEST_ITEMS!");
                Debug.Log($"{inventory} has items : {inventory.GetItemCount(ID)}");
                Debug.Log("--------------------------------------------------------");
            }
            else
            {
                PASSED++;
            }
        }

        private static void RemoveItems(int was, int taken, ref int PASSED, ref int FAILD)
        {
            IInventory inventory = new InventorySlotsData(99);
            var item = new TestItem();
            item.Count = was;
            var ID = item.ID;
            inventory.AddItem(null, item);

            int code = inventory.TryRemove(null, ID, taken) ? 0 : 1;

            if (was < taken)
            {
                if (code == 0)
                {
                    FAILD++;
                    Debug.Log($"TRY REMOVE {taken} TEST_ITEMS, WAS : {was}");
                    Debug.Log($"WAS: {was} < TAKEN: {taken} !BUT! deletion passed!");
                    Debug.Log("--------------------------------------------------------");
                }
                else
                {
                    PASSED++;
                }
            }
            else
            {
                if (code == 1)
                {
                    FAILD++;
                    Debug.Log($"TRY REMOVE {taken} TEST_ITEMS, WAS : {was}");
                    Debug.Log($"WAS: {was} > TAKEN: {taken} !BUT! deletion failed!");
                    Debug.Log("--------------------------------------------------------");
                }
                else
                {
                    PASSED++;
                }
            }
        }
    }

    public class TestItem : InventoryItem
    {
        [SerializeField] private Sprite sprite;

        public override bool IsEquipped { get; set; } = false;
        public override long ID => 1;
        public override int Count { get; set; }
        public override string Name { get; } = "Test Item";
        public override Sprite Sprite { get => sprite; set => Sprite = value; }
    }
}