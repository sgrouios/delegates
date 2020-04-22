using System;
using System.Collections.Generic;
using System.Linq;
using ObjectLibrary;


namespace FileParser
{


    public class PersonHandler
    {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();

            for (int i = 1; i < people.Count; i++)
            {
                People.Add(new Person(Convert.ToInt32(people[i][0]), people[i][1].ToString(), people[i][2].ToString(), new DateTime(Convert.ToInt64(people[i][3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            List<Person> ordered = new List<Person>();
            List<Person> oldest = new List<Person>();

            ordered = People.OrderBy(p => p.Dob).ToList();
            oldest.Add(ordered[0]);

            for (int i = 1; i < ordered.Count; i++)
            {
                if (ordered[i].Dob.Equals(oldest[0].Dob))
                {
                    oldest.Add(ordered[i]);
                }
            }

            return oldest;
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People[id].ToString();
        }

        public List<Person> GetOrderBySurname()
        {
            return People.OrderBy(p => p.Surname).ToList();
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            int count = 0;

            foreach (Person pers in People)
            {
                if (pers.Surname.StartsWith(searchTerm, !caseSensitive, null))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            //IEnumerable<IGrouping<DateTime, Person>>
            var grouped = People.OrderBy(p => p.Dob).GroupBy(o => o.Dob);

            List<string> result = new List<string>();

            foreach (var person in grouped)
            {
                result.Add($"{person.Key.ToString("dd/MM/yyyy")} {person.Count()}");
            }
            return result;
        }
    }
}