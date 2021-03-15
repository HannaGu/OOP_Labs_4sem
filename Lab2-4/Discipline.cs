using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab2_3
{
   public class SemAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = @"^([1-2]*\d{1};)*$";
            Regex regex = new Regex(pattern);
            if (value!=null&&regex.IsMatch(Convert.ToString(value)))
                return true;
            else
            {
               this.ErrorMessage = "Запись должна иметь формат '1;2;'";
                return false;
            }
        }
    }

    [Serializable]
    public class Lecturer
    {
        [Required(ErrorMessage = "Не указано имя преподавателя")]
        public string name { get; set; }
        [Required]
        public string department { get; set; }
        public string room { get; set; }
    }
    public class Discipline
    {
        public string type { get; set; }
        [Required]
        public Lecturer lecturer;
        [Required]
        public string discipline { get; set; }
       
        [Required]
        [SemAttribute]
        public string sem { get; set; }
        [Required]
        public uint course { get; set; }
        public string speciality { get; set; }
        [Required]
        public uint lections { get; set; }
        public uint labs { get; set; }
        [Required]
        public string testing { get; set; }               

        public Discipline() { }
    }
}
