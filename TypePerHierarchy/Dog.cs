namespace InHeritance
{
    public class Dog : Animal
    {
        public virtual DogId DogId { get; set; }

        public Dog(DogId dogId)
        {
            DogId = dogId;
        }

        public Dog()
        {
        }

        public virtual string Breed { get; set; }

    }
}