﻿using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PetShopAPI.Contracts.User;
using Mapster;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение информации о всех пользователях
        /// </summary>
        /// <returns></returns>

        // GET api/<UserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _userService.GetAll();
            return Ok(Dto.Adapt<List<GetUserResponse>>());
        }

        /// <summary>
        /// Получение информации о пользователе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UserController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _userService.GetById(id);
            return Ok(Dto.Adapt<GetUserRequest>());
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "username": "string",
        ///        "email" : "email@gmail.com",
        ///        "passwordHash" : "!Pa$$word123@"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // POST api/<UserController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var Dto = request.Adapt<User>();
            await _userService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "userId": 1,
        ///       "email": "string",
        ///       "passwordHash": "string",
        ///       "username": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UserController>

        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var Dto = user.Adapt<User>();
            await _userService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<UserController>


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}