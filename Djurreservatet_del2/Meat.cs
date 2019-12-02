using System.Collections.Generic;

namespace Djurreservatet
{
    public class Meat : Food
    {
        public List<Meat> meatList;
        public Meat(string foodType) : base(foodType)
        {
            meatList = new List<Meat>();
        }

        public override void DecreaseFoodCount(int number)
        {
            for (int n = 1; n <= number; n++)
            {
                meatList.RemoveAt(meatList.Count - n);
            }
            
        }
    }
}