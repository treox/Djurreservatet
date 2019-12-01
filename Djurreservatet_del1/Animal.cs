namespace Djurreservatet
{
    public class Animal
    {
        public string type {get; protected set;}
        public string name {get; protected set;}

        public Animal(string type, string name)
        {
            this.name = name;
            this.type = type;
        }
    }
}