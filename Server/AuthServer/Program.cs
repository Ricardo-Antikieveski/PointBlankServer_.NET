using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer
{
    class Program
    {
        static Mutex mutex;
        static bool ServerLoaded = false;

        static async Task Main()
        {
            mutex = new Mutex(true, "AuthServerSingletonMutex", out bool isNewInstance);
            if (!isNewInstance)
            {
                Console.WriteLine("Outra instância do AuthServer já está em execução. Encerrando esta instância.");
                return;
            }

            Console.Title = "Inicializando Auth Server...";
            Console.WindowWidth = 100;

            var animTask = AnimationGame("Iniciando Servidor: Aguarde!");

            try
            {
                Thread.Sleep(2700);



                ServerLoaded = true;
                await animTask;


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" * ==========================================================");
                Console.WriteLine(" * Firewall system is in use in your network protocol.");
                Console.WriteLine(" * Brazil - RS");
                Console.WriteLine(" * Desenvolvido por: (c) Ricardo Antikieveski - 2018 - 2026");
                Console.WriteLine(" * ==========================================================");
                Console.ResetColor();

                ManualResetEvent wait = new ManualResetEvent(false);
                wait.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public static async Task AnimationGame(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            while (!ServerLoaded)
            {
                for (int i = 0; i < text.Length && !ServerLoaded; i++)
                {
                    Console.Write(text[i]);
                    await Task.Delay(80);
                }

                if (!ServerLoaded)
                {
                    await Task.Delay(500);
                    Console.Write("\r" + new string(' ', text.Length) + "\r"); 
                }
            }
            Console.WriteLine("======================");
            Console.WriteLine("= Servidor iniciado! =");
            Console.WriteLine("======================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ResetColor();
        }
    }
}
