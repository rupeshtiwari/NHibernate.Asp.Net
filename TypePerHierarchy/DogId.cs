namespace InHeritance
{
    public class DogId
    {
        public virtual string DogGuidId{ get; set; }

        public DogId(string id)
        {
            DogGuidId = id;
        }
        public DogId()
        {
            
        }
    }
}