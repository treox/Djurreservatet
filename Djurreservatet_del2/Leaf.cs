using System.Collections.Generic;

namespace Djurreservatet
{
    public class Leaf : Food
    {
        public List<Leaf> leafList;

        public Leaf(string foodType) : base(foodType)
        {
            leafList = new List<Leaf>();
        }

        public override void DecreaseFoodCount(int number)
        {
            for (int n = 1; n <= number; n++)
            {
                leafList.RemoveAt(leafList.Count - n);
            }
            
        }
    }
}