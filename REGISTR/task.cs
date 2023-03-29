using System;
using System.ComponentModel;
using System.Linq;

namespace RegistrationService
{


    // User Sign in and Sign Up service for game
    internal class Program
    {
        //Global Data
        static string[] nicknames = new string[10];
        static string[] passwords = new string[10];

        static void Main(string[] args)
        {
            //Initialize Data
            SeedData();

            ApplicationStartWindow();
        }

        static void SeedData()
        {
            nicknames[0] = "Faiq";
            passwords[0] = "salam123";

            nicknames[1] = "Turan";
            passwords[1] = "salam123";

            nicknames[2] = "Razor";
            passwords[2] = "salam123";

        }

     
        static void ApplicationStartWindow()
        {
            //Reset Color when Application starts
            Console.ResetColor();

            Console.Title = "Clash of Clans";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome");
            Console.ResetColor();
            
            //Options
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SignIn();
            }
            else if(choice == "2")
            {
                SignUp();
            }
        }

        static void SignIn()
        {

            Console.Clear();
            Console.WriteLine("Welcome to Game.");

            Console.WriteLine("Enter Nickname: ");
            string nickname = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            bool usernameFound = false;
            bool passwordFound = false;
            for(int i = 0; i<nicknames.Length;i++){
                if(nicknames[i] == nickname){
                    usernameFound = true;
                }
            }
            for(int i = 0; i<passwords.Length;i++){
                if(passwords[i] == password){
                    passwordFound = true;
                }
            }
            if(usernameFound && passwordFound){
                Console.WriteLine("Sign in successfully!");
            }
            else if(usernameFound=false && passwordFound = true){
                Console.WriteLine("Username not found.Try again.");
            }
            else if(usernameFound && passwordFound = false){
                Console.WriteLine("Password is not correct. Please enter again.");
            }
            else{
                Console.WriteLine("Username and password is not found.");
            }

        }

        static void SignUp()
        {

            //Clear All Data from Console
            Console.Clear();

            //Header
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------->Sing Up Form<----------------------");
            Console.ResetColor();

            // Registration Form
            Console.WriteLine("Enter Your Nickname: ");
            string nickName = Console.ReadLine();

            while (CheckNickName(nickName) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("This NickName already exists. Please Enter new NickName: ");
                Console.ResetColor();
                nickName = Console.ReadLine();

            }
            AddToUsernames(nicknames,nickName);
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();

            while(CheckPassword(password) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Password is invalid. Password must contain at least 1 UpperCase, 1 Digit, 1 Symbol and length 12");
                Console.ResetColor();
                password = Console.ReadLine();
                
            }
            AddToPasswords(passwords,password);
            // Add new user to Arrays
            

        }

        static bool CheckNickName(string nickName)
        {
            bool notExist = true;

            for (int i = 0; i < nicknames.Length; i++)
            { 
                if(nicknames[i] == nickName)
                {
                    notExist = false;
                    break;
                }
            }

            return notExist;
        }

        static bool CheckPassword(string password)
        {
            if (password.Length < 12) return false;

            bool hasDigit = false;
            bool hasSymbol = false;
            bool hasUpper = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i])) hasDigit = true;
                if (char.IsUpper(password[i])) hasUpper = true;
                if (char.IsSymbol(password[i])) hasSymbol = true;
            }

            if (hasDigit && hasSymbol && hasUpper) return true;

            return false;

            //return password.Length < 12
            //    && password.Any(char.IsDigit)
            //    && password.Any(char.IsSymbol)
            //    && password.Any(char.IsUpper);
        }
        static string[] AddToUsernames(string[] usernames, string username){
            int countUsername = 0;
            for(int i = 0;i<usernames.Length;i++){
                if (usernames[i] !=""){
                    countUsername++;
                }
            }
            usernames[countUsername+1] = username;
        }
        static string[] AddToPasswords(string[] passwords, string password){
            int countPassword = 0;
            for(int i = 0;i<passwords.Length;i++){
                if (passwords[i] !=""){
                    countPassword++;
                }
            }
            passwords[countPassword+1] = password;
        }
    }
}
