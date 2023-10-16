namespace GrafosExemplo
{
    public class Friend
    {
        public string Name;
        public List<string> Hobbies;
        public bool IsBase;

        // Constructor for the Friend class
        public Friend(string name, List<string> hobbies, bool isBase)
        {
            this.Name = name;
            this.Hobbies = hobbies;
            this.IsBase = isBase;
        }
    }
}