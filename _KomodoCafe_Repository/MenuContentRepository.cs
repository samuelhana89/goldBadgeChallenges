using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoCafe_Repository
{
    public class MenuContentRepository
    {
        private List<MenuContent> _listOfItem = new List<MenuContent>();

        //Create
        public void AddContentToList(MenuContent content)
        {
            if (content != null)
            {

               _listOfItem.Add(content);
            }
        }

        //Read
        public List<MenuContent> GetContentList()
        {
            return _listOfItem;
        }

        //Delete
        public bool DeleteContentFromList(string mealName)
        {
            MenuContent content = GetContentByName(mealName);
            if (content == null)
            {
                return false;
            }

            int initialItem = _listOfItem.Count;
            _listOfItem.Remove(content);

            if(initialItem > _listOfItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        //check if the meal name exist to help with delete method
        public MenuContent GetContentByName(string mealName)
        {
            foreach(MenuContent content in _listOfItem)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

    }
}
