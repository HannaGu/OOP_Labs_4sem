using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3.AbstractFactory
{
    public abstract class Subject           //AbstractProductA 
    {
        public abstract string Type();
    }

    public abstract class Teacher               //AbstractProductB
    {
        public abstract string Gender();
    }
    public class Economy : Subject             //ProductA1
    {
        public override string Type()
        {
            return "This is economy";
        }
    }

    public class English : Subject              //ProductA2
    {
        public override string Type()
        {
            return "This is english";
        }
    }

    public class DataBases : Subject            //ProductA3
    {
        public override string Type()
        {
            return "This is data bases";
        }
    }

    
    public class Male : Teacher                 //ProductB1
    {
        public override string Gender()
        {
            return "I'm man";
        }
    }

    public class Female : Teacher               //ProductB2
    {
        public override string Gender()
        {
            return "I'm woman";
        }
     }

    public abstract class DisciplineFactory     // AbstractFactory
    {
        public abstract Subject CreateSubject();
        public abstract Teacher CreateTeacher();
    }

    class Discipline1 : DisciplineFactory       //ConcreteFactory1
    {
        public override Subject CreateSubject()
        {
            return new Economy();
        }

        public override Teacher CreateTeacher()
        {
            return new Male();
        }
    }

    class Discipline2 : DisciplineFactory          //ConcreteFactory2
    {
        public override Subject CreateSubject()
        {
            return new DataBases();
        }

        public override Teacher CreateTeacher()
        {
            return new Female();
        }
    }

    //Client
    class Discipline
    {
        private Subject subject;
        private Teacher teacher;
        public Discipline(DisciplineFactory factory)
        {
            subject = factory.CreateSubject();
            teacher = factory.CreateTeacher();
        }

        public string Name()
        {
            return subject.Type();
        }

        public string Person()
        {
            return teacher.Gender();
        }
    }
}

