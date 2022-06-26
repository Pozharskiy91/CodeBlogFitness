using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController (string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            var gender = new Gender(genderName);

            User = new User(userName, gender, birdthDay,weight, height);

        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save() 
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользовательское приложения.</returns>

        
    }
}
