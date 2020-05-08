using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUD.Dtos;
using DapperCRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserRepository _repo;
        /// <summary>
        /// constructor for UserController. It uses _repo from userRepository
        /// </summary>
        /// <param name="repo"></param>
        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _repo.GetById(id);
        }
        
        [HttpPost]
        public void Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = new User
            {
                Name = userForRegisterDto.Name,
                Address = userForRegisterDto.Address
            };

            _repo.Add(userToCreate);
        }

        [HttpPut("{id}")]
        public void Update(UserForRegisterDto userForRegisterDto, int id)
        {
            var userToUpdate = new User
            {
                UId = id,
                Name = userForRegisterDto.Name,
                Address = userForRegisterDto.Address
            };

            _repo.Update(userToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }


    }
}