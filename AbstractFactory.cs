using System;

namespace Lab2-3.AbstractFactory
{
     public abstract class AbstractFactory
    {
        public abstract Discipline CreateDiscipline();
    }

    public class ProfileFactory : AbstractFactory
    {
        public override Discipline CreateDiscipline();
        {
            return new ProfileDiscipline();
        }
    }
    public class NonProfileFactory: AbstaractFactory
    {
        public override Discipline CreateDiscipline();
        {
            return new NonProfileDisciplines();
        }
    }
    public class CargoFactory : AbstractFactory
    {
        public override Plane CreatePlane()
        {
            return new CargoPlane();
        }
    }

}
