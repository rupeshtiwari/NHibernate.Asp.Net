using System;
using System.Linq;
using NHibernate.Linq;

namespace InHeritance
{
    class Program
    {
        private static void Main(string[] args)
        {
            var helper = new NHibernateHelper();
          //  InheritanceExcersize.InsertNewSnake(helper);
           // InheritanceExcersize.UpdateSnake(helper);
          //  InheritanceExcersize.InsertNewPerson(helper);
            //InheritanceExcersize.InsertNewDog(helper);
            InheritanceExcersize.InsertTestletSegment(helper);
        }
    }
}
