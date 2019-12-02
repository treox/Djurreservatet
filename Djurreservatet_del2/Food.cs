namespace Djurreservatet
{
    public abstract class Food
    {
        public string foodType {get; protected set;}

        public Food(string foodType)
        {
            this.foodType = foodType;
        }

        public abstract void DecreaseFoodCount(int number);
    }
}