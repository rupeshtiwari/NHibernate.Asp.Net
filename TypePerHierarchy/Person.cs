using FluentNHibernate.Mapping;

namespace InHeritance
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Address Address { get; set; }
    }


    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(m => m.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Component(x => x.Address, m =>
            {
                m.Map(a => a.Street);
                m.Map(a => a.State);
                m.Map(a => a.City);
            });
        }
    }
}