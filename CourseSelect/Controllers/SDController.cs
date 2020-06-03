using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{
    public class SDController : Controller
    {
        private readonly IDBBCService _dBBCService;
        private readonly IDBBCToUserService _dBBCToUserService;
        private readonly IUsersService _usersService;

        public SDController(
            IDBBCService dBBCService,
            IDBBCToUserService dBBCToUserService,
            IUsersService usersService)
        {
            _dBBCService = dBBCService;
            _dBBCToUserService = dBBCToUserService;
            _usersService = usersService;
        }

        [Route("Fill")]
        [HttpPost]
        public async Task Fill()
        {
            List<AspNetUsers> users = new List<AspNetUsers>()
            {
                new AspNetUsers()
                {
                    UserName = "Jhon",
                    Email = "123456@gmail.com",
                    Credit = "Student",
                    Surname = "Wilson",
                    PasswordHash = "AQAAAAEAACcQAAAAEDPwXXx3p9qMfLYoDG5yhJQ3/CEjPCgp5dxH3BoLi6Oa7FdcoNRrjnD1CnFmnsgV9A=="
                },                  
                new AspNetUsers()
                {
                    UserName = "Altapak",
                    Email = "654321@gmail.com",
                    Credit = "Teacher",
                    Surname = "Wilson",
                    PasswordHash = "AQAAAAEAACcQAAAAEDPwXXx3p9qMfLYoDG5yhJQ3/CEjPCgp5dxH3BoLi6Oa7FdcoNRrjnD1CnFmnsgV9A==",
                    IsAdmin = true
                },
                new AspNetUsers()
                {
                    UserName = "Joshua",
                    Email = "65456@gmail.com",
                    Credit = "Teacher1",
                    Surname = "Imgur",
                    PasswordHash = "AQAAAAEAACcQAAAAEDPwXXx3p9qMfLYoDG5yhJQ3/CEjPCgp5dxH3BoLi6Oa7FdcoNRrjnD1CnFmnsgV9A==",
                    IsAdmin = true
                },
            };

            foreach (var item in users)
            {
                _usersService.AddUser(item);
            }

            await _usersService.Save();

            var student = _usersService.GetUsers().FirstOrDefault(x => x.Credit == users[0].Credit);
            var teacher = _usersService.GetUsers().FirstOrDefault(x => x.Credit == users[1].Credit);
            var teacher1 = _usersService.GetUsers().FirstOrDefault(x => x.Credit == users[0].Credit);

            List<Dbbc> dbbcs = new List<Dbbc>()
            {
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "Psihology: The science of behavior and mind. Psychology includes the study of conscious and unconscious phenomena, as well as feeling and thought. It is an academic discipline of immense scope. Psychologists seek an understanding of the emergent properties of brains, and all the variety of phenomena linked to those emergent properties, joining this way the broader neuro-scientific group of researchers. As a social science it aims to understand individuals and groups by establishing general principles and researching specific cases.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 20,
                    NumberSetsUsed = 1
                },
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "Yoga: The practice of yoga has been thought to date back to pre-vedic Indian traditions; possibly in the Indus valley civilization around 3000 BCE. Yoga is mentioned in the Rigveda, and also referenced in the Upanishads, . Although, yoga most likely developed as a systematic study around the 5th and 6th centuries BCE, in ancient India's ascetic and śramaṇa movements. The chronology of earliest texts describing yoga-practices is unclear, varyingly credited to the Upanishads. The Yoga Sutras of Patanjali date from the 2nd century BCE, and gained prominence in the west in the 20th century after being first introduced by Swami Vivekananda. Hatha yoga texts began to emerge sometime between the 9th and 11th century with origins in tantra.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 30,
                    NumberSetsUsed = 1
                },
                new Dbbc()
                {
                    TeacherId = teacher1.Id,
                    Description = "Cryptography: Cryptography prior to the modern age was effectively synonymous with encryption, the conversion of information from a readable state to apparent nonsense. The originator of an encrypted message shares the decoding technique only with intended recipients to preclude access from adversaries. The cryptography literature often uses the names Alice  for the sender, Bob  for the intended recipient, and Eve  for the adversary.[5] Since the development of rotor cipher machines in World War I and the advent of computers in World War II, the methods used to carry out cryptology have become increasingly complex and its application more widespread.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 60,
                    NumberSetsUsed = 0
                },
                new Dbbc()
                {
                    TeacherId = teacher1.Id,
                    Description = "Further Mathematics: A qualification in Further Mathematics involves studying both pure and applied modules. Whilst the pure modules (formerly known as Pure 4-6 or Core 4-6, now known as Further Pure 1-3, where 4 exists for the AQA board) build on knowledge from the core mathematics modules, the applied modules may start from first principles.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 10,
                    NumberSetsUsed = 0
                },
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "English: English has developed over the course of more than 1,400 years. The earliest forms of English, a group of West Germanic (Ingvaeonic) dialects brought to Great Britain by Anglo-Saxon settlers in the 5th century, are collectively called Old English. Middle English began in the late 11th century with the Norman conquest of England; this was a period in which English was influenced by Old French, in particular though its Old Norman dialect.[9][10] Early Modern English began in the late 15th century with the introduction of the printing press to London, the printing of the King James Bible and the start of the Great Vowel Shift.[11]",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2060, 1, 1),
                    NumberOfSeats = 100,
                    NumberSetsUsed = 0
                },
                new Dbbc()
                {
                    TeacherId = teacher1.Id,
                    Description = "Computer programming: s the process of designing and building an executable computer program to accomplish a specific computing result. Programming involves tasks such as: analysis, generating algorithms, profiling algorithms' accuracy and resource consumption, and the implementation of algorithms in a chosen programming language (commonly referred to as coding).[1][2] The source code of a program is written in one or more languages that are intelligible to programmers, rather than machine code, which is directly executed by the central processing unit. The purpose of programming is to find a sequence of instructions that will automate the performance of a task (which can be as complex as an operating system) on a computer, often for solving a given problem. The process of programming thus often requires expertise in several different subjects, including knowledge of the application domain, specialized algorithms, and formal logic.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 30,
                    NumberSetsUsed = 1
                }
            };

            foreach (var item in dbbcs)
            {
                _dBBCService.AddDBBC(item);
            }

            await _dBBCService.Save();

            var firstDbbc = _dBBCService.GetDBBC().First(x => x.Description.Split(':')[0] == "Psihology");

            List<Dbbctouser> dbbctousers = new List<Dbbctouser>()
            {
                new Dbbctouser()
                {
                    UserId = student.Id,
                    Dbbcid = firstDbbc.Id
                }
            };

            foreach (var item in dbbctousers)
            {
                _dBBCToUserService.AddDBBCToUser(item);
            }

            await _dBBCToUserService.Save();
        }
    }
}