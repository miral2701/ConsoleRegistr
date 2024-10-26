namespace ConsoleApp14
{
    internal class Program
    {
        public enum Menu { Register=1,Login,Exit}
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            { 
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var userService = new UserRepository(db);

                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                int choice = 0;

                while(true)
                {
                    choice = Helper.GetInt("menu item");

                    switch ((Menu)choice) 
                    { 
                    case Menu.Register:
                            if (Register(userService))
                            {
                                Helper.WriteSuccessfulMessage("Successfil registration.Pleade log in");

                            }
                            else
                            {

                                goto case Menu.Register;
                            }
                            break;
                            case Menu.Login:
                            string username = Helper.GetString("username");
                            string password= Helper.GetString("password");

                            User user=new User() { Password = password,Username=username };
                            if (Helper.Check(user))
                            {
                                if (userService.AuthenticateUser(user))
                                {
                                    Helper.WriteSuccessfulMessage("Login Successful");
                                    ShowMainMenu(username);
                                }
                                else
                                {
                                    Helper.WriteErrorMessage("login failed");
                                }
                            }
                            else
                            {
                                goto case Menu.Login;
                            }
                            break;

                        case Menu.Exit:
                            return;
                            

                        default:
                            Helper.WriteErrorMessage("Invalid option");
                            break;

                    }
                }
            }
        }
        public static void ShowMainMenu(string username)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine( "                                       MAIN MENU");
            Console.WriteLine( "User:"+username);
            Console.ReadLine();
        }
        private static bool Register(UserRepository userRepository) { 
        
            string username=Helper.GetString("username");
            string password=Helper.GetString("password");   
            User user=new User { Password = password ,Username=username};
            if (Helper.Check(user))
            {
                userRepository.RegisterUser(user);
                return true;
            }
            return false;
        }
    }
}
