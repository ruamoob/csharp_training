using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }


        public List<GroupData> GetGroupList()
        {
          List<GroupData> list = new List<GroupData>();
          Window dialogue= OpenGroupsDialogue();
          Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
          TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue= OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox =(TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        public void Remove()
        {
            Window dialogue = OpenGroupsDialogue();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            Window confirmation = dialogue.ModalWindow("Delete group");
            confirmation.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            confirmation.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();

        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);

        }
    }


}