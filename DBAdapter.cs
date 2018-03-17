using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lab4
{
    static class DBAdapter
    {
        public static List<Person> Users { get; }

        static DBAdapter()
        {
            var filepath = Path.Combine(GetAndCreateDataPath(), Person.filename);
            if (File.Exists(filepath))
            {
                try
                {
                    Users = SerializeHelper.Deserialize<List<Person>>(filepath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                    throw;
                }
            }
            else
            {
                Users = new List<Person>();
                for(int i = 0; i<50;++i)
                {
                    Person toAdd = new Person($"Olya{i}", $"Petrenko{i}", new DateTime(1996, 5, 23));
                    Users.Add(toAdd);
                }
            }
        }

        internal static Person CreatePerson(string name, string lastName, string email, DateTime dateOfBirth)
        {
            Person person=null;
            try
            {

                person =new Person(name, lastName, email, dateOfBirth);
            }
            catch (FutureDateOfBirthException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            catch (OldDateOfBirthException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            catch (WrongEmailAdressException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (person != null)
                Users.Add(person);
            return person ;
        }

        internal static void SaveData()
        {
            SerializeHelper.Serialize(Users, Path.Combine(GetAndCreateDataPath(), Person.filename));
        }

        private static string GetAndCreateDataPath()
        {
            string dir = StationManager.WorkingDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

    }
}
