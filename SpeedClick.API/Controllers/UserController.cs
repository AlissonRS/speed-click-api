﻿using Alisson.Core;
using Alisson.Core.Encryption;
using Alisson.Core.IoC;
using Alisson.Core.Repository;
using Alisson.Core.Services.Commands.RegisterUser;
using SpeedClick.API.Models;
using SpeedClick.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace SpeedClick.API.Controllers
{
    public class UserController : ApiController
    {

        private ICommandHandler<RegisterUserCommandData> RegisterUser;

        public UserController(ICommandHandler<RegisterUserCommandData> registerUser)
        {
            this.RegisterUser = registerUser;
        }

        public ResponseData<IEnumerable<UserModelResponse>> Get()
        {
            ResponseData<IEnumerable<UserModelResponse>> resp = new ResponseData<IEnumerable<UserModelResponse>>();
            resp.Data = AutoMapperFacade.Map < IEnumerable < UserModelResponse >>(BaseRepository<User>.getAll());
            resp.Message = "";
            resp.Success = true;
            return resp;
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return BaseRepository<User>.getByID(id);
        }

        // GET: api/User/5
        public ResponseData<UserModelResponse> Get(string login, string password)
        {
            ResponseData<UserModelResponse> resp = new ResponseData<UserModelResponse>();
            try
            {
                string encrypted = StringCipher.Encrypt(password, StringCipher.SecretMessage);
                User users = BaseRepository<User>.getAll().Where(u => u.Login == login && u.Password == encrypted).FirstOrDefault();
                if (users == null)
                    throw new InvalidOperationException("Login e/ou Senha incorreto(s)!");
                resp.Data = AutoMapperFacade.Map<UserModelResponse>(users);
                resp.Message = "Login efetuado com sucesso!";
                resp.Success = true;
            }
            catch (Exception e)
            {
                resp.Message = e.Message ?? "Not treated exception!";
            }
            return resp;
        }

        // POST: api/User
        public ResponseData<UserModelResponse> Post([FromBody]UserModelPost user)
        {
            ResponseData<UserModelResponse> resp = new ResponseData<UserModelResponse>();
            try
            {
                if (BaseRepository<User>.getAll().Where(u => u.Login == user.Login).Count() > 0)
                    throw new InvalidOperationException("Este login já está sendo utilizado por outro jogador!");
                string ip = Helpers.GetVisitorIPAddress(HttpContext.Current.Request);
                string encrypted = StringCipher.Encrypt(user.Password, StringCipher.SecretMessage);
                RegisterUserCommandData data = new RegisterUserCommandData(user.Login, encrypted, ip);
                resp.Data = AutoMapperFacade.Map<UserModelResponse>(this.RegisterUser.Handle(data).user);
                resp.Message = "Registro efetuado com sucesso!";
                resp.Success = true;
            }
            catch (Exception e)
            {
                resp.Message = e.Message;
            }
            return resp;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
