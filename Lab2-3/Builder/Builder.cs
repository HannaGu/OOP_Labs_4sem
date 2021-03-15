using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3.Builder
{
    class Title
    {
        public string subjectTitle { get; set; }
    }
    class Labs
    {
       public int labsAmount { get; set; }
    }
    class Lections
    {
        public int lectAmount { get; set; }
    }
    class Seminars
    {
        public int semAmount { get; set; }
    }

    class BSubject
    {
        public Title title { get; set; }
        public Labs labs  { get; set; }        
        public Lections lections { get; set; }
        public Seminars seminars{ get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Subject: "+title.subjectTitle + "\n");
            if (labs != null)
                sb.Append("Amount of labs: "+labs.labsAmount + "\n");
            if (lections != null)
                sb.Append("Amount of lections: "+lections.lectAmount +"\n");
            if (seminars != null)
                sb.Append("Amount of seminars: " + seminars.semAmount + " \n");
            return sb.ToString();
        }
    }

    abstract class SubjectBuilder
    {
        public BSubject subject { get; private set; }
        public void CreateSubject()
        {
            subject = new BSubject();
        }

        public abstract void SetTitle();
        public abstract void SetLabs();
        public abstract void SetLections();
        public abstract void SetSeminars();
    }

    class Director
    {
        public BSubject Build(SubjectBuilder subjectBuilder)
        {
            subjectBuilder.CreateSubject();
            subjectBuilder.SetTitle();
            subjectBuilder.SetLabs();
            subjectBuilder.SetLections();
            subjectBuilder.SetSeminars();
            return subjectBuilder.subject;
        }

    }
    class Subject1 : SubjectBuilder
    {
        public override void SetTitle()
        {
            this.subject.title = new Title{ subjectTitle = "Economy" };
        }

        public override void SetLabs()
        {
            //
        }

        public override void SetLections()
        {
            this.subject.lections = new Lections { lectAmount = 10};
        }

        public override void SetSeminars()
        {
            this.subject.seminars = new Seminars { semAmount =8 };
        }
    }

    class Subject2 : SubjectBuilder
    {
        public override void SetTitle()
        {
            this.subject.title = new Title { subjectTitle = "Data Bases" };
        }

        public override void SetLabs()
        {
            this.subject.labs = new Labs { labsAmount = 16 };
        }

        public override void SetLections()
        {
            this.subject.lections = new Lections { lectAmount = 18 };
        }

        public override void SetSeminars()
        {
            //
        }
    }
}
