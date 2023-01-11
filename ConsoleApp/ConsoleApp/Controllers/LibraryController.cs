using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
    public class LibraryController
    {
        private readonly ILibraryService _libraryservice;

        public LibraryController()
        {
            _libraryservice = new LibraryService();
        }


        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Please add library name:");
            LibraryName: string libraryName =Console.ReadLine();
            ConsoleColor.Red.WriteConsole("Please add library seat count");
             SeatCount: string seatCountStr=Console.ReadLine();
            int SeatCount;

            bool isCorrectSeatCount=int.TryParse(seatCountStr, out SeatCount);

            if (isCorrectSeatCount)
            {
                try
                {
                    Library library = new Library
                    {
                        Name = libraryName,
                        SeatCount = SeatCount
                    };

                   var response = _libraryservice.Create(library);
                    ConsoleColor.Green.WriteConsole($"{response.Id} {response.Name} {response.SeatCount}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto LibraryName;
                    
                }      
            }
            else
            {
                ConsoleColor.Cyan.WriteConsole("Please add correct format seat count");
                goto SeatCount;
            }
        }
    }
}
